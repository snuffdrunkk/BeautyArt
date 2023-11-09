using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BeautyArt.Add
{
    /// <summary>
    /// Логика взаимодействия для CompositionAdd.xaml
    /// </summary>
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
