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
            var rightVm = BuildVm("Right");
            SidePaneR.DataContext = rightVm;

            var pm = new PaneManager(new []{leftVm, rightVm});

            leftVm.Manager = pm;
            rightVm.Manager = pm;
        }

        private SidePanelVm BuildVm(string name)
        {
            var sideVm = new SidePanelVm {Name = name};
            var item1 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Rtb"] };
            var item2 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Tv"] };
            var item3 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Cv"] };
            var item4 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Draw"] };
            sideVm.Items.AddRange(new[] { item1, item2, item3, item4 });
            return sideVm;
        }
    }
}
