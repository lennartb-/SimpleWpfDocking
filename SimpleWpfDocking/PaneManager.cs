using System.Collections.Generic;
using System.Linq;
using SimpleWpfDocking.VM;

namespace SimpleWpfDocking
{
    public class PaneManager
    {
        private IEnumerable<SidePanelVm> managedPanes;

        public PaneManager(IEnumerable<SidePanelVm> panesToManage)
        {
            managedPanes = panesToManage;
        }

        public void SendToPane(PaneItemVm item, SidePanelVm target)
        {
            var source = managedPanes.Single(p => p.Items.Contains(item));
            source.SetActiveContentCommand.Execute(null);
            source.Items.Remove(item);
            target.Items.Add(item);
            target.SetActiveContentCommand.Execute(item);
        }

        public IEnumerable<ContextMenuEntryVm> GetItemsForPane(PaneItemVm selectedItem, SidePanelVm pane)
        {
            foreach (var managedPane in managedPanes.Except(new[] {pane}))
            {
                yield return new ContextMenuEntryVm(selectedItem, managedPane, SendToPane);
            }
        }
    }
}
