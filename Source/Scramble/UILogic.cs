using System;
using System.Windows.Forms;

namespace Scramble
{
    public class UILogic
    {
        public enum InvokeMode { changeStatusLabel, changeProgressValue, changeProgressMax, toggleButtons, showMessageBox }

        //Allows actions to be called from other threads
        public void InvokeFunctionOn(InvokeMode mode, Object value)
        {
            Action safeInvoke = null;

            switch (mode)
            {
                case InvokeMode.changeStatusLabel:
                    safeInvoke = delegate { ChangeStatusLabel((string)value); };
                    Scramble._statusLabel.Invoke(safeInvoke);
                    break;

                case InvokeMode.changeProgressValue:
                    safeInvoke = delegate { ChangeProgressBarFill((int)value); };
                    Scramble._progressBar.Invoke(safeInvoke);
                    break;

                case InvokeMode.changeProgressMax:
                    safeInvoke = delegate { ChangeProgressBarMax((int)value); };
                    Scramble._progressBar.Invoke(safeInvoke);
                    break;

                case InvokeMode.toggleButtons:
                    safeInvoke = delegate { ToggleUI(); };
                    Scramble._browseButton.Invoke(safeInvoke);
                    break;

                case InvokeMode.showMessageBox:
                    safeInvoke = delegate { ShowMessageBox((int)value); };
                    Scramble._progressBar.Invoke(safeInvoke);
                    break;
            }
        }

        //Changes the status label text
        private void ChangeStatusLabel(string value) { Scramble._statusLabel.Text = value; }

        //Changes the progress bar fill value
        private void ChangeProgressBarFill(int value) { Scramble._progressBar.Value = value; }

        //Changes the progress bar max value
        private void ChangeProgressBarMax(int value) { Scramble._progressBar.Maximum = value; }

        //Displays a message box to the user
        private void ShowMessageBox(int value)
        {
            object[] fetchedData = Scramble.messageBoxData.messageData[value];

            MessageBox.Show(
                (string)fetchedData[1], (string)fetchedData[0],
                (MessageBoxButtons)fetchedData[2],
                (MessageBoxIcon)fetchedData[3]
            );
        }

        //Toggles specified UI elements
        private void ToggleUI()
        {
            Scramble._browseButton.Enabled = !Scramble._browseButton.Enabled;
            Scramble._encryptButton.Enabled = !Scramble._encryptButton.Enabled;
            Scramble._pathBox.Enabled = !Scramble._pathBox.Enabled;
            Scramble._encryptModeBox.Enabled = !Scramble._encryptModeBox.Enabled;
        }
    }
}
