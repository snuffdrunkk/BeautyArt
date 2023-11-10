using System.Windows;
using System.Windows.Controls;

namespace BeautyArt.Add
{
    public partial class CompositionAdd : Window
    {
        DataBase db;
        DataGrid dataGrid;
        public CompositionAdd(DataGrid dataGrid)
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxEnable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxEnable.SelectedIndex == 0)
            {
                ComboBoxReason.IsEnabled = true;
            }
            else
            {
                ComboBoxReason.IsEnabled = false;
                ComboBoxReason.SelectedIndex = -1;
            }
        }
    }
}
