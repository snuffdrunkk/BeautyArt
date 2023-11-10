using BeautyArt.Add;
using BeautyArt.Service;
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
            compAdd.ShowDialog();
            db.CompositionsGridRead(curs, CompositionsGrid);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.CompositionsGridRead(curs, CompositionsGrid);

        }

        private void ExitCompositions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CompExcel_Click(object sender, RoutedEventArgs e)
        {
            outputService.ExportScheduleToExcel(CompositionsGrid, compositionPath, "Состав", false);
        }
    }
}
