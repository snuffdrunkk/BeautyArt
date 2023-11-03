using System.Windows;
using System.Windows.Controls;

namespace BeautyArt.Edit
{
    public partial class SchedulesEdit : Window
    {
        DataBase db;
        DataGrid dataGrid;
        int ID;
        public SchedulesEdit(DataGrid dataGrid, int id, string title, string type, string stud, string date, string time, string cab)
        {
            InitializeComponent();

            db = new DataBase();
            this.dataGrid = dataGrid;

            ID = id;
            ComboBoxType.Text = type;
            DatePickerDate.Text = date;
            TimePickerTime.Text = time;
            ComboBoxCabinet.Text = cab;

            ComboBoxTitle.Items.Add(title);
            ComboBoxTitle.SelectedIndex = 0;

            ComboBoxStudent.Items.Add(stud);
            ComboBoxStudent.SelectedIndex = 0;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            string formattedDateDateStart = DatePickerDate.SelectedDate.Value.ToString("yyyy-MM-dd");

            db.Update($"UPDATE Schedules SET Type = N'{ComboBoxType.Text}', Date = '{formattedDateDateStart}', Time = N'{TimePickerTime.Text}', Cabinet = N'{ComboBoxCabinet.Text}' WHERE IdSchedule = '{ID}'");
            db.ReadSchedule(dataGrid);
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

        private void ComboBoxStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
