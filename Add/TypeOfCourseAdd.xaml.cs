using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            if (ValidateInput())
            {
                db.Update($"Insert INTO TypeOfCourse (TitleCourse, MinMember, MaxMember, CostCourse, Duration) VALUES (N'{TextBoxTitleCourse.Text}', N'{ComboBoxMin.Text}', N'{ComboBoxMax.Text}', N'{TextBoxCost.Text}', N'{TextBoxDuration.Text}')");
            }
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
