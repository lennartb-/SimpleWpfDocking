using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
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

        public string Name { get; set; }

        public PaneManager Manager { get; set; }


        public RelayCommand<PaneItemVm> SetActiveContentCommand
        {
            get
            {
                return new RelayCommand<PaneItemVm>( item => ActivePane = item);
            }
        }

        public RelayCommand<ContextMenuEventArgs > OnContextMenuOpening
        {
            get
            {
                return new RelayCommand<ContextMenuEventArgs>(args =>
                {
                    var ctx = args.Source as ContextMenu;
                    Manager.GetItemsForPane()
                    ctx.Items
                });
            }
        }
    }
}
