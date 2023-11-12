﻿using System;
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
            db=new DataBase();
            this.dataGrid = dataGrid;
            db.ReadStudentsToComboBox(ComboBoxStud);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            //if (ValidateInput())
            //{
            

                db.Update($"Insert INTO Compositions (IdStudnet, IdCourse, Activity) VALUES ({(ComboBoxStud.SelectedValue as ComboBoxDTO).id}, {curs}, N'{ComboBoxEnable.Text}')");
            db.CompositionsGridRead(curs, dataGrid);
            //}

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
    }
}
