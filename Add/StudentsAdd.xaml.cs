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
    /// Логика взаимодействия для StudentsAdd.xaml
    /// </summary>
    public partial class StudentsAdd : Window
    {
        DataBase db;

        public StudentsAdd()
        {
            InitializeComponent();
            db = new DataBase();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                db.Update($"Insert INTO Students (NameStud, SurnameStud, MiddlenameStud, EmailStud, NumberStud, PassportData) VALUES (N'{TextBoxNameStud.Text}', N'{TextBoxSurnameStud.Text}', N'{TextBoxMiddlenameStud.Text}', N'{TextBoxEmail.Text}', N'{TextBoxNumberStud.Text}', N'{TextBoxPassport.Text}')");
            }
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
            string phoneNumber = TextBoxNumberStud.Text.Trim();
            if (string.IsNullOrEmpty(phoneNumber) || !phoneNumber.All(char.IsDigit) || phoneNumber.Length != 12)
            {
                MessageBox.Show("Пожалуйста, введите корректный номер телефона (только 12 цифр).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Проверка паспортных данных
            string passport = TextBoxPassport.Text.Trim();
            if (string.IsNullOrEmpty(passport) || !passport.All(char.IsDigit) || passport.Length != 7)
            {
                MessageBox.Show("Пожалуйста, введите корректные паспортные данные (только 7 цифр).", "Проверка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            return true;
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
