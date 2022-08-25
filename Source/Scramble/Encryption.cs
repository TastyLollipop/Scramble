using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Scramble
{
    public class Encryption
    {
        public int encryptionMethod = 0;
        public int byteTrashPool = 256;

        //Encrypts the file or files
        public void EncryptFile(string path)
        {
            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressValue, 0);

            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeStatusLabel, "Encrypting");

            if (Scramble.utils.isFileTooBig)
            {
                string[] directoryFiles = Directory.GetFiles(path);

                Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressMax, directoryFiles.Length);

                for (int i = 0; i < directoryFiles.Length; i++)
                {
                    Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressValue, i + 1);

                    byte[] byteData;
                    byte[] rolledByteData;

                    switch (encryptionMethod)
                    {
                        case 0:
                            byteData = ManageTrashPool(0, File.ReadAllBytes(directoryFiles[i]));
                            File.WriteAllBytes(directoryFiles[i], byteData);
                            break;

                        case 1:
                            rolledByteData = ManageTrashRoller(File.ReadAllBytes(directoryFiles[i]));
                            File.WriteAllBytes(directoryFiles[i], rolledByteData);
                            break;

                        case 2:
                            rolledByteData = ManageTrashRoller(File.ReadAllBytes(directoryFiles[i]));
                            byteData = ManageTrashPool(0, rolledByteData);
                            File.WriteAllBytes(directoryFiles[i], byteData);
                            break;
                    }
                }

                Scramble.utils.MergeFiles();
            }

            else
            {
                Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressMax, 1);

                byte[] byteData;
                byte[] rolledByteData;

                switch (encryptionMethod)
                {
                    case 0:
                        byteData = ManageTrashPool(0, File.ReadAllBytes(path));
                        File.WriteAllBytes(path + Scramble.utils.encryptedExtension, byteData);
                        File.Delete(path);
                        break;

                    case 1:
                        rolledByteData = ManageTrashRoller(File.ReadAllBytes(path));
                        File.WriteAllBytes(path + Scramble.utils.encryptedExtension, rolledByteData);
                        File.Delete(path);
                        break;

                    case 2:
                        rolledByteData = ManageTrashRoller(File.ReadAllBytes(path));
                        byteData = ManageTrashPool(0, rolledByteData);
                        File.WriteAllBytes(path + Scramble.utils.encryptedExtension, byteData);
                        File.Delete(path);
                        break;
                }

                Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressValue, 1);
                Scramble.utils.FinalizeOperation();
            }
        }

        //Decrypts the file or files
        public void DecryptFile(string path)
        {
            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressValue, 0);

            Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeStatusLabel, "Decrypting");

            if (Scramble.utils.isFileTooBig)
            {
                string[] directoryFiles = Directory.GetFiles(path);

                Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressMax, directoryFiles.Length);

                for (int i = 0; i < directoryFiles.Length; i++)
                {
                    Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressValue, i + 1);

                    byte[] byteData;
                    byte[] rolledByteData;

                    switch (encryptionMethod)
                    {
                        case 0:
                            byteData = ManageTrashPool(1, File.ReadAllBytes(directoryFiles[i]));
                            File.WriteAllBytes(directoryFiles[i], byteData);
                            break;

                        case 1:
                            rolledByteData = ManageTrashRoller(File.ReadAllBytes(directoryFiles[i]));
                            File.WriteAllBytes(directoryFiles[i], rolledByteData);
                            break;

                        case 2:
                            byteData = ManageTrashPool(1, File.ReadAllBytes(directoryFiles[i]));
                            rolledByteData = ManageTrashRoller(byteData);
                            File.WriteAllBytes(directoryFiles[i], rolledByteData);
                            break;
                    }
                }

                Scramble.utils.MergeFiles();
            }

            else
            {
                Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressMax, 1);

                byte[] byteData;
                byte[] rolledByteData;
                string newPath;

                switch (encryptionMethod)
                {
                    case 0:
                        byteData = ManageTrashPool(1, File.ReadAllBytes(path));
                        newPath = path.Remove(path.Count() - 4, 4);
                        File.WriteAllBytes(newPath, byteData);
                        File.Delete(path);
                        break;

                    case 1:
                        rolledByteData = ManageTrashRoller(File.ReadAllBytes(path));
                        newPath = path.Remove(path.Count() - 4, 4);
                        File.WriteAllBytes(newPath, rolledByteData);
                        File.Delete(path);
                        break;

                    case 2:
                        byteData = ManageTrashPool(1, File.ReadAllBytes(path));
                        rolledByteData = ManageTrashRoller(byteData);
                        newPath = path.Remove(path.Count() - 4, 4);
                        File.WriteAllBytes(newPath, rolledByteData);
                        File.Delete(path);
                        break;
                }

                Scramble.uiLogic.InvokeFunctionOn(UILogic.InvokeMode.changeProgressValue, 1);
                Scramble.utils.FinalizeOperation();
            }
        }

        //Manages the "Trash Pool" encryption method
        private byte[] ManageTrashPool(int mode, byte[] data)
        {
            List<byte> byteList = data.ToList();

            if (mode == 0)
            {
                for (int index = 0; index < byteTrashPool; index++)
                {
                    Random random = new Random();
                    byteList.Insert(0, (byte)random.Next(0, 9));
                    byteList.Insert(byteList.Count, (byte)random.Next(0, 9));
                }

                return byteList.ToArray();
            }

            else
            {
                for (int index = 0; index < byteTrashPool; index++)
                {
                    byteList.RemoveAt(0);
                    byteList.RemoveAt(byteList.Count - 1);
                }

                return byteList.ToArray();
            }
        }

        //Manages the "Thrash Roller" encryption method
        private byte[] ManageTrashRoller(byte[] data)
        {
            List<byte> byteList = data.ToList();

            byteList.Reverse();

            return byteList.ToArray();
        }
    }
}
