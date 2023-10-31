using System.Windows;
using System.Windows.Controls;

namespace BeautyArt.Edit
{
    public partial class SchedulesEdit : Window
    {
        DataBase db;
        DataGrid dataGrid;
        int ID;
        public SchedulesEdit(DataGrid dataGrid, int id, string title, string teacher, string type, string date, string time, string cab)
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

            ComboBoxTeach.Items.Add(teacher);
            ComboBoxTeach.SelectedIndex = 0;

            ComboBoxType.Items.Add(type);
            ComboBoxType.SelectedIndex = 0;
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
    }
}
