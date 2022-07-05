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
        public bool OnOption(string option, string optionTitle)
        {
            if (MessageBox.Show(option, optionTitle, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                return true;
            else return false;
        }
    }
}
