using BeautyArt.Add;
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
        public CompositionShow(DataGrid dataGrid)
        {
            InitializeComponent();
        }

        private void CompositionsGridUpdate()//Обновление грида расписание
        {
            //db.Select("select Compositions.IdCourseComposition, Students.IdStudnet, Students.IdStudent, Teachers.IdTeacher, Schedules.Type, Schedules.Date, Schedules.Time, Schedules.Cabinet From Schedules, Courses, Teachers, Students Where Schedules.IdCourse = Courses.IdCourse And Schedules.IdStudent = Students.IdStudent And Schedules.IdTeacher = Teachers.IdTeacher", ScheduleGrid);
        }

        private void DeleteCompositions_Click(object sender, RoutedEventArgs e)//Удаление состава
        {
            try
            {
                var selectedRow = CompositionsGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    db.Update($"DELETE FROM Compositions Where IdCourseComposition = {selectedRow.Row.ItemArray[0]}");
                    CompositionsGridUpdate();
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
            CompositionsGridUpdate();
        }
    }
}
