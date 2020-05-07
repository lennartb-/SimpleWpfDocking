using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.CommandWpf;
using SimpleWpfDocking.Annotations;

namespace SimpleWpfDocking.VM
{
    public class SidePanelVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<PaneItemVm> Items { get; set; } = new List<PaneItemVm>();

        public PaneItemVm ActivePane { get; set; }

        public RelayCommand<PaneItemVm> SetActiveContentCommand
        {
            get
            {
                return new RelayCommand<PaneItemVm>( item => ActivePane = item);
            }
        }
    }
}
