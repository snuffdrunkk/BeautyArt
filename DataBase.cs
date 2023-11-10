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
            Select("select Schedules.IdSchedule, TypeOfCourse.TitleCourse, Schedules.Type, Students.SurnameStud, Schedules.Date, Schedules.Time, Cabinet from Schedules left join Students on Schedules.IdStudent = Students.IdStudent left join Courses on Schedules.IdCourse = Courses.IdCourse left join TypeOfCourse on Courses.IdTypeOfCOurse = TypeOfCourse.IdTypeOfCourse left join Teachers on Courses.IdTeacher = Teachers.IdTeacher ", dataGrid);
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

        public DataTable Select(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataTable data = new DataTable();
            adapter.Fill(data);

            return data;
        }

        public DataTable GetOrderComposition(string productName)
        {
            string query = $@"SELECT product.title, order_composition.quantity, ord.order_type
                FROM order_composition, ord, product
                where ord.order_id = order_composition.order_id
                and order_composition.product_id = product.product_id
                and product.title = N'{productName}'";

            DataTable result = Select(query);
            DataTable newTable = new DataTable();

            newTable.Columns.Add("Название", typeof(string));
            newTable.Columns.Add("Приход", typeof(int));
            newTable.Columns.Add("Расход", typeof(int));
            newTable.Columns.Add("Остаток", typeof(int));

            foreach (DataRow row in result.Rows)
            {
                string title = row["title"].ToString();
                int quantity = int.Parse(row["quantity"].ToString());
                string orderType = row["order_type"].ToString();

                DataRow newRow = newTable.NewRow();

                newRow["Название"] = title;
                newRow["Приход"] = orderType == "Поступление" ? quantity : 0;
                newRow["Расход"] = orderType == "Выбытие" ? quantity : 0;

                newTable.Rows.Add(newRow);
            }

            return newTable;
        }
    }
}
