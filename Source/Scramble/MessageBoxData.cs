using System.Windows.Forms;

namespace Scramble
{
    public class MessageBoxData
    {
        //Store info of message boxes that might trigger

        public object[][] messageData = new object[][]
        {
            new object[]
            {
                "Error!",
                "The provided path is invalid! Change it and try again",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            },

            new object[]
            {
                "Success!",
                "Operation Complete!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            },
        };
    }
}
