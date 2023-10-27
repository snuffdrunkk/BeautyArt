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
    }
}
