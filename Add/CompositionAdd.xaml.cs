using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace BeautyArt.Add
{
    public partial class CompositionAdd : Window
    {
        DataBase db;
        DataGrid dataGrid;
        public int curs;
        public CompositionAdd(DataGrid dataGrid)
        {
            InitializeComponent();
            db = new DataBase();
            this.dataGrid = dataGrid;
            db.ReadStudentsToComboBox(ComboBoxStud);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            if (ValidateInput())
            {
                db.Update($"Insert INTO Compositions (IdStudnet, IdCourse, Activity) VALUES ({(ComboBoxStud.SelectedValue as ComboBoxDTO).id}, {curs}, N'{ComboBoxEnable.Text}')");
                db.CompositionsGridRead(curs, dataGrid);
                db.ReadCourse(dataGrid);
            }

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
