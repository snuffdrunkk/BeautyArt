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
            db.Select("select Schedules.IdSchedule, Courses.IdCourse, Students.IdStudent, Teachers.IdTeacher, Schedules.Type, Schedules.Date, Schedules.Time, Schedules.Cabinet From Schedules, Courses, Teachers, Students Where Schedules.IdCourse = Courses.IdCourse And Schedules.IdStudent = Students.IdStudent And Schedules.IdTeacher = Teachers.IdTeacher", ScheduleGrid);
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
            StudentsAdd studentsAdd = new StudentsAdd(StudentsGrid);
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
