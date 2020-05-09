using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using SimpleWpfDocking.Annotations;

namespace SimpleWpfDocking.VM
{
    public class PaneItemVm : INotifyPropertyChanged
    {
        public string ButtonText { get; set; }
        public bool IsActive { get; set; }
        public FrameworkElement PaneContent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
