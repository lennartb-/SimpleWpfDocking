using System;
using System.Collections.Generic;

namespace SimpleWpfDocking.VM
{
    public class ContextMenuEntryVm
    {
        public PaneItemVm ItemVm { get; }
        public IEnumerable<SidePanelVm> PossibleTargets { get; }
        public Action<PaneItemVm, SidePanelVm> ClickAction { get; }

        public ContextMenuEntryVm(PaneItemVm paneItemVm, IEnumerable<SidePanelVm> possibleTargets, Action<PaneItemVm, SidePanelVm> clickAction)
        {
            ItemVm = paneItemVm;
            PossibleTargets = possibleTargets;
            ClickAction = clickAction;
        }
    }
}
