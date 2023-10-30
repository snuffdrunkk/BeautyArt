using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class TypeOfCourseAdd : Window
    {
        DataBase db;
        DataGrid dataGrid;
        public TypeOfCourseAdd(DataGrid dataGrid)
        {
            InitializeComponent();
            db = new DataBase();
            this.dataGrid = dataGrid;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            db.Update($"Insert INTO TypeOfCourse (TitleCourse, MinMember, MaxMember, CostCourse, Duration) VALUES (N'{TextBoxTitleCourse.Text}', N'{ComboBoxMin.Text}', N'{ComboBoxMax.Text}', N'{TextBoxCost.Text}', N'{TextBoxDuration.Text}')");
            db.ReadTypeOfCourse(dataGrid);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            // Проверка наименования курса
            string title = TextBoxTitleCourse.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Пожалуйста, введите наименование курса.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            string patternCost = @"^\d{4} руб$";
            string cost = TextBoxCost.Text.Trim();
            if (!decimal.TryParse(cost, out decimal costValue) || !Regex.IsMatch(TextBoxCost.Text.Trim(), patternCost))
            {
                MessageBox.Show("Пожалуйста, введите корректную стоимость курса (число больше нуля не больше 4 цифр и слово руб).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка продолжительности курса
            string patternDur = @"^\d{3} акч$";
            string duration = TextBoxDuration.Text.Trim();
            if (!int.TryParse(duration, out int durationValue) || !Regex.IsMatch(TextBoxDuration.Text.Trim(), patternDur))
            {
                MessageBox.Show("Пожалуйста, введите корректную продолжительность курса (число больше нуля не больше 3 цифр и слово акч).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
