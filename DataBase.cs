using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace BeautyArt
{
    internal class DataBase
    {
        static string con = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BeautyArt;Integrated Security=True;Connect Timeout=30;";
        SqlConnection sqlConnection = new SqlConnection(con);

        public void Open()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            else if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void Select(string query, DataGrid dataGrid)
        {
            Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            Open();
        }

        public void Update(string query)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                Open();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();
            Open();
        }

        public void ReadStudent(DataGrid dataGrid)
        {
            Select("select Students.IdStudent, Students.NameStud, Students.SurnameStud, Students.MiddlenameStud, Students.EmailStud, Students.NumberStud, Students.PassportData From Students", dataGrid);
        }

        public void ReadTeachers(DataGrid dataGrid)
        {
            Select("select Teachers.IdTeacher, Teachers.NameTeach, Teachers.SurnameTeach, Teachers.MiddlenameTeach, Teachers.Position, Teachers.NumberTeach From Teachers", dataGrid);
        }

        public void ReadTypeOfCourse(DataGrid dataGrid)
        {
            Select("select TypeOfCourse.IdTypeOfCourse, TypeOfCourse.TitleCourse, TypeOfCourse.MinMember, TypeOfCourse.MaxMember, TypeOfCourse.CostCourse, TypeOfCourse.Duration From TypeOfCourse", dataGrid);
        }

        public void ReadCourse(DataGrid dataGrid)
        {
            Select("select Courses.IdCourse, TypeOfCourse.TitleCourse, Teachers.SurnameTeach,  Courses.DateStart, Courses.DateEnd, Courses.CountStud From Courses, Teachers, TypeOfCourse Where Courses.IdTypeOfCourse = TypeOfCourse.IdTypeOfCourse And Courses.IdTeacher = Teachers.IdTeacher", dataGrid);
        }

        public void ReadSchedule(DataGrid dataGrid)
        {
            //Select("select Schedules.IdSchedule, Courses.IdCourse, Students.IdStudent, Teachers.IdTeacher, Schedules.Type, Schedules.Date, Schedules.Time, Schedules.Cabinet From Schedules, Courses, Teachers, Students Where Schedules.IdCourse = Courses.IdCourse And Schedules.IdStudent = Students.IdStudent And Schedules.IdTeacher = Teachers.IdTeacher", dataGrid);
        }
    }
}
