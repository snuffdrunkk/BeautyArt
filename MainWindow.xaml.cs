using BeautyArt.Add;
using System.Windows;
using System.Windows.Controls;

namespace BeautyArt
{
    public partial class MainWindow : Window
    {
        DataBase db;
        public MainWindow()
        {
            InitializeComponent();
            db = new DataBase();
        }

        private void StudentsGridUpdate()
        {
            db.ReadStudent(StudentsGrid);
        }

        private void TeachersGridUpdate()//Обновление грида учителей
        {
            db.Select("select Teachers.IdTeacher, Teachers.NameTeach, Teachers.SurnameTeach, Teachers.MiddlenameTeach, Teachers.Position, Teachers.NumberTeach From Teachers", TeachersGrid);
            TeachersGrid.Columns[0].Visibility = Visibility.Hidden;
            TeachersGrid.Columns[1].Header = "Имя";
            TeachersGrid.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            TeachersGrid.Columns[2].Header = "Фамилия";
            TeachersGrid.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            TeachersGrid.Columns[3].Header = "Отчество";
            TeachersGrid.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            TeachersGrid.Columns[4].Header = "Должность";
            TeachersGrid.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            TeachersGrid.Columns[5].Header = "Номер телефона";
            TeachersGrid.Columns[5].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
        }

        private void TypeOfCourseGridUpdate()//Обновление грида видов курсов
        {
            db.Select("select TypeOfCourse.IdTypeOfCourse, TypeOfCourse.TitleCourse, TypeOfCourse.MinMember, TypeOfCourse.MaxMember, TypeOfCourse.CostCourse, TypeOfCourse.Duration From TypeOfCourse", TypeOfCoursesGrid);
            TypeOfCoursesGrid.Columns[0].Visibility = Visibility.Hidden;
            TypeOfCoursesGrid.Columns[1].Header = "Наименование";
            TypeOfCoursesGrid.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            TypeOfCoursesGrid.Columns[2].Header = "Минимум человек";
            TypeOfCoursesGrid.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            TypeOfCoursesGrid.Columns[3].Header = "Максимум человек";
            TypeOfCoursesGrid.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            TypeOfCoursesGrid.Columns[4].Header = "Стоимость";
            TypeOfCoursesGrid.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            TypeOfCoursesGrid.Columns[5].Header = "Продолжительность";
            TypeOfCoursesGrid.Columns[5].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
        }

        private void CoursesGridUpdate()//Обновление грида курсов
        {
            db.Select("select Courses.IdCourse, Teachers.IdTeacher, TypeOfCourse.IdTypeOfCourse, Courses.DateStart, Courses.DateEnd, Courses.CountStud From Courses, Teachers, TypeOfCourse Where Courses.IdTeacher = Teachers.IdTeacher And Courses.IdTypeOfCourse = TypeOfCourse.IdTypeOfCourse", CoursesGrid);
            CoursesGrid.Columns[0].Visibility = Visibility.Hidden;
            CoursesGrid.Columns[1].Header = "Наименование";
            CoursesGrid.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            CoursesGrid.Columns[2].Header = "Учитель";
            CoursesGrid.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            CoursesGrid.Columns[3].Header = "Дата начала";
            CoursesGrid.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            CoursesGrid.Columns[4].Header = "Дата окончания";
            CoursesGrid.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            CoursesGrid.Columns[5].Header = "Количество учеников";
            CoursesGrid.Columns[5].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
        }

        private void ScheduleGridUpdate()//Обновление грида расписание
        {
            db.Select("select Schedules.IdSchedule, Courses.IdCourse, Students.IdStudent, Teachers.IdTeacher, Schedules.Type, Schedules.Date, Schedules.Time, Schedules.Cabinet From Schedules, Courses, Teachers, Students Where Schedules.IdCourse = Courses.IdCourse And Schedules.IdStudent = Students.IdStudent And Schedules.IdTeacher = Teachers.IdTeacher", ScheduleGrid);
            ScheduleGrid.Columns[0].Visibility = Visibility.Hidden;
            ScheduleGrid.Columns[1].Header = "Наименование";
            ScheduleGrid.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            ScheduleGrid.Columns[2].Header = "Ученик";
            ScheduleGrid.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            ScheduleGrid.Columns[3].Header = "Учитель";
            ScheduleGrid.Columns[3].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            ScheduleGrid.Columns[4].Header = "Тип занятия";
            ScheduleGrid.Columns[4].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            ScheduleGrid.Columns[5].Header = "Дата";
            ScheduleGrid.Columns[5].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            ScheduleGrid.Columns[6].Header = "Время";
            ScheduleGrid.Columns[6].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
            ScheduleGrid.Columns[7].Header = "Кабинет";
            ScheduleGrid.Columns[7].Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
        }

        private void StudnetsShow_Click(object sender, RoutedEventArgs e)//Вывод студентов
        {
            StudentsGrid.Visibility = Visibility.Visible;
            TeachersGrid.Visibility = Visibility.Hidden;
            TypeOfCoursesGrid.Visibility = Visibility.Hidden;
            CoursesGrid.Visibility = Visibility.Hidden;
            ScheduleGrid.Visibility = Visibility.Hidden;

            /*            SearchTypeOfBusBox.Visibility = Visibility.Hidden;
                        SearchDriversBox.Visibility = Visibility.Hidden;
                        SearchTicketBox.Visibility = Visibility.Hidden;
                        SearchRouteBox.Visibility = Visibility.Hidden;
                        SearchBusBox.Visibility = Visibility.Visible;

                        FilterTypeOfBusBox.Visibility = Visibility.Visible;
                        FilterDriversBox.Visibility = Visibility.Hidden;
                        FilterTicketBox.Visibility = Visibility.Hidden;
                        FilterRouteBox.Visibility = Visibility.Hidden;
                        FilterBusBox.Visibility = Visibility.Hidden;*/
            StudentsGridUpdate();
        }

        private void TeachersShow_Click(object sender, RoutedEventArgs e)//Вывод учителей
        {
            StudentsGrid.Visibility = Visibility.Hidden;
            TeachersGrid.Visibility = Visibility.Visible;
            TypeOfCoursesGrid.Visibility = Visibility.Hidden;
            CoursesGrid.Visibility = Visibility.Hidden;
            ScheduleGrid.Visibility = Visibility.Hidden;

            /*            SearchTypeOfBusBox.Visibility = Visibility.Visible;
                        SearchDriversBox.Visibility = Visibility.Hidden;
                        SearchTicketBox.Visibility = Visibility.Hidden;
                        SearchRouteBox.Visibility = Visibility.Hidden;
                        SearchBusBox.Visibility = Visibility.Hidden;

                        FilterTypeOfBusBox.Visibility = Visibility.Hidden;
                        FilterDriversBox.Visibility = Visibility.Hidden;
                        FilterTicketBox.Visibility = Visibility.Hidden;
                        FilterRouteBox.Visibility = Visibility.Hidden;
                        FilterBusBox.Visibility = Visibility.Visible;*/
            TeachersGridUpdate();
        }
        private void TypeOfCoursesShow_Click(object sender, RoutedEventArgs e)//Вывод типов курсов
        {
            StudentsGrid.Visibility = Visibility.Hidden;
            TeachersGrid.Visibility = Visibility.Hidden;
            TypeOfCoursesGrid.Visibility = Visibility.Visible;
            CoursesGrid.Visibility = Visibility.Hidden;
            ScheduleGrid.Visibility = Visibility.Hidden;

            /*            SearchTypeOfBusBox.Visibility = Visibility.Hidden;
                        SearchDriversBox.Visibility = Visibility.Visible;
                        SearchTicketBox.Visibility = Visibility.Hidden;
                        SearchRouteBox.Visibility = Visibility.Hidden;
                        SearchBusBox.Visibility = Visibility.Hidden;

                        FilterTypeOfBusBox.Visibility = Visibility.Hidden;
                        FilterDriversBox.Visibility = Visibility.Visible;
                        FilterTicketBox.Visibility = Visibility.Hidden;
                        FilterRouteBox.Visibility = Visibility.Hidden;
                        FilterBusBox.Visibility = Visibility.Hidden;*/
            TypeOfCourseGridUpdate();
        }

        private void CoursesShow_Click(object sender, RoutedEventArgs e)//Вывод курсов
        {
            StudentsGrid.Visibility = Visibility.Hidden;
            TeachersGrid.Visibility = Visibility.Hidden;
            TypeOfCoursesGrid.Visibility = Visibility.Hidden;
            CoursesGrid.Visibility = Visibility.Visible;
            ScheduleGrid.Visibility = Visibility.Hidden;

            /*            SearchTypeOfBusBox.Visibility = Visibility.Hidden;
                        SearchDriversBox.Visibility = Visibility.Hidden;
                        SearchTicketBox.Visibility = Visibility.Visible;
                        SearchRouteBox.Visibility = Visibility.Hidden;
                        SearchBusBox.Visibility = Visibility.Hidden;

                        FilterTypeOfBusBox.Visibility = Visibility.Hidden;
                        FilterDriversBox.Visibility = Visibility.Hidden;
                        FilterTicketBox.Visibility = Visibility.Visible;
                        FilterRouteBox.Visibility = Visibility.Hidden;
                        FilterBusBox.Visibility = Visibility.Hidden;*/
            CoursesGridUpdate();
        }

        private void ScheduleShow_Click(object sender, RoutedEventArgs e)//Вывод расписания
        {
            StudentsGrid.Visibility = Visibility.Hidden;
            TeachersGrid.Visibility = Visibility.Hidden;
            TypeOfCoursesGrid.Visibility = Visibility.Hidden;
            CoursesGrid.Visibility = Visibility.Hidden;
            ScheduleGrid.Visibility = Visibility.Visible;

            /*            SearchTypeOfBusBox.Visibility = Visibility.Hidden;
                        SearchDriversBox.Visibility = Visibility.Hidden;
                        SearchTicketBox.Visibility = Visibility.Hidden;
                        SearchRouteBox.Visibility = Visibility.Visible;
                        SearchBusBox.Visibility = Visibility.Hidden;

                        FilterTypeOfBusBox.Visibility = Visibility.Hidden;
                        FilterDriversBox.Visibility = Visibility.Hidden;
                        FilterTicketBox.Visibility = Visibility.Hidden;
                        FilterRouteBox.Visibility = Visibility.Visible;
                        FilterBusBox.Visibility = Visibility.Hidden;*/
            ScheduleGridUpdate();
        }

        private void StudentsAdd_Click(object sender, RoutedEventArgs e)//Добавление учеников
        {
            StudentsAdd studentsAdd = new StudentsAdd();
            studentsAdd.ShowDialog();
            StudentsGridUpdate();
        }

        private void TeachersAdd_Click(object sender, RoutedEventArgs e)
        {
            TeachersAdd teatersAdd = new TeachersAdd(TeachersGrid);
            teatersAdd.ShowDialog();
            TeachersGridUpdate();
        }
    }
}
