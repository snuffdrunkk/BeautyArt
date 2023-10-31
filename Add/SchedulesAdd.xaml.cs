using System;
using System.Windows;
using System.Windows.Controls;

namespace BeautyArt.Add
{
    public partial class SchedulesAdd : Window
    {
        DataBase db;
        DataGrid dataGrid;
        public SchedulesAdd(DataGrid dataGrid)
        {
            InitializeComponent();
            db = new DataBase();
            this.dataGrid = dataGrid;
            db.ReadCoursesToComboBox(ComboBoxTitle);
            db.ReadTeachersToComboBox(ComboBoxTeach);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                ComboBoxDTO dtoTitle = (ComboBoxDTO)ComboBoxTitle.SelectedItem;
                ComboBoxDTO dtoTeacher = (ComboBoxDTO)ComboBoxTeach.SelectedItem;

                DateTime selectedDateDateStart = DatePickerDate.SelectedDate.Value;
                string formattedDateDateStart = selectedDateDateStart.ToString("yyyy-MM-dd");

                db.Update($"Insert INTO Schedules (IdCourse, IdTeacher, Type, Date, Time, Cabinet) VALUES ('{dtoTitle.id}', '{dtoTeacher.id}', N'{ComboBoxType.Text}', '{formattedDateDateStart}', N'{TimePickerTime.Text}', N'{ComboBoxCabinet.Text}')");
                db.ReadSchedule(dataGrid);
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
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Пожалуйста, выберите наименование занятия.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка фамилии учителя
            string teacherSurname = ComboBoxTeach.Text.Trim();
            if (string.IsNullOrEmpty(teacherSurname))
            {
                MessageBox.Show("Пожалуйста, выберите фамилию учителя.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка типа занятия
            if (ComboBoxType.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип занятия.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка времени
            if (TimePickerTime.SelectedTime == null)
            {
                MessageBox.Show("Пожалуйста, выберите время.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка кабинета
            if (ComboBoxCabinet.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите кабинет.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

    }
}
