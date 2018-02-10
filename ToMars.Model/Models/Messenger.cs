using System.Windows.Forms;

namespace ToMars.Model.Models
{
    public interface IMessenger
    {
        void ShowMessage(string message);
    }
    public class Messenger : IMessenger
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
