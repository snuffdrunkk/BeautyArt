using BeautyArt.Add;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System;
using BeautyArt.Edit;
using BeautyArt.Composition;
using DataGrid = System.Windows.Controls.DataGrid;
using BeautyArt.Service;
using BeautyArt.FilterData;
using DataGridColumn = System.Windows.Controls.DataGridColumn;
using Window = System.Windows.Window;

namespace BeautyArt
{
    public partial class MainWindow : Window
    {
        DataBase db;

        private string schedulePath = "D:\\Практика\\Prog\\BeautyArt\\Resources\\ScheduleExcel.xlsx";
        private string coursesPath = "D:\\Практика\\Prog\\BeautyArt\\Resources\\CoursesExcel.xlsx";
        private string studentsPath = "D:\\Практика\\Prog\\BeautyArt\\Resources\\StudentsExcel.xlsx";
        private OutputService outputService;

        public MainWindow()
        {
            InitializeComponent();
            
            db = new DataBase();
            outputService = new OutputService();
        }

        private void StudentsGridUpdate()//Обновление грида учеников
        {
            db.ReadStudent(StudentsGrid);
        }

        private void TeachersGridUpdate()//Обновление грида учителей
        {
            db.ReadTeachers(TeachersGrid);
        }

        private void TypeOfCourseGridUpdate()//Обновление грида видов курсов
        {
            db.ReadTypeOfCourse(TypeOfCoursesGrid);
        }

        private void CoursesGridUpdate()//Обновление грида курсов
        {
            db.ReadCourse(CoursesGrid);
        }

        private void ScheduleGridUpdate()//Обновление грида расписание
        {
            db.ReadSchedule(ScheduleGrid);
        }

        private void StudnetsShow_Click(object sender, RoutedEventArgs e)//Вывод студентов
        {
            StudentsGrid.Visibility = Visibility.Visible;
            TeachersGrid.Visibility = Visibility.Hidden;
            TypeOfCoursesGrid.Visibility = Visibility.Hidden;
            CoursesGrid.Visibility = Visibility.Hidden;
            ScheduleGrid.Visibility = Visibility.Hidden;

            SearchStudentsBox.Visibility = Visibility.Visible;
            SearchTeachersBox.Visibility = Visibility.Hidden;
            SearchTypeOfCourseBox.Visibility = Visibility.Hidden;
            SearchCoursesBox.Visibility = Visibility.Hidden;
            SearchScheduleBox.Visibility = Visibility.Hidden;

            FilterStudentsBox.Visibility = Visibility.Visible;
            FilterTeachersBox.Visibility = Visibility.Hidden;
            FilterTypeOfCoursesBox.Visibility = Visibility.Hidden;
            FilterCoursesBox.Visibility = Visibility.Hidden;
            FilterScheduleBox.Visibility = Visibility.Hidden;
            StudentsGridUpdate();
        }

        private void TeachersShow_Click(object sender, RoutedEventArgs e)//Вывод учителей
        {
            StudentsGrid.Visibility = Visibility.Hidden;
            TeachersGrid.Visibility = Visibility.Visible;
            TypeOfCoursesGrid.Visibility = Visibility.Hidden;
            CoursesGrid.Visibility = Visibility.Hidden;
            ScheduleGrid.Visibility = Visibility.Hidden;

            SearchStudentsBox.Visibility = Visibility.Hidden;
            SearchTeachersBox.Visibility = Visibility.Visible;
            SearchTypeOfCourseBox.Visibility = Visibility.Hidden;
            SearchCoursesBox.Visibility = Visibility.Hidden;
            SearchScheduleBox.Visibility = Visibility.Hidden;

            FilterStudentsBox.Visibility = Visibility.Hidden;
            FilterTeachersBox.Visibility = Visibility.Visible;
            FilterTypeOfCoursesBox.Visibility = Visibility.Hidden;
            FilterCoursesBox.Visibility = Visibility.Hidden;
            FilterScheduleBox.Visibility = Visibility.Hidden;
            TeachersGridUpdate();
        }
        private void TypeOfCoursesShow_Click(object sender, RoutedEventArgs e)//Вывод типов курсов
        {
            StudentsGrid.Visibility = Visibility.Hidden;
            TeachersGrid.Visibility = Visibility.Hidden;
            TypeOfCoursesGrid.Visibility = Visibility.Visible;
            CoursesGrid.Visibility = Visibility.Hidden;
            ScheduleGrid.Visibility = Visibility.Hidden;

            SearchStudentsBox.Visibility = Visibility.Hidden;
            SearchTeachersBox.Visibility = Visibility.Hidden;
            SearchTypeOfCourseBox.Visibility = Visibility.Visible;
            SearchCoursesBox.Visibility = Visibility.Hidden;
            SearchScheduleBox.Visibility = Visibility.Hidden;

            FilterStudentsBox.Visibility = Visibility.Hidden;
            FilterTeachersBox.Visibility = Visibility.Hidden;
            FilterTypeOfCoursesBox.Visibility = Visibility.Visible;
            FilterCoursesBox.Visibility = Visibility.Hidden;
            FilterScheduleBox.Visibility = Visibility.Hidden;
            TypeOfCourseGridUpdate();
        }

        private void CoursesShow_Click(object sender, RoutedEventArgs e)//Вывод курсов
        {
            StudentsGrid.Visibility = Visibility.Hidden;
            TeachersGrid.Visibility = Visibility.Hidden;
            TypeOfCoursesGrid.Visibility = Visibility.Hidden;
            CoursesGrid.Visibility = Visibility.Visible;
            ScheduleGrid.Visibility = Visibility.Hidden;

            SearchStudentsBox.Visibility = Visibility.Hidden;
            SearchTeachersBox.Visibility = Visibility.Hidden;
            SearchTypeOfCourseBox.Visibility = Visibility.Hidden;
            SearchCoursesBox.Visibility = Visibility.Visible;
            SearchScheduleBox.Visibility = Visibility.Hidden;

            FilterStudentsBox.Visibility = Visibility.Hidden;
            FilterTeachersBox.Visibility = Visibility.Hidden;
            FilterTypeOfCoursesBox.Visibility = Visibility.Hidden;
            FilterCoursesBox.Visibility = Visibility.Visible;
            FilterScheduleBox.Visibility = Visibility.Hidden;
            CoursesGridUpdate();
        }

        private void ScheduleShow_Click(object sender, RoutedEventArgs e)//Вывод расписания
        {
            StudentsGrid.Visibility = Visibility.Hidden;
            TeachersGrid.Visibility = Visibility.Hidden;
            TypeOfCoursesGrid.Visibility = Visibility.Hidden;
            CoursesGrid.Visibility = Visibility.Hidden;
            ScheduleGrid.Visibility = Visibility.Visible;

            SearchStudentsBox.Visibility = Visibility.Hidden;
            SearchTeachersBox.Visibility = Visibility.Hidden;
            SearchTypeOfCourseBox.Visibility = Visibility.Hidden;
            SearchCoursesBox.Visibility = Visibility.Hidden;
            SearchScheduleBox.Visibility = Visibility.Visible;

            FilterStudentsBox.Visibility = Visibility.Hidden;
            FilterTeachersBox.Visibility = Visibility.Hidden;
            FilterTypeOfCoursesBox.Visibility = Visibility.Hidden;
            FilterCoursesBox.Visibility = Visibility.Hidden;
            FilterScheduleBox.Visibility = Visibility.Visible;
            ScheduleGridUpdate();
        }

        private void StudentsAdd_Click(object sender, RoutedEventArgs e)//Добавление учеников
        {
            StudentsAdd studentsAdd = new StudentsAdd(StudentsGrid);
            studentsAdd.ShowDialog();
            StudentsGridUpdate();
        }

        private void TeachersAdd_Click(object sender, RoutedEventArgs e)//Добавление учителей   
        {
            TeachersAdd teatersAdd = new TeachersAdd(TeachersGrid);
            teatersAdd.ShowDialog();
            TeachersGridUpdate();
        }

        private void TypeOfCoursesAdd_Click(object sender, RoutedEventArgs e)//Добавление типа курса
        {
            TypeOfCourseAdd typeOfCourseAdd = new TypeOfCourseAdd(TypeOfCoursesGrid);
            typeOfCourseAdd.ShowDialog();
            TypeOfCourseGridUpdate();
        }

        private void CoursesAdd_Click(object sender, RoutedEventArgs e)//Добавление курса
        {
            CoursesAdd coursesAdd = new CoursesAdd(CoursesGrid);
            coursesAdd.ShowDialog();
            CoursesGridUpdate();
        }

        private void ScheduleAdd_Click(object sender, RoutedEventArgs e)//Добавление расписания
        {
            SchedulesAdd schedulesAdd = new SchedulesAdd(ScheduleGrid);
            schedulesAdd.ShowDialog();
            ScheduleGridUpdate();
        }

        private void ShowComposition_Click(object sender, RoutedEventArgs e)//Добавление состава
        {
            CompositionShow compShow = new CompositionShow(CompositionsGrid);
            compShow.curs = Convert.ToInt32((CoursesGrid.SelectedItem as DataRowView).Row.ItemArray[0].ToString());
            compShow.ShowDialog();
        }

        private void DeleteStudents_Click(object sender, RoutedEventArgs e)//Удаление ученика
        {
            try
            {
                var selectedRow = StudentsGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    db.Update($"DELETE FROM Students Where IdStudent = {selectedRow.Row.ItemArray[0]}");
                    StudentsGridUpdate();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Данные из строки используются в другой таблице! Удалите данные из другой таблицы.", "Ошибка при удалении");
            }
        }

        private void DeleteTeachers_Click(object sender, RoutedEventArgs e)//Удаление препода
        {
            try
            {
                var selectedRow = TeachersGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    db.Update($"DELETE FROM Teachers Where IdTeacher = {selectedRow.Row.ItemArray[0]}");
                    TeachersGridUpdate();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Данные из строки используются в другой таблице! Удалите данные из другой таблицы.", "Ошибка при удалении");
            }
        }

        private void DeleteTypeOfCourses_Click(object sender, RoutedEventArgs e)//Удаление типа
        {
            try
            {
                var selectedRow = TypeOfCoursesGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    db.Update($"DELETE FROM TypeOfCourse Where IdTypeOfCourse = {selectedRow.Row.ItemArray[0]}");
                    TypeOfCourseGridUpdate();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Данные из строки используются в другой таблице! Удалите данные из другой таблицы.", "Ошибка при удалении");
            }
        }

        private void DeleteCourses_Click(object sender, RoutedEventArgs e)//Удаление курса
        {
            try
            {
                var selectedRow = CoursesGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    db.Update($"DELETE FROM Courses Where IdCourse = {selectedRow.Row.ItemArray[0]}");
                    CoursesGridUpdate();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Данные из строки используются в другой таблице! Удалите данные из другой таблицы.", "Ошибка при удалении");
            }
        }

        private void DeleteSchedule_Click(object sender, RoutedEventArgs e)//Удаление расписания
        {
            try
            {
                var selectedRow = ScheduleGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    db.Update($"DELETE FROM Schedules Where IdSchedule = {selectedRow.Row.ItemArray[0]}");
                    ScheduleGridUpdate();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Данные из строки используются в другой таблице! Удалите данные из другой таблицы.", "Ошибка при удалении");
            }
        }

        private void SearchStudentsBox_TextChanged(object sender, TextChangedEventArgs e)//Поиск учеников
        {
            string searchText = SearchStudentsBox.Text.ToLower();
            SearchAndHighlightRowsStud(searchText);
        }
        private void SearchAndHighlightRowsStud(string searchText)
        {
            foreach (DataGridRow row in GetDataGridRows(StudentsGrid))
            {
                var rowData = row.Item as DataRowView;
                if (rowData != null)
                {
                    bool found = false;
                    foreach (DataGridColumn column in StudentsGrid.Columns)
                    {
                        string cellValue = rowData[column.SortMemberPath].ToString();
                        if (searchText == "")
                        {
                            break;
                        }
                        if (cellValue.ToLower().Contains(searchText))
                        {
                            row.Background = Brushes.MediumPurple;
                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        row.Background = Brushes.Transparent;
                    }
                }
            }
        }

        private void SearchTeachersBox_TextChanged(object sender, TextChangedEventArgs e)//Поиск преподов
        {
            string searchText = SearchTeachersBox.Text.ToLower();
            SearchAndHighlightRowsTeach(searchText);
        }

        private void SearchAndHighlightRowsTeach(string searchText)
        {
            foreach (DataGridRow row in GetDataGridRows(TeachersGrid))
            {
                var rowData = row.Item as DataRowView;
                if (rowData != null)
                {
                    bool found = false;
                    foreach (DataGridColumn column in TeachersGrid.Columns)
                    {
                        string cellValue = rowData[column.SortMemberPath].ToString();
                        if (searchText == "")
                        {
                            break;
                        }
                        if (cellValue.ToLower().Contains(searchText))
                        {
                            row.Background = Brushes.MediumPurple;
                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        row.Background = Brushes.Transparent;
                    }
                }
            }
        }

        private void SearchTypeOfCourseBox_TextChanged(object sender, TextChangedEventArgs e)//Поиск видов курса
        {
            string searchText = SearchTypeOfCourseBox.Text.ToLower();
            SearchAndHighlightRowsType(searchText);
        }
        private void SearchAndHighlightRowsType(string searchText)
        {
            foreach (DataGridRow row in GetDataGridRows(TypeOfCoursesGrid))
            {
                var rowData = row.Item as DataRowView;
                if (rowData != null)
                {
                    bool found = false;
                    foreach (DataGridColumn column in TypeOfCoursesGrid.Columns)
                    {
                        string cellValue = rowData[column.SortMemberPath].ToString();
                        if (searchText == "")
                        {
                            break;
                        }
                        if (cellValue.ToLower().Contains(searchText))
                        {
                            row.Background = Brushes.MediumPurple;
                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        row.Background = Brushes.Transparent;
                    }
                }
            }
        }

        private void SearchCoursesBox_TextChanged(object sender, TextChangedEventArgs e)//Поиск курсов
        {
            string searchText = SearchCoursesBox.Text.ToLower();
            SearchAndHighlightRowsCourse(searchText);
        }
        private void SearchAndHighlightRowsCourse(string searchText)
        {
            foreach (DataGridRow row in GetDataGridRows(CoursesGrid))
            {
                var rowData = row.Item as DataRowView;
                if (rowData != null)
                {
                    bool found = false;
                    foreach (DataGridColumn column in CoursesGrid.Columns)
                    {
                        string cellValue = rowData[column.SortMemberPath].ToString();
                        if (searchText == "")
                        {
                            break;
                        }
                        if (cellValue.ToLower().Contains(searchText))
                        {
                            row.Background = Brushes.MediumPurple;
                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        row.Background = Brushes.Transparent;
                    }
                }
            }
        }

        private void SearchScheduleBox_TextChanged(object sender, TextChangedEventArgs e)//Поиск расписания
        {
            string searchText = SearchScheduleBox.Text.ToLower();
            SearchAndHighlightRowsSchedule(searchText);
        }
        private void SearchAndHighlightRowsSchedule(string searchText)
        {
            foreach (DataGridRow row in GetDataGridRows(ScheduleGrid))
            {
                var rowData = row.Item as DataRowView;
                if (rowData != null)
                {
                    bool found = false;
                    foreach (DataGridColumn column in ScheduleGrid.Columns)
                    {
                        string cellValue = rowData[column.SortMemberPath].ToString();
                        if (searchText == "")
                        {
                            break;
                        }
                        if (cellValue.ToLower().Contains(searchText))
                        {

                            row.Background = Brushes.MediumPurple;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        row.Background = Brushes.Transparent;
                    }
                }
            }
        }

        private IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        private void FilterStudentsBox_TextChanged(object sender, TextChangedEventArgs e)//Фильтрация учеников
        {
            string searchText = FilterStudentsBox.Text.ToLower();
            SearchAndHideRows(searchText, StudentsGrid);
        }

        private void FilterTeachersBox_TextChanged(object sender, TextChangedEventArgs e)//Фильтрация преподов
        {
            string searchText = FilterTeachersBox.Text.ToLower();
            SearchAndHideRows(searchText, TeachersGrid);
        }

        private void FilterTypeOfCoursesBox_TextChanged(object sender, TextChangedEventArgs e)//Фильтрация видов курса
        {
            string searchText = FilterTypeOfCoursesBox.Text.ToLower();
            SearchAndHideRows(searchText, TypeOfCoursesGrid);
        }

        private void FilterCoursesBox_TextChanged(object sender, TextChangedEventArgs e)//Фильтрация курсов
        {
            string searchText = FilterCoursesBox.Text.ToLower();
            SearchAndHideRows(searchText, CoursesGrid);
        }

        private void FilterScheduleBox_TextChanged(object sender, TextChangedEventArgs e)//Фильтрация расписания
        {
            string searchText = FilterScheduleBox.Text.ToLower();
            SearchAndHideRows(searchText, ScheduleGrid);
        }

        private void SearchAndHideRows(string searchText, DataGrid datagrid)
        {
            foreach (DataGridRow row in GetDataGridRows(datagrid))
            {
                var rowData = row.Item as DataRowView;
                if (rowData != null)
                {
                    bool found = false;
                    foreach (DataGridColumn column in datagrid.Columns)
                    {
                        string cellValue = rowData[column.SortMemberPath].ToString();
                        if (searchText == "")
                        {
                            found = true;
                            break;
                        }
                        if (cellValue.ToLower().Contains(searchText))
                        {
                            row.Visibility = Visibility.Visible;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        row.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private void ReturnStudents_Click(object sender, RoutedEventArgs e)//Отменена ученик
        {
            StudentsGridUpdate();
        }

        private void ReturnTeachers_Click(object sender, RoutedEventArgs e)//Отменена учитель
        {
            TeachersGridUpdate();
        }

        private void ReturnTypeOfCourses_Click(object sender, RoutedEventArgs e)//Отменена тип
        {
            TypeOfCourseGridUpdate();
        }

        private void ReturnCourses_Click(object sender, RoutedEventArgs e)//Отменена курс
        {
            CoursesGridUpdate();
        }

        private void ReturnSchedule_Click(object sender, RoutedEventArgs e)//Отменена расписание
        {
            ScheduleGridUpdate();
        }

        private void EditStudents_Click(object sender, RoutedEventArgs e)//Редактирование студентов
        {
            var selectedRow = StudentsGrid.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                StudentsEdit window = new StudentsEdit(StudentsGrid, Convert.ToInt32(selectedRow.Row.ItemArray[0]), Convert.ToString(selectedRow.Row.ItemArray[1]), Convert.ToString(selectedRow.Row.ItemArray[2]), Convert.ToString(selectedRow.Row.ItemArray[3]), Convert.ToString(selectedRow.Row.ItemArray[4]), Convert.ToString(selectedRow.Row.ItemArray[5]), Convert.ToString(selectedRow.Row.ItemArray[6]));
                window.ShowDialog();
                StudentsGridUpdate();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для редактирования", "Ошибка", MessageBoxButton.OK);
            }
        }

        private void EditTeachers_Click(object sender, RoutedEventArgs e)//Редактирование препод
        {
            var selectedRow = TeachersGrid.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                TeachersEdit window = new TeachersEdit(TeachersGrid, Convert.ToInt32(selectedRow.Row.ItemArray[0]), Convert.ToString(selectedRow.Row.ItemArray[1]), Convert.ToString(selectedRow.Row.ItemArray[2]), Convert.ToString(selectedRow.Row.ItemArray[3]), Convert.ToString(selectedRow.Row.ItemArray[4]), Convert.ToString(selectedRow.Row.ItemArray[5]));
                window.ShowDialog();
                TeachersGridUpdate();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для редактирования", "Ошибка", MessageBoxButton.OK);
            }
        }

        private void EditTypeOfCourses_Click(object sender, RoutedEventArgs e)//Редакт тип
        {
            var selectedRow = TypeOfCoursesGrid.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                TypeOfCourseEdit window = new TypeOfCourseEdit(TypeOfCoursesGrid, Convert.ToInt32(selectedRow.Row.ItemArray[0]), Convert.ToString(selectedRow.Row.ItemArray[1]), Convert.ToString(selectedRow.Row.ItemArray[2]), Convert.ToString(selectedRow.Row.ItemArray[3]), Convert.ToString(selectedRow.Row.ItemArray[4]), Convert.ToString(selectedRow.Row.ItemArray[5]));
                window.ShowDialog();
                TypeOfCourseGridUpdate();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для редактирования", "Ошибка", MessageBoxButton.OK);
            }
        }

        private void EditCourses_Click(object sender, RoutedEventArgs e)//Редакт курс
        {
            var selectedRow = CoursesGrid.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                CoursesEdit window = new CoursesEdit(CoursesGrid, Convert.ToInt32(selectedRow.Row.ItemArray[0]), Convert.ToString(selectedRow.Row.ItemArray[1]), Convert.ToString(selectedRow.Row.ItemArray[2]), Convert.ToString(selectedRow.Row.ItemArray[3]), Convert.ToInt32(selectedRow.Row.ItemArray[4]));
                window.ShowDialog();
                TypeOfCourseGridUpdate();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для редактирования", "Ошибка", MessageBoxButton.OK);
            }
        }

        private void EditSchedule_Click(object sender, RoutedEventArgs e)//Редакт расписание
        {
            var selectedRow = ScheduleGrid.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                SchedulesEdit window = new SchedulesEdit(ScheduleGrid, Convert.ToInt32(selectedRow.Row.ItemArray[0]), Convert.ToString(selectedRow.Row.ItemArray[1]), Convert.ToString(selectedRow.Row.ItemArray[2]), Convert.ToString(selectedRow.Row.ItemArray[3]), Convert.ToString(selectedRow.Row.ItemArray[4]), Convert.ToString(selectedRow.Row.ItemArray[5]), Convert.ToString(selectedRow.Row.ItemArray[6]));
                window.ShowDialog();
                ScheduleGridUpdate();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для редактирования", "Ошибка", MessageBoxButton.OK);
            }
        }

        private void ExcelSchedule_Click(object sender, RoutedEventArgs e)//Печать расписания
        {
            outputService.ExportScheduleToExcel(ScheduleGrid, schedulePath, "Расписание", true);
        }


        private void ExcelCourse_Click(object sender, RoutedEventArgs e)//Печать курса
        {
            outputService.ExportScheduleToExcel(CoursesGrid, coursesPath, "Курсы", false);
        }

        private void ExcelDateSchedule_Click(object sender, RoutedEventArgs e)//Печать расп по дате
        {
            ExcelDataShedule excelDataShow = new ExcelDataShedule(ScheduleGrid);
            excelDataShow.ShowDialog();
        }

        private void ExcelStudents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedRow = StudentsGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    outputService.ExportStudToExcel(StudentsGrid, studentsPath, "Договор", true, selectedRow);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Выберите строку.", "Ошибка при печати");
            }
        }
    }

}
