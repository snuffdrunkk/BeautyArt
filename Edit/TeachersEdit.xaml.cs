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

namespace BeautyArt.Edit
{
    /// <summary>
    /// Логика взаимодействия для TeachersEdit.xaml
    /// </summary>
    public partial class TeachersEdit : Window
    {
        DataBase db;
        DataGrid dataGrid;
        int ID;
        public TeachersEdit(DataGrid dataGrid, int id, string name, string surname, string midname, string pos, string num)
        {
            InitializeComponent();
            db = new DataBase();
            this.dataGrid = dataGrid;

            ID = id;
            TextBoxNameTeach.Text = name;
            TextBoxSurnameTeach.Text = surname;
            TextBoxMiddlenameTeach.Text = midname;
            ComboBoxPosition.Text = pos;
            TextBoxNumberTeach.Text = num;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                db.Update($"Update Teachers set NameTeach = N'{TextBoxNameTeach.Text}', SurnameTeach =  N'{TextBoxSurnameTeach.Text}', MiddlenameTeach = N'{TextBoxMiddlenameTeach.Text}', Position = N'{ComboBoxPosition.Text}', NumberTeach = N'{TextBoxNumberTeach.Text}' Where IdTeacher = N'{ID}'");
            }
            db.ReadTeachers(dataGrid);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            string patternNum = @"^(\+375|80)(44|29|25|33)\d{7}$";
            string phoneNumber = TextBoxNumberTeach.Text.Trim();
            if (!Regex.IsMatch(phoneNumber, patternNum))
            {
                MessageBox.Show("Пожалуйста, введите корректный номер преподавателя (только 12 цифр).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
