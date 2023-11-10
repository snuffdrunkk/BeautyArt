using BeautyArt.Service;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BeautyArt.FilterData
{
    public partial class ExcelDataShedule : Window
    {
        public DateTime firstDate;
        public DateTime secondDate;

        public DataGrid dataGrid;

        private OutputService outputService;

        private string filePath = "D:\\Практика\\Prog\\BeautyArt\\Resources\\DateScheduleExcel.xlsx";

        public ExcelDataShedule(DataGrid dataGrid)
        {
            InitializeComponent();

            this.dataGrid = dataGrid;

            outputService = new OutputService();
        }

        private void ExcelButton_Click(object sender, RoutedEventArgs e)
        {
            firstDate = DatePickerDateStart.SelectedDate.Value;
            secondDate = DatePickerDateEnd.SelectedDate.Value;

            outputService.ExportScheduleToExcelWithDate(dataGrid, filePath, "Расписание на определенные дни" ,false, firstDate, secondDate);

            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
