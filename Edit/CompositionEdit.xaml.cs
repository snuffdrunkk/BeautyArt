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

            db = new DataBase();
            this.dataGrid = dataGrid;
            db.ReadStudentsToComboBox(ComboBoxStud);

/*            ComboBoxStud.Items.Add(title);
            ComboBoxStud.SelectedIndex = 0;

            ComboBoxEnable.Items.Add(teacher);
            ComboBoxStud.SelectedIndex = 0;*/
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            if (ValidateInput())
            {
                db.Update($"UPDATE Compositions SET Activity = N'{ComboBoxEnable.Text}' ,Reason=N'{ComboBoxReason.Text}' WHERE IdCourseComposition = '{sostav}'");
                db.CompositionsGridRead(curs, dataGrid);
                db.ReadCourse(dataGrid);
            }
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

        private bool ValidateInput()
        {

            // Проверка фамилии студента
            string studentSurname = ComboBoxStud.Text.Trim();
            if (string.IsNullOrEmpty(studentSurname))
            {
                MessageBox.Show("Пожалуйста, выберите фамилию студента.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка нахождения в курсе и причины (если ComboBoxEnable содержит "Нет")
            string enableStatus = ComboBoxEnable.Text.Trim();
            if (string.IsNullOrEmpty(enableStatus))
            {
                MessageBox.Show("Пожалуйста, выберите статус участия в курсе.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (enableStatus == "Нет")
            {
                string reason = ComboBoxReason.Text.Trim();
                if (string.IsNullOrEmpty(reason))
                {
                    MessageBox.Show("Пожалуйста, укажите причину отсутствия в курсе.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }

            return true;
        }
    }
}
