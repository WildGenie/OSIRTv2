using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using ImageMagick;
using OSIRT.Extensions;
using System.Collections.Generic;
using System.Net;
using CefSharp;

namespace OSIRT.Helpers
{
    public class OsirtHelper
    {

        public static bool DisableWebRtc = false;
        public static Dictionary<string, string> Favourites = new Dictionary<string, string>();
        public static List<History> history = new List<History>();


        public static string GetIpFromUrl(string url)
        {
            Uri uri = new Uri(url);
            IPAddress[] addresses = Dns.GetHostAddresses(uri.Host);

            string message = "";
            foreach (var address in addresses)
            {
                message += address.ToString() + "\r\n";
            }
            return message;
        }

        //http://stackoverflow.com/questions/12899876/checking-strings-for-a-strong-enough-password
        public enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }

      
        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length < 4)
                return PasswordScore.VeryWeak;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"\d+", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success &&
                Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @".[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }

        public static string GetSafeFilename(string filename, string mimeType)
        {
            try
            {
                //filename = Path.GetFileName(filename);
                filename = StripQueryFromFile(filename);
                filename = Path.GetFileName(filename);
                filename = string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));

                if (filename.Length > 150)
                {
                    filename = filename.Substring(0, 150);
                }

                if (filename == "") filename = "blank_file_" + DateTime.Now.ToString("ddMMyyyyHHmmss");// + "." + MimeTypeMap.GetExtension(MimeType);

                
                if (string.IsNullOrEmpty(Path.GetExtension(filename))) 
                {
                    Console.WriteLine("MIME: " + mimeType);
                    try
                    {
                        filename += MimeTypes.MimeTypeMap.GetExtension(mimeType);
                    }
                    catch
                    {
                        if (mimeType == "text/javascript")
                        {
                            filename += ".js";
                        }
                        else
                        {
                            filename += ".unknown";
                        }
                    }
                }

            }
            catch
            {
                filename = "error_file_" + DateTime.Now.ToString("ddMMyyyyHHmmss");// + "." + MimeTypeMap.GetExtension(MimeType);
            }
            return filename;
        }




        public static void CheckCacheDirectoriesExist()
        {
           Directory.CreateDirectory(Constants.CacheLocation);
           Directory.CreateDirectory(Constants.VideoCacheLocation);
           Directory.CreateDirectory(Constants.TextCacheLocation);
            if (!File.Exists(Constants.ApplicationLog)) File.Create(Constants.ApplicationLog);
            if (!File.Exists(Constants.Favourites)) File.Create(Constants.Favourites);
            if (!File.Exists(Constants.UserAgentsFile) || new FileInfo(Constants.UserAgentsFile).Length == 0)
            {
                string res = GetResource("ua.txt");
                File.WriteAllText(Constants.UserAgentsFile, res);
            }
        }

        public static void WriteFavourites()
        {
            string[] lines = Favourites.Select(kvp => kvp.Key + "=" + kvp.Value).ToArray();
            File.WriteAllLines(Constants.Favourites, lines);
        }


        public static bool IsOnFacebook(string url)
        {

            string stripped = StripQueryFromPath(url);
            var rCaseInsensitive = new Regex(@"^(https?:\/\/)?((w{3}\.)?)facebook\.com\/(?:[^\s()\\\[\]{};:'"",<>?«»“”‘’]){5,}$", RegexOptions.IgnoreCase);
            return rCaseInsensitive.IsMatch(stripped);
        }

        public static string ResizeConstabLogo(string filepath)
        {
            //need to convert image to png
            try
            {
                using (MagickImage image = new MagickImage(filepath))
                {
                    image.Write(Constants.TempLogoFile);
                }

                using (MagickImage image = new MagickImage(Constants.TempLogoFile))
                {
                    MagickGeometry size = new MagickGeometry(196, 196);
                    size.IgnoreAspectRatio = false;
                    image.Resize(size);
                    image.Write(Constants.TempImgFile);
                }
                string base64;
                using (Image img = new Bitmap(Constants.TempImgFile))
                {
                     base64 = img.ToBase64Encoded();
                }
                ImageDiskCache.RemoveItemsInCache();
                return base64;
            }
            catch
            {
                throw new Exception("Unable to save icon");
            }

            
      

        }
    

        //http://stackoverflow.com/questions/1337750/get-imageformat-from-file-extension/1337773#1337773
        public static ImageFormat GetImageFormat(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(extension))
                throw new ArgumentException(
                    string.Format("Unable to determine file extension for fileName: {0}", fileName));

            switch (extension.ToLower())
            {
                case @".bmp":
                    return ImageFormat.Bmp;

                case @".gif":
                    return ImageFormat.Gif;

                case @".ico":
                    return ImageFormat.Icon;

                case @".jpg":
                case @".jpeg":
                    return ImageFormat.Jpeg;

                case @".png":
                    return ImageFormat.Png;

                case @".tif":
                case @".tiff":
                    return ImageFormat.Tiff;

                case @".wmf":
                    return ImageFormat.Wmf;

                default:
                    throw new NotImplementedException();
            }
        }

        public static bool HasJpegExtension(string path)
        {
            return Path.GetExtension(path).Equals(".jpg", StringComparison.InvariantCultureIgnoreCase)
                    || Path.GetExtension(path).Equals(".jpeg", StringComparison.InvariantCultureIgnoreCase);
        }

        public static string StripQueryFromFile(string file)
        {
            Uri uri = new Uri(file);
            if (uri.Query != string.Empty)
            {
                file = uri.OriginalString.Replace(uri.Query, "");
            } 
            return file;
        }

        public static string StripQueryFromPath(string path)
        {
            Uri uri = new Uri(path);
            return uri.GetLeftPart(UriPartial.Path);
        }


        public static string CreateHashForFolder(string path)
        {
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                         .OrderBy(p => p).ToList();

            //When we use the hash factory, we get exceptions. This is better than no hash at all.
            SHA512 hash = SHA512.Create(); 

            for (int i = 0; i < files.Count; i++)
            {
                string file = files[i];

                // hash path
                string relativePath = file.Substring(path.Length + 1);
                byte[] pathBytes = Encoding.UTF8.GetBytes(relativePath.ToLower());
                hash.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);

                // hash contents
                byte[] contentBytes = File.ReadAllBytes(file);
                if (i == files.Count - 1)
                    hash.TransformFinalBlock(contentBytes, 0, contentBytes.Length);
                else
                    hash.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
            }

            return BitConverter.ToString(hash.Hash).Replace("-", "").ToUpper();
        }


        //(Remember to change Build Action to "Embedded rsource" when adding a new resource
        public static string GetResource(string resource)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"OSIRT.Resources.{resource}";
            string result;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        public static bool IsOnTwitter(string url)
        {
            string pattern = @"http(?:s)?:\/\/(?:www.)?twitter\.com\/([a-zA-Z0-9_]+)";
            return Regex.Match(url, pattern).Success;
        }

        public static bool IsOnGoogle(string url)
        {
            return url.StartsWith("http://www.google") || url.StartsWith("https://www.google") || url.StartsWith("http://google") || url.StartsWith("https://google");
        }

        public static bool IsOnYouTube(string url)
        {
            string pattern = @"(https?\:\/\/)?(www\.youtube\.com|youtu\.?be)\/.+";
            return Regex.Match(url, pattern).Success;
        }

        /// <summary>
        /// Depth-first recursive delete, with handling for descendant 
        /// directories open in Windows Explorer.
        /// http://stackoverflow.com/questions/329355/cannot-delete-directory-with-directory-deletepath-true
        /// </summary>
        public static void DeleteDirectory(string path)
        {
            //Thread.Sleep(1); <--- Bad
            //TODO: Throwing a directory not found sometimes
            foreach (string directory in Directory.GetDirectories(path))
            {
                DeleteDirectory(directory);
            }

            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Debug.WriteLine("IOEXC");
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Debug.WriteLine("UNAUTH");
                Directory.Delete(path, true);
            }
        }



        //http://stackoverflow.com/questions/281640/how-do-i-get-a-human-readable-file-size-in-bytes-abbreviation-using-net
        public static string GetHumanReadableFileSize(string fileName)
        {
            try {
                if (fileName == null)
                    throw new ArgumentException("File name must not be null");

                string[] sizes = { "B", "KB", "MB", "GB" };
                double len = new FileInfo(fileName).Length;
                int order = 0;
                while (len >= 1024 && order + 1 < sizes.Length)
                {
                    order++;
                    len = len / 1024;
                }

                return $"{len:0.##} {sizes[order]}";

            } catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return "";
        }


        /// <summary>
        /// Returns the assoicated Enum from a String.
        /// </summary>
        /// <typeparam name="T">The Enum type to parse to</typeparam>
        /// <param name="value">The string you want to parse to EnumT</param>
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
            string hash;
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
            return GetFileHash(path, UserSettings.Load().Hash);
        }

        public static string GetFileHash(byte[] bytes)
        {
            HashService hashService = HashServiceFactory.Create(UserSettings.Load().Hash);
            return hashService.ToHex(hashService.ComputeHash(bytes));
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
