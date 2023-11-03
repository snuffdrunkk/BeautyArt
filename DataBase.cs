using BeautyArt.Add;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BeautyArt
{
    internal class DataBase
    {
        private static string con = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BeautyArt;Integrated Security=True;Connect Timeout=30;";
        SqlConnection sqlConnection = new SqlConnection(con);

        private string selectCourse = $"select Courses.IdCourse, concat(TitleCourse,' ',DateStart,' ', " +
            "SurnameTeach) as aa  from Courses inner join TypeOfCourse on TypeOfCourse.IdTypeOfCourse=Courses.IdTypeOfCourse" +
            " inner join Teachers on Teachers.IdTeacher=Courses.IdTeacher";
        
        private string selectTeachers = $"select IdTeacher, SurnameTeach from Teachers";
        private string selectStudent = $"select IdStudent, SurnameStud from Students";
        private string selectTypeOfCourse = $"select IdTypeOfCourse, TitleCourse from TypeOfCourse";

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
            Select("select IdStudent, NameStud, SurnameStud, MiddlenameStud, EmailStud, NumberStud, PassportData From Students", dataGrid);
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
            Select("select Courses.IdCourse, TypeOfCourse.TitleCourse, Teachers.SurnameTeach,  Courses.DateStart, Courses.CountStud From Courses, Teachers, TypeOfCourse Where Courses.IdTypeOfCourse = TypeOfCourse.IdTypeOfCourse And Courses.IdTeacher = Teachers.IdTeacher", dataGrid);
        }

        public void ReadSchedule(DataGrid dataGrid)
        {
            Select("select Schedules.IdSchedule, Type, Students.SurnameStud, Date, Time, Cabinet from Students, Courses, Schedules where Schedules.IdCourse = Courses.IdCourse And Schedules.IdStudent = Students.IdStudent", dataGrid);
        }

        public void ReadCoursesToComboBox(ComboBox box)
        {
            ComboBoxToTable(selectCourse, box);
        }

        public void ReadTypeOfCourseToComboBox(ComboBox box)
        {
            ComboBoxToTable(selectTypeOfCourse, box);
        }

        public void ReadTeachersToComboBox(ComboBox box)
        {
            ComboBoxToTable(selectTeachers, box);
        }

        public void ReadStudentsToComboBox(ComboBox box)
        {
            ComboBoxToTable(selectStudent, box);
        }

        public void ComboBoxToTable(string query, ComboBox box)
        {
            Open();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            box.Items.Clear();
            while (reader.Read())
            {
                ComboBoxDTO dto = new ComboBoxDTO();
                dto.id = reader.GetInt64(0);
                dto.name = reader.GetString(1);
                box.Items.Add(dto);
            }
            reader.Close();
            Open();
        }
    }
}
