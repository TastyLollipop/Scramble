using System.Threading;

namespace Scramble
{
    public class Threading
    {
        //Generates threads for operations to work in
        public void GenerateThreads(int value)
        {
            switch(value)
            {
                case 0:
                    Thread fileManagementThread = new Thread(new ThreadStart(Scramble.utils.ManageFile));
                    fileManagementThread.IsBackground = true;
                    fileManagementThread.Name = "File Management Thread";
                    fileManagementThread.Start();
                    break;
            }
        }
    }
}
