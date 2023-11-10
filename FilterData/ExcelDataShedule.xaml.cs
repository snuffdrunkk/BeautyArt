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

namespace BeautyArt.FilterData
{
    /// <summary>
    /// Логика взаимодействия для ExcelDataShedule.xaml
    /// </summary>
    public partial class ExcelDataShedule : Window
    {
        public ExcelDataShedule()
        {
            InitializeComponent();
        }

        private void ExcelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
