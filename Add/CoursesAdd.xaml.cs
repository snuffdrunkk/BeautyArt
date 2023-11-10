using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
namespace BeautyArt.Add
{
    public partial class CoursesAdd : Window
    {
        DataBase db;
        DataGrid dataGrid;
        public CoursesAdd(DataGrid dataGrid)
        {
            InitializeComponent();
            db = new DataBase();
            this.dataGrid = dataGrid;
            db.ReadTypeOfCourseToComboBox(ComboBoxTitle);
            db.ReadTeachersToComboBox(ComboBoxTeach);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            if (ValidateInput())
            {
                DateTime selectedDateDateStart = DatePickerDateStart.SelectedDate.Value;
                string formattedDateDateStart = selectedDateDateStart.ToString("yyyy-MM-dd");

                ComboBoxDTO dtoTitle = (ComboBoxDTO)ComboBoxTitle.SelectedItem;
                ComboBoxDTO dtoTeacher = (ComboBoxDTO)ComboBoxTeach.SelectedItem;

                db.Update($"Insert INTO Courses (IdTypeOfCourse, IdTeacher, DateStart, CountStud) VALUES ('{dtoTitle.id}', '{dtoTeacher.id}', '{formattedDateDateStart}', N'{TextBoxCount.Text}')");
                db.ReadCourse(dataGrid);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            // Проверка наименования
            string title = ComboBoxTitle.Text.Trim();
            if (string.IsNullOrEmpty(title) || !Regex.IsMatch(title, @"^([A-Za-zА-Яа-я]| )+$"))
            {
                MessageBox.Show("Пожалуйста, выберите наименование курса.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка фамилии учителя
            string teacherSurname = ComboBoxTeach.Text.Trim();
            if (string.IsNullOrEmpty(teacherSurname) || !Regex.IsMatch(teacherSurname, @"^[A-Za-zА-Яа-я]+$"))
            {
                MessageBox.Show("Пожалуйста, выберите учителя.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            
            try
            {
                DateTime date = DatePickerDateStart.SelectedDate.Value;

                if (date < date.AddDays(-1))
                {
                    MessageBox.Show("Пожалуйста, выберите верную дату.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            } catch (InvalidOperationException)
            {
                MessageBox.Show("Введите дату!");
                return false;
            }
           

            return true;
        }
    }
}
