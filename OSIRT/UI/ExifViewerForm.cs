using ExifLib;
using OSIRT.Helpers;
using OSIRT.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class ExifViewer : Form
    {

        private List<string> properties;
        private string path;
        private string url;
        private string googleMapUrl;

        public ExifViewer(string path, string url)
        {
            InitializeComponent();
            uiExifDatGridView.RowPrePaint += UiExifDatGridView_RowPrePaint;
            this.path = path;
            this.url = url;
        }

        private static string RenderTag(object tagValue)
        {
            // Arrays don't render well without assistance.
            var array = tagValue as Array;
            if (array != null)
            {
                // Hex rendering for really big byte arrays (ugly otherwise)
                if (array.Length > 20 && array.GetType().GetElementType() == typeof(byte))
                    return "0x" + string.Join("", array.Cast<byte>().Select(x => x.ToString("X2")).ToArray());

                return string.Join(", ", array.Cast<object>().Select(x => x.ToString()).ToArray());
            }
            return tagValue.ToString();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (ExifReader reader = new ExifReader(path))
                {
                    properties = Enum.GetValues(typeof(ExifTags)).Cast<ushort>().Select(tagID =>
                    {
                        object val;
                        if (reader.GetTagValue(tagID, out val))
                        {
                        // Special case - some doubles are encoded as TIFF rationals. These
                        // items can be retrieved as 2 element arrays of {numerator, denominator}
                        if (val is double)
                            {
                                int[] rational;
                                if (reader.GetTagValue(tagID, out rational))
                                    val = string.Format("{0} ({1}/{2})", val, rational[0], rational[1]);
                            }

                            return string.Format("{0}: {1}", Enum.GetName(typeof(ExifTags), tagID), RenderTag(val));
                        }

                        return null;

                    }).Where(x => x != null).ToList();

                    PopulateGrid();
                    DisplayThumbnail(reader);
                }
            }
            catch (ExifLibException ex)
            {
                MessageBox.Show("Unable to load Exif data.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }

        private void PopulateGrid()
        {
            string longitude = "";
            string latitude = "";
            foreach (string property in properties)
            {
                string[] split = property.Split(':');
                uiExifDatGridView.Rows.Add(split[0], split[1]);

                if(split[0].ToLower() == "gpslatitude")
                {
                    latitude = split[1];
                }
                if (split[0].ToLower() == "gpslongitude")
                {
                    longitude = split[1];
                }

            }
            //googleMapUrl = $@"http://maps.google.com/maps?q={latitude},{longitude}";
            //Console.WriteLine(googleMapUrl);
        }

        private void DisplayThumbnail(ExifReader reader)
        {
            var thumbnailBytes = reader.GetJpegThumbnailBytes();
            uiThumbnailPictureBox.Image = null;
            if (thumbnailBytes != null)
            {
                using (var stream = new MemoryStream(thumbnailBytes))
                {
                    uiThumbnailPictureBox.Image = Image.FromStream(stream);
                }
            }
        }

        private void uiSaveAsTextButton_Click(object sender, EventArgs e)
        {

            string savePath = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Enums.Actions.Exif), $"exif_data_{DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss")}.txt");
            string text = string.Join("\r\n", properties);
            File.WriteAllText(savePath, text);
            Logger.Log(new WebpageActionsLog(url, Enums.Actions.Exif, OsirtHelper.GetFileHash(savePath), Path.GetFileName(savePath), "[Exif Saved]"));
            MessageBox.Show("Exif data saved.", "Exif saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void UiExifDatGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All);

            e.PaintHeader(DataGridViewPaintParts.Background
                | DataGridViewPaintParts.Border
                | DataGridViewPaintParts.Focus
                | DataGridViewPaintParts.SelectionBackground
                | DataGridViewPaintParts.ContentForeground);

            e.Handled = true;
        }

        

        private void ExifViewer_Load(object sender, EventArgs e)
        {
            FormClosing += ExifViewer_FormClosing;
        }

        private void ExifViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ImageDiskCache.RemoveItemsInCache();
        }

        private void uiGoogleMapsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                   
        }

        private void uiGoogleMapsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
