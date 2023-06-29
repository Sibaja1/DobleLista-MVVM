using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DobleLista.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected void OnPropertyChanging([CallerMemberName] string propetyName = "")
        {
            PropertyChanging(this, new PropertyChangingEventArgs(propetyName));
        }

        protected void OnPropertyChanged([CallerMemberName] string propetyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propetyName));
            }
        }
    }
}

