using System.Windows;
using SimpleWpfDocking.VM;

namespace SimpleWpfDocking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var leftVm = BuildVm("Left");
            SidePaneL.DataContext = leftVm;
            var rightVm = BuildVm2("Right");
            SidePaneR.DataContext = rightVm;

            var bottomVm = BuildVm3("Bottom");
            SidePaneB.DataContext = bottomVm;

            var pm = new PaneManager(new []{leftVm, rightVm, bottomVm});

            leftVm.Manager = pm;
            rightVm.Manager = pm;
            bottomVm.Manager = pm;
        }

        private SidePanelVm BuildVm(string name)
        {
            var sideVm = new SidePanelVm {Name = name};
            var item1 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Rtb"] };
            var item2 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Tv"] };
            sideVm.Items.Add(item1);
            sideVm.Items.Add(item2);
            return sideVm;
        }

        private SidePanelVm BuildVm2(string name)
        {
            var sideVm = new SidePanelVm {Name = name};
            var item3 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Cv"] };
            var item4 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Draw"] };
            sideVm.Items.Add(item3);
            sideVm.Items.Add(item4);
            return sideVm;
        }

        private SidePanelVm BuildVm3(string name)
        {
            var sideVm = new SidePanelVm {Name = name};
            var item4 = new PaneItemVm() { ButtonText = "A", PaneContent = (FrameworkElement) Resources["Draw"] };
            return sideVm;
        }
    
    }
}
