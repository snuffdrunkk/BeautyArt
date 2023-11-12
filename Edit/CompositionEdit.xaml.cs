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

namespace BeautyArt.Edit
{
    public partial class CompositionEdit : Window
    {
        DataBase db;
        DataGrid dataGrid;
        public int curs;
        public int sostav;
        public int id_stud;
        public CompositionEdit(DataGrid dataGrid)
        {
            InitializeComponent();

            db=new DataBase();
            this.dataGrid = dataGrid;
            db.ReadStudentsToComboBox(ComboBoxStud);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
        

            db.Update($"UPDATE Compositions SET Activity = N'{ComboBoxEnable.Text}' ,Reason=N'{ComboBoxReason.Text}' WHERE IdCourseComposition = '{sostav}'");

            db.CompositionsGridRead(curs,dataGrid);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxEnable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxEnable.SelectedIndex == 1)
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
