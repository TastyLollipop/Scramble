using System;
using System.Globalization;
using System.Windows.Forms;

namespace Scramble
{
    public partial class Scramble : Form
    {
        public static Utils utils = new Utils();
        public static UILogic uiLogic = new UILogic();
        public static Threading threading = new Threading();
        public static Encryption encryption = new Encryption();
        public static MessageBoxData messageBoxData = new MessageBoxData();

        public static Button _browseButton;
        public static Button _encryptButton;
        public static ProgressBar _progressBar;
        public static Label _statusLabel;
        public static TextBox _pathBox;
        public static ComboBox _encryptModeBox;

        private string aboutURL = "https://github.com/TastyLollipop/Scramble";
        private string versionName = "v1.0.0";

        public Scramble()
        {
            InitializeComponent();
            SetupAppDetails();
            SetupVariables();
            PopulateComboBox();
        }

        //Setup the details that need to be configured before the app starts working
        private void SetupAppDetails()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US", false);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US", false);

            utils.CheckForPreviousTempData();

            Text = "Scramble " + versionName;
        }

        //Setup UI elements to be accessed from anywhere
        private void SetupVariables()
        {
            _browseButton = browseButton;
            _encryptButton = encryptButton;
            _progressBar = progressBar;
            _statusLabel = statusLabel;
            _pathBox = pathBox;
            _encryptModeBox = encryptModeBox;
        }

        //Populate the encryption mode combobox
        private void PopulateComboBox()
        {
            encryptModeBox.Items.Add("Low");
            encryptModeBox.Items.Add("Medium");
            encryptModeBox.Items.Add("Hard");

            encryptModeBox.SelectedIndex = 1;
        }

        //Handles the "Browse" button click
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) { pathBox.Text = openFileDialog.FileName; }
            else return;
        }

        //Handles the "Encrypt" button click
        private void EncryptButton_Click(object sender, EventArgs e)
        {
            if (!utils.CheckForParameters()) return;

            uiLogic.InvokeFunctionOn(UILogic.InvokeMode.toggleButtons, null);

            encryption.encryptionMethod = encryptModeBox.SelectedIndex;

            threading.GenerateThreads(0);
        }

        //Opens the "About" URL
        private void AboutButton_Click(object sender, EventArgs e) { System.Diagnostics.Process.Start(aboutURL); }
    }
}
