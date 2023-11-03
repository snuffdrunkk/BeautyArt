using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace BeautyArt.Add
{
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
            db.ReadTeachers(dataGrid);
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
