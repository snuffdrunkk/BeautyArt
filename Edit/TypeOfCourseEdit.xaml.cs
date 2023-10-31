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
    /// <summary>
    /// Логика взаимодействия для TypeOfCourseEdit.xaml
    /// </summary>
    public partial class TypeOfCourseEdit : Window
    {
        DataBase db;
        DataGrid dataGrid;
        int ID;
        public TypeOfCourseEdit(DataGrid dataGrid, int id, string title, string min, string max, string cost, string dur)
        {
            InitializeComponent();
            db = new DataBase();
            this.dataGrid = dataGrid;

            ID = id;
            TextBoxTitleCourse.Text = title;
            ComboBoxMin.Text = min;
            ComboBoxMax.Text = max;
            TextBoxCost.Text = cost;
            TextBoxDuration.Text = dur;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput()) 
            {
                db.Update($"Update TypeOfCourse set TitleCourse = N'{TextBoxTitleCourse.Text}', MinMember =  N'{ComboBoxMin.Text}', MaxMember = N'{ComboBoxMax.Text}', CostCourse = N'{TextBoxCost.Text}', Duration = N'{TextBoxDuration.Text}' Where IdTypeOfCourse = N'{ID}'");
                db.ReadTypeOfCourse(dataGrid);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            // Проверка наименования курса
            string title = TextBoxTitleCourse.Text.Trim();
            if (string.IsNullOrEmpty(title) || title.Any(char.IsDigit))
            {
                MessageBox.Show("Пожалуйста, введите корректное наименование курса (без цифр).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка минимума учеников
            if (ComboBoxMin.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите минимальное количество учеников.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка максимума учеников
            if (ComboBoxMax.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите максимальное количество учеников.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка стоимости курса
            string cost = TextBoxCost.Text.Trim();
            if (string.IsNullOrEmpty(cost) || !decimal.TryParse(cost, out decimal costValue) || costValue <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректную стоимость курса (число больше нуля не больше 4 цифр и слово руб).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка продолжительности курса
            string duration = TextBoxDuration.Text.Trim();
            if (string.IsNullOrEmpty(duration) || duration.Length <= 0 || duration.Length > 3)
            {
                MessageBox.Show("Пожалуйста, введите корректную продолжительность курса (число больше нуля и не больше 3).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
