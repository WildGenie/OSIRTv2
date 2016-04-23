using OSIRT.Helpers;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using OSIRT.Loggers;

namespace OSIRT.UI
{
    public partial class VideoPreviewerOld : Form
    {
        private BackgroundWorker hashCalcBackgroundWorker;
        public string Hash { get; private set; }

        public VideoPreviewerOld(string dateAndTime)
        {
            InitializeComponent();
            uiDateAndTimeTextBox.Text = dateAndTime;
            InitialiseBackgroundWorker();
            hashCalcBackgroundWorker.RunWorkerAsync();
        }

       
        private void VideoPreviewer_Load(object sender, EventArgs e)
        {
            InitialiseVideoPlayer();
            PopulateComboboxWithFiles();
        }

        private void InitialiseVideoPlayer()
        {
            try
            {
                uiVideoMediaPlayer.URL = Constants.TempVideoFile;
            }
            catch
            {
                //this thing seems to throw exceptions for fun.
            }
        }

        private void PopulateComboboxWithFiles()
        {
            string path = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Enums.Actions.Video));
            string[] files = Directory.GetFiles(path).Select(Path.GetFileNameWithoutExtension).ToArray();
            uiVideoNameComboBox.Items.AddRange(files);
        }

        private void InitialiseBackgroundWorker()
        {
            hashCalcBackgroundWorker = new BackgroundWorker();
            hashCalcBackgroundWorker.DoWork += HashCalcBackgroundWorker_DoWork;
            hashCalcBackgroundWorker.RunWorkerCompleted += HashCalcBackgroundWorker_RunWorkerCompleted;
        }

        private void HashCalcBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Hash = e.Result.ToString();
            uiHashTextBox.Text = Hash;
            uiHashCalcProgressBar.Visible = false;
            uiCalculatingHashLabel.Text = $"{UserSettings.Load().Hash.ToUpperInvariant()} Hash";
        }

        private void HashCalcBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Task.Delay(1000).Wait(); //just so user can "see" the image hashing
            e.Result = OsirtHelper.GetFileHash(Constants.TempVideoFile);
        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {
            try
            {

                File.Copy(Constants.TempVideoFile, Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Enums.Actions.Video), uiVideoNameComboBox.Text + ".mp4"));
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(Constants.TempVideoFile);

                //TODO: A lot of similarities between Image and Video Previewer. DRY!
                Logger.Log(new VideoLog(Enums.Actions.Video, uiVideoNameComboBox.Text + ".mp4" ,uiHashTextBox.Text, "Test note"));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can't move video. Reason: " + ex.InnerException);
            }


        }
    }
}
