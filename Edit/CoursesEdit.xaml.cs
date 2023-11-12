using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml.Linq;

namespace BeautyArt.Edit
{
    public partial class CoursesEdit : Window
    {
        DataBase db;
        DataGrid dataGrid;
        int ID;
        int count;

        public CoursesEdit(DataGrid dataGrid, int id, string title, string teacher, string date, int count)
        {
            InitializeComponent();

            db = new DataBase();

            ID = id;
            DatePickerDateStart.Text = date;

            this.dataGrid = dataGrid;
            this.count = count;

            TextBoxCount.Text = count.ToString();

            ComboBoxTitle.Items.Add(title);
            ComboBoxTitle.SelectedIndex = 0;

            ComboBoxTeach.Items.Add(teacher);
            ComboBoxTeach.SelectedIndex = 0;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                string formattedDateDateStart = DatePickerDateStart.SelectedDate.Value.ToString("yyyy-MM-dd");

                db.Update($"UPDATE Courses SET DateStart = '{formattedDateDateStart}' WHERE IdCourse = '{ID}'");

                db.ReadCourse(dataGrid);
            }
        }

        private bool ValidateInput()
        {
            try
            {
                DateTime date = DatePickerDateStart.SelectedDate.Value;

                if (date < DateTime.Now.AddDays(-1))
                {
                    MessageBox.Show("Пожалуйста, выберите верную дату.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Введите дату!");
                return false;
            }
            return true;
        }
    }
}
