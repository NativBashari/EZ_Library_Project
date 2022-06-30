using Services;
using System.Windows;

namespace EZ_Library
{
    public class Notifier : INotifier
    {
        public void OnError(string error)
        {
            MessageBox.Show(error);
        }

        public void OnInfo(string info)
        {
            MessageBox.Show(info);
        }

        public void OnSucces(string succes)
        {
            MessageBox.Show(succes);
        }

        public void OnWarning(string warning)
        {
            MessageBox.Show(warning);
        }
    }
}
