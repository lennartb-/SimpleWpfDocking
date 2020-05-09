using System;

namespace SimpleWpfDocking.VM
{
    public class ContextMenuEntryVm
    {
        public PaneItemVm ItemVm { get; }
        public SidePanelVm Target { get; }
        public Action<PaneItemVm, SidePanelVm> ClickAction { get; }

        public string Text => $"Send to {Target.Name}";

        public ContextMenuEntryVm(PaneItemVm paneItemVm, SidePanelVm target, Action<PaneItemVm, SidePanelVm> clickAction)
        {
            ItemVm = paneItemVm;
            Target = target;
            ClickAction = clickAction;
        }
    }
}
