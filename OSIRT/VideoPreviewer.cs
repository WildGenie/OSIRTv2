using OSIRT.Enums;
using OSIRT.Helpers;
using OSIRT.Loggers;
using OSIRT.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT
{
    public partial class VideoPreviewer : Previewer
    {

        private bool successful = false;

        public VideoPreviewer(Actions a) : base(a, Constants.TempVideoFile)
        {
            InitializeComponent();
            //filePath = Constants.TempVideoFile;
        }



        private void VideoPreviewer_Load(object sender, EventArgs e)
        {
            try
            {
                uiVideoMediaPlayer.URL = filePath; 
            }
            catch {  /*this thing seems to throw exceptions for fun.*/ }
        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {
            try
            {
                uiVideoMediaPlayer.Ctlcontrols.stop();
                File.Copy(Constants.TempVideoFile, Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(action), FileName + FileExtension));
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(Constants.TempVideoFile);
                successful = true;
            }
            catch(UnauthorizedAccessException uex)
            {
                MessageBox.Show("Unauthorized Access Exception: " + uex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save the video. Enter a different file name and try again", "Unable to save video", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (successful)
            {
                Logger.Log(new VideoLog(action, FileName + FileExtension, Hash, Note));
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
