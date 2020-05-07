using System.Windows;
using System.Windows.Controls;

namespace SimpleWpfDocking
{
    /// <summary>
    /// Interaction logic for SidePanel.xaml
    /// </summary>
    public partial class SidePanel
    {
        public SidePanel()
        {
            InitializeComponent();
        }

        public Dock Side
        {
            get { return (Dock) GetValue(SideProperty); }
            set { SetValue(SideProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Side.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SideProperty =
            DependencyProperty.Register("Side", typeof(Dock), typeof(SidePanel), new PropertyMetadata(default));

    }
}
