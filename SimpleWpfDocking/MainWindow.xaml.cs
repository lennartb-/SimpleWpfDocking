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

            SidePaneL.DataContext = BuildVm();
            SidePaneR.DataContext = BuildVm();
        }

        private SidePanelVm BuildVm()
        {
            var sideVm = new SidePanelVm();

            var item1 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Rtb"] };
            var item2 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Tv"] };
            var item3 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Cv"] };
            var item4 = new PaneItemVm() { ButtonText = "", PaneContent = (FrameworkElement) Resources["Draw"] };
            sideVm.Items.AddRange(new[] { item1, item2, item3, item4 });
            return sideVm;
        }
    }
}
