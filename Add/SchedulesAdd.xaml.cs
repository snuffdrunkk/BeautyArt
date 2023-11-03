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
            db.ReadStudentsToComboBox(ComboBoxStudent);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                ComboBoxDTO dtoTitle = (ComboBoxDTO)ComboBoxTitle.SelectedItem;
                ComboBoxDTO dtoStud = (ComboBoxDTO)ComboBoxStudent.SelectedItem;
                string stud = dtoStud != null ? dtoStud.id.ToString() : "null";

                DateTime selectedDateDateStart = DatePickerDate.SelectedDate.Value;
                string formattedDateDateStart = selectedDateDateStart.ToString("yyyy-MM-dd");

                db.Update($"Insert INTO Schedules (IdCourse, Type, IdStudent, Date, Time, Cabinet) VALUES ('{dtoTitle.id}', N'{ComboBoxType.Text}', {stud}, '{formattedDateDateStart}', N'{TimePickerTime.Text}', N'{ComboBoxCabinet.Text}')");
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

        private void ComboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxType.SelectedIndex == 0)
            {
                ComboBoxStudent.IsEnabled = true;
            }
            else 
            { 
                ComboBoxStudent.IsEnabled = false;
                ComboBoxStudent.SelectedIndex = -1;

            }
        }
    }
}
