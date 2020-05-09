using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using GalaSoft.MvvmLight.CommandWpf;
using SimpleWpfDocking.Annotations;

namespace SimpleWpfDocking.VM
{
    /// <summary>
    /// Viewmodel for a side pane.
    /// </summary>
    public class SidePanelVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<PaneItemVm> Items { get; set; } = new ObservableCollection<PaneItemVm>();

        public PaneItemVm ActivePane { get; set; }

        public string Name { get; set; }

        public PaneManager Manager { get; set; }


        public RelayCommand<PaneItemVm> SetActiveContentCommand
        {
            get
            {
                return new RelayCommand<PaneItemVm>(item => ActivePane = item);
            }
        }

        public RelayCommand<ContextMenuEventArgs> OnContextMenuOpening
        {
            get
            {
                return new RelayCommand<ContextMenuEventArgs>(args =>
                {
                    if (!(args.Source is Button button && button.DataContext is PaneItemVm paneVm)) return;

                    var entries = Manager.GetItemsForPane(paneVm, this);
                    button.ContextMenu?.Items.Clear();
                    foreach (var contextMenuEntryVm in entries)
                    {
                        var menuItem = new MenuItem { DataContext = contextMenuEntryVm, Header = contextMenuEntryVm.Text };
                        menuItem.Click += (sender, eventArgs) =>
                            contextMenuEntryVm.ClickAction(contextMenuEntryVm.ItemVm, contextMenuEntryVm.Target);
                        button.ContextMenu?.Items.Add(menuItem);
                    }
                });
            }
        }
    }
}
