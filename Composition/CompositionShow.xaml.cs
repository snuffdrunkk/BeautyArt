using BeautyArt.Add;
using BeautyArt.Edit;
using BeautyArt.Service;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace BeautyArt.Composition
{
    public partial class CompositionShow : Window
    {
        DataBase db;
        DataGrid dataGrid;

        OutputService outputService;

        private string compositionPath = "D:\\Практика\\Prog\\BeautyArt\\Resources\\CompExcel.xlsx";
        private string compSertPath = "D:\\Практика\\Prog\\BeautyArt\\Resources\\CompSertExcel.xlsx";

        public int curs;
        public CompositionShow(DataGrid dataGrid)
        {
            InitializeComponent(); 
            
            db = new DataBase();
            outputService = new OutputService();
        }
        private void DeleteCompositions_Click(object sender, RoutedEventArgs e)//Удаление состава
        {
            try
            {
                var selectedRow = CompositionsGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    db.Update($"DELETE FROM Compositions Where IdCourseComposition = {selectedRow.Row.ItemArray[0]}");
                    db.CompositionsGridRead(curs, CompositionsGrid);
                    db.ReadCourse(dataGrid);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Данные из строки используются в другой таблице! Удалите данные из другой таблицы.", "Ошибка при удалении");
            }
        }

        private void AddCompositions_Click(object sender, RoutedEventArgs e)
        {
            CompositionAdd compAdd = new CompositionAdd(CompositionsGrid);
            compAdd.curs=this.curs; 
          
            compAdd.ShowDialog();
            db.CompositionsGridRead(curs, CompositionsGrid);
            db.ReadCourse(dataGrid);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.CompositionsGridRead(curs, CompositionsGrid);
            db.ReadCourse(dataGrid);
        }

        private void ExitCompositions_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            db.ReadCourse(dataGrid);
        }

        private void CompExcel_Click(object sender, RoutedEventArgs e)
        {
            outputService.ExportScheduleToExcel(CompositionsGrid, compositionPath, "Состав", false);
        }

        private void EditCompositions_Click(object sender, RoutedEventArgs e)
        {
            CompositionEdit compEdit = new CompositionEdit(CompositionsGrid);
            compEdit.sostav = Convert.ToInt32((CompositionsGrid.SelectedItem as DataRowView).Row.ItemArray[0].ToString()); ;
            compEdit.id_stud=Convert.ToInt32((CompositionsGrid.SelectedItem as DataRowView).Row.ItemArray[5].ToString());
            compEdit.curs = curs;
            compEdit.ShowDialog();
            db.CompositionsGridRead(curs, CompositionsGrid);
            db.ReadCourse(dataGrid);
        }

        private void CompSertExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedRow = CompositionsGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    outputService.ExportToExcel(CompositionsGrid, compSertPath, "Сертификат", true, selectedRow);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Выберите строку.", "Ошибка при печати");
            }
        }
    }
}
