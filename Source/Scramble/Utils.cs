using System;
using System.IO;
using System.Linq;

namespace Scramble
{
    public class Utils
    {
        public string tempPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Temp";
        private string filePath;
        private string tempFolderPath;

        public string encryptedExtension = ".ecd";

        private long fileSizeInBytes;
        private int chunkSize = 64 * 1000000;
        private int fileChunks;

        public bool isFileTooBig;
        public bool isFileEncrypted;

        //Manages what is to do with the file
        public void ManageFile()
        {
            if (IsFileTooBig()) SplitFile();

            if (!IsFileEncrypted()) Scramble.encryption.EncryptFile(isFileTooBig ? tempFolderPath : filePath);
            else Scramble.encryption.DecryptFile(isFileTooBig ? tempFolderPath : filePath);
        }

        //Checks if the file is too big
        private bool IsFileTooBig()
        {
            filePath = Scramble._pathBox.Text;
            FileInfo fileInfo = new FileInfo(filePath);
            fileSizeInBytes = fileInfo.Length;

            if (fileSizeInBytes > chunkSize)
            {
                isFileTooBig = true;
                return true;
            }
            else
            {
                isFileTooBig = false;
                return false;
            }
        }

        //Checks if the file is encrypted
        private bool IsFileEncrypted()
        {
            filePath = Scramble._pathBox.Text;
            FileInfo fileInfo = new FileInfo(filePath);

            if (Path.GetExtension(fileInfo.Name) == encryptedExtension)
            {
                isFileEncrypted = true;
                return true;
            }
            else
            {
                isFileEncrypted = false;
                return false;
            }
        }

        //Splits the file into multiple smaller ones to handle them correctly
        private void SplitFile()
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            if (IsFileEncrypted()) tempFolderPath = tempPath + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(fileName);
            else tempFolderPath = tempPath + Path.DirectorySeparatorChar + fileName;

            string baseFileName = Path.GetFileNameWithoutExtension(filePath);
            string Extension = Path.GetExtension(filePath);
            if (isFileEncrypted && Scramble.encryption.encryptionMethod != 1) fileChunks = (int)Math.Ceiling((decimal)fileSizeInBytes / (chunkSize +  Scramble.encryption.byteTrashPool * 2));
            else fileChunks = (int)Math.Ceiling((decimal)fileSizeInBytes / chunkSize);

            if (!Directory.Exists(tempFolderPath)) Directory.CreateDirectory(tempFolderPath);

            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeStatusLabel, "Splitting");
            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressMax, fileChunks);

            FileStream readFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            for (int i = 0; i < fileChunks; i++)
            {
                int bytesRead = 0;

                FileStream outputFileStream = new FileStream(tempFolderPath + Path.DirectorySeparatorChar + baseFileName + "." +
                        i.ToString().PadLeft(5, Convert.ToChar("0")) + Extension + ".tmp", FileMode.Create, FileAccess.Write);

                using (outputFileStream)
                {
                    byte[] buffer;
                    if (isFileEncrypted && Scramble.encryption.encryptionMethod != 1) buffer = new byte[chunkSize + Scramble.encryption.byteTrashPool * 2];
                    else buffer = new byte[chunkSize];

                    if ((bytesRead = readFileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        outputFileStream.Write(buffer, 0, bytesRead);
                    }
                }
                outputFileStream.Close();

                Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressValue, (i + 1));
            }

            readFileStream.Close();
        }

        //Merges the files back together into one
        public void MergeFiles()
        {
            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressValue, 0);

            int endFileSize = 0;
            string[] directoryFiles = Directory.GetFiles(tempFolderPath);

            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeStatusLabel, "Merging");
            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressMax, directoryFiles.Length);

            string fileCreationPath = "";
            if (!isFileEncrypted) fileCreationPath = filePath + encryptedExtension;
            else fileCreationPath = filePath.Remove(filePath.Count() - 4, 4);

            FileStream writeFileStream = new FileStream(fileCreationPath, FileMode.Create, FileAccess.Write);
            using (writeFileStream)
            {
                for (int i = 0; i < directoryFiles.Length; i++)
                {
                    byte[] byteData = File.ReadAllBytes(directoryFiles[i]);
                    writeFileStream.Write(byteData, 0, byteData.Count());
                    endFileSize += byteData.Count();

                    Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressValue, i + 1);
                }
            }
            writeFileStream.Close();

            string previousFilePath = "";
            if (!isFileEncrypted) previousFilePath = filePath;
            else previousFilePath = filePath;

            File.Delete(previousFilePath);
            Directory.Delete(tempFolderPath, true);

            FinalizeOperation();
        }

        //Triggers whenever everything is done
        public void FinalizeOperation()
        {
            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.showMessageBox, 1);
            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeStatusLabel, "Idle");
            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressValue, 0);
            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressMax, 0);
            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.toggleButtons, null);
        }

        //Checks for previous temp data and deletes it
        public void CheckForPreviousTempData()
        {
            if (Directory.Exists(tempPath))
            {
                string[] tempData = Directory.GetDirectories(tempPath);

                for (int i = 0; i < tempData.Length; i++) Directory.Delete(tempData[i], true);
            }
        }

        //Checks that every needed parameters is valid
        public bool CheckForParameters()
        {
            bool isWrong = false;

            if (string.IsNullOrWhiteSpace(Scramble._pathBox.Text)) isWrong = true;
            if (!File.Exists(Scramble._pathBox.Text)) isWrong = true;

            if (isWrong)
            {
                Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.showMessageBox, 0);
                return false;
            }
            else return true;
        }
    }
}
