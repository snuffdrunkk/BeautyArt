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
    /// Логика взаимодействия для StudentsEdit.xaml
    /// </summary>
    public partial class StudentsEdit : Window
    {
        DataBase db;
        DataGrid dataGrid;

        int ID;
        public StudentsEdit(DataGrid dataGrid, int id, string name, string surname, string midname, string email, string num, string pas)
        {
            InitializeComponent();
            db = new DataBase();
            this.dataGrid = dataGrid;

            ID = id;
            TextBoxNameStud.Text = name;
            TextBoxSurnameStud.Text = surname;
            TextBoxMiddlenameStud.Text = midname;
            TextBoxEmail.Text = email;
            TextBoxNumberStud.Text = num;
            TextBoxPassport.Text = pas;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                db.Update($"Update Students set NameStud = N'{TextBoxNameStud.Text}', SurnameStud =  N'{TextBoxMiddlenameStud.Text}', MiddlenameStud = N'{TextBoxSurnameStud.Text}', EmailStud = N'{TextBoxEmail.Text}', NumberStud = N'{TextBoxNumberStud.Text}', PassportData = N'{TextBoxPassport.Text}' Where IdStudent = N'{ID}'");
            }
            db.ReadStudent(dataGrid);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            // Проверка имени студента
            string name = TextBoxNameStud.Text.Trim();
            if (string.IsNullOrEmpty(name) || !name.All(char.IsLetter))
            {
                MessageBox.Show("Пожалуйста, введите корректное имя студента (только буквы).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка фамилии студента
            string surname = TextBoxSurnameStud.Text.Trim();
            if (string.IsNullOrEmpty(surname) || !surname.All(char.IsLetter))
            {
                MessageBox.Show("Пожалуйста, введите корректную фамилию студента (только буквы).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка отчества студента
            string middlename = TextBoxMiddlenameStud.Text.Trim();
            if (string.IsNullOrEmpty(middlename) || !middlename.All(char.IsLetter))
            {
                MessageBox.Show("Пожалуйста, введите корректное отчество студента (только буквы).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка email адреса
            string email = TextBoxEmail.Text.Trim();
            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"))
            {
                MessageBox.Show("Пожалуйста, введите корректный email адрес.", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка номера телефона
            string patternNum = @"^(\+375|80)(44|29|25|33)\d{7}$";
            string phoneNumber = TextBoxNumberStud.Text.Trim();
            if ( !Regex.IsMatch(phoneNumber, patternNum))
            {
                MessageBox.Show("Пожалуйста, введите корректный номер телефона (только 12 цифр).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка паспортных данных
            string patternPass = @"^HB\d{7}$";
            string passport = TextBoxPassport.Text.Trim();
            if (!Regex.IsMatch(passport, patternPass))
            {
                MessageBox.Show("Пожалуйста, введите корректные паспортные данные (только 7 цифр).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
