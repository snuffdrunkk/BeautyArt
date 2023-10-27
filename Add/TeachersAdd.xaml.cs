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
    /// <summary>
    /// Логика взаимодействия для TeachersAdd.xaml
    /// </summary>
    public partial class TeachersAdd : Window
    {
        DataBase db;
        DataGrid dataGrid;
        public TeachersAdd(DataGrid dataGrid)
        {
            InitializeComponent();
            db = new DataBase();
            this.dataGrid = dataGrid;
        }

        private void TeachersGridUpdate()//Обновление грида учителей
        {
            db.Select("select Teachers.IdTeacher, Teachers.NameTeach, Teachers.SurnameTeach, Teachers.MiddlenameTeach, Teachers.Position, Teachers.NumberTeach From Teachers", TeachersGrid);
            dataGrid.Columns[0].Visibility = Visibility.Hidden;
            dataGrid.Columns[1].Header = "Имя";
            dataGrid.Columns[1].Width = 100;
            dataGrid.Columns[2].Header = "Фамилия";
            dataGrid.Columns[2].Width = 100;
            dataGrid.Columns[3].Header = "Отчество";
            dataGrid.Columns[3].Width = 100;
            dataGrid.Columns[4].Header = "Должность";
            dataGrid.Columns[4].Width = 100;
            dataGrid.Columns[5].Header = "Номер телефона";
            dataGrid.Columns[5].Width = 100;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                db.Update($"Insert INTO Teachers (NameTeach, SurnameTeach, MiddlenameTeach, Position, NumberTeach) VALUES (N'{TextBoxNameTeach.Text}', N'{TextBoxSurnameTeach.Text}', N'{TextBoxMiddlenameTeach.Text}', N'{ComboBoxPosition.Text}', N'{TextBoxNumberTeach.Text}')");
            }
            TeachersGridUpdate();
        }

        private bool ValidateInput()
        {
            // Проверка имени преподавателя
            string name = TextBoxNameTeach.Text.Trim();
            if (string.IsNullOrEmpty(name) || !name.All(char.IsLetter))
            {
                MessageBox.Show("Пожалуйста, введите корректное имя преподавателя (только буквы).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка фамилии преподавателя
            string surname = TextBoxSurnameTeach.Text.Trim();
            if (string.IsNullOrEmpty(surname) || !surname.All(char.IsLetter))
            {
                MessageBox.Show("Пожалуйста, введите корректную фамилию преподавателя (только буквы).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка отчества преподавателя
            string middlename = TextBoxMiddlenameTeach.Text.Trim();
            if (string.IsNullOrEmpty(middlename) || !middlename.All(char.IsLetter))
            {
                MessageBox.Show("Пожалуйста, введите корректное отчество преподавателя (только буквы).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка выбранной должности преподавателя
            if (ComboBoxPosition.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите должность преподавателя.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка номера преподавателя
            string patternNum = @"^\+\d{12}$";
            string number = TextBoxNumberTeach.Text.Trim();
            MessageBox.Show($"number: {number}");
            if (string.IsNullOrEmpty(number) || Regex.IsMatch(number, patternNum))
            {
                MessageBox.Show("Пожалуйста, введите корректный номер преподавателя (только 12 цифр).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

    }
}
