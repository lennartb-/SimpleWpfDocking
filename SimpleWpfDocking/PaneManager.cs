using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            source.Items.Remove(item);
            target.Items.Add(item);
        }

        public IEnumerable<ContextMenuEntryVm> GetItemsForPane(SidePanelVm pane)
        {
            foreach (var paneItemVm in pane.Items)
            {
                yield return new ContextMenuEntryVm(paneItemVm, managedPanes.Except(new[] {pane}), SendToPane);
            }
        }
    }
}
