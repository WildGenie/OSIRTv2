using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace OSIRT.Helpers
{
    public class OsirtHelper
    {


        //http://stackoverflow.com/questions/12278978/combining-n-datatables-into-a-single-datatable
        public static DataTable MergeAll(IList<DataTable> tables, string primaryKeyColumn)
        {
            if (!tables.Any())
                throw new ArgumentException("Tables must not be empty", "tables");
            if (primaryKeyColumn != null)
                foreach (DataTable t in tables)
                    if (!t.Columns.Contains(primaryKeyColumn))
                        throw new ArgumentException("All tables must have the specified primarykey column " + primaryKeyColumn, "primaryKeyColumn");

            if (tables.Count == 1)
                return tables[0];

            DataTable table = new DataTable("TblUnion");
            table.BeginLoadData(); // Turns off notifications, index maintenance, and constraints while loading data
            foreach (DataTable t in tables)
            {
                table.Merge(t); // same as table.Merge(t, false, MissingSchemaAction.Add);
            }
            table.EndLoadData();

            if (primaryKeyColumn != null)
            {
                // since we might have no real primary keys defined, the rows now might have repeating fields
                // so now we're going to "join" these rows ...
                var pkGroups = table.AsEnumerable()
                    .GroupBy(r => r[primaryKeyColumn]);
                var dupGroups = pkGroups.Where(g => g.Count() > 1);
                foreach (var grpDup in dupGroups)
                {
                    // use first row and modify it
                    DataRow firstRow = grpDup.First();
                    foreach (DataColumn c in table.Columns)
                    {
                        if (firstRow.IsNull(c))
                        {
                            DataRow firstNotNullRow = grpDup.Skip(1).FirstOrDefault(r => !r.IsNull(c));
                            if (firstNotNullRow != null)
                                firstRow[c] = firstNotNullRow[c];
                        }
                    }
                    // remove all but first row
                    var rowsToRemove = grpDup.Skip(1);
                    foreach (DataRow rowToRemove in rowsToRemove)
                        table.Rows.Remove(rowToRemove);
                }
            }

            return table;
        }



        //http://stackoverflow.com/questions/281640/how-do-i-get-a-human-readable-file-size-in-bytes-abbreviation-using-net
        public static string GetHumanReadableFileSize(string fileName)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = new FileInfo(fileName).Length;
            int order = 0;
            while (len >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                len = len / 1024;
            }

            return string.Format("{0:0.##} {1}", len, sizes[order]); ;
        }


        /// <summary>
        /// Returns the assoicated Enum from a String.
        /// </summary>
        /// <typeparam name="T">The Enum type to parse to</typeparam>
        /// <param name="value">The string you want to parse to Enum<T></param>
        /// <returns>An Enum of type T</returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }


        public static Bitmap GetBitmap(BitmapSource source)
        {
            Bitmap bmp = new Bitmap(source.PixelWidth, source.PixelHeight, PixelFormat.Format32bppPArgb);
            BitmapData data = bmp.LockBits(new Rectangle(System.Drawing.Point.Empty, bmp.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
            source.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bmp.UnlockBits(data);
            return bmp;
        }

        /// <summary>
        /// Obtains a file's hash using the specified hash
        /// </summary>
        /// <param name="path">The location of the file required to be hashed</param>
        /// <param name="hashWanted">The hash alogorithm required</param>
        /// <returns>Hash of the file</returns>
        public static string GetFileHash(string path, string hashWanted)
        {
            HashService hashService = HashServiceFactory.Create(hashWanted);
            string hash = "";
            using (FileStream fileStream = File.OpenRead(path))
            {
                hash = hashService.ToHex(hashService.ComputeHash(fileStream));
            }
            return hash;
        }

        /// <summary>
        /// Obtains a file's hash using the saved hash setting
        /// </summary>
        /// <param name="path">The location of the file required to be hashed</param>
        /// <returns>Hash of the file</returns>
        public static string GetFileHash(string path)
        {
            return GetFileHash(path, UserSettings.Load().hash);
        }


        public static bool IsValidFilename(string fileName)
        {


            //< > : " / \ | ? *
            return !string.IsNullOrWhiteSpace(fileName) && fileName.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;
        }

        public static FileStream WaitForFile(string fullPath)
        {
            for (int numTries = 0; numTries < 10; numTries++)
            {
                try
                {
                    FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                    fs.ReadByte();
                    fs.Seek(0, SeekOrigin.Begin);

                    return fs;
                }
                catch (IOException)
                {
                    Thread.Sleep(50);
                }
            }

            return null;
        }

    }
}
