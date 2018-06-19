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

        public VideoPreviewer(Actions a) : this (a, Constants.TempVideoFile)
        {
            //InitializeComponent();
            //filePath = Constants.TempVideoFile;
        }

        public VideoPreviewer(Actions a, string videoPath) : base(a, videoPath)
        {
            InitializeComponent();
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
                //File.Copy(Constants.TempVideoFile, Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(action), FileName + FileExtension));
                File.Copy(filePath, Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(action), FileName + FileExtension));
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

                if (UserSettings.Load().CopyArtefact) CopyVideo();

                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(filePath);

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CopyVideo()
        {
            string message = "";
            try
            {
                File.Copy(filePath, Path.Combine(UserSettings.Load().CopyImageLocation, FileName + FileExtension));
            }
            catch (IOException)
            {
                message = "Creating duplicate failed, but video successfully placed in case container. This may be because a file with name already exists in the copy location.";
            }
            catch (UnauthorizedAccessException)
            {
                message = "Creating duplicate failed, but video successfully placed in case container. This is due to not having permission to save to the copy location specified in the options menu.";
            }
            catch
            {
                message = "Creating duplicate failed, but video successfully placed in case container.";
            }

            if (message != "") MessageBox.Show(message, "Error in Creating Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
