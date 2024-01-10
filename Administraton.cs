using System;
using System.Collections.Generic;

namespace Project
{
class Administration
{
    public void ManageStudents()
    {
        Student student = new Student();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Edit Student");
            Console.WriteLine("3. View Student Details");
            Console.WriteLine("4. Delete Student");
            
            Console.WriteLine("5. Back to Administration Menu");
            Console.Write("Enter your choice (1-5): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        student.Add();
                        break;
                    case 2:
                        student.Edit();
                        break;
                    case 3:
                        student.ViewDetails();
                        break;
                    case 4:
                        student.Delete();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }

            Console.WriteLine(); 
        }
    }

    public void ManageTeachers()
    {
        Teacher teacher = new Teacher();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. Edit Teacher");
            Console.WriteLine("3. View Teacher Details");
            Console.WriteLine("4. Delete Teacher");
            Console.WriteLine("5. Back to Administration Menu");
            Console.Write("Enter your choice (1-5): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        teacher.Add();
                        break;
                    case 2:
                        teacher.Edit();
                        break;
                    case 3:
                        teacher.ViewDetails();
                        break;
                    case 4:
                        teacher.Delete();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }

            Console.WriteLine(); 
        }
    }
        public void CalendarMenu(Calendar calendar, Administration admin)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Calendar Management");
            Console.WriteLine("1. Create Exam Date");
            Console.WriteLine("2. Change Exam Date");
            Console.WriteLine("3. Create Course Deadline");
            Console.WriteLine("4. Change Course Deadline");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Enter your choice (1-4): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                    calendar.CreateExamDate(admin);
                        break;
                    case 2:
                    Console.Write("Enter Exam Name: ");
                    string examName = Console.ReadLine();
                    Console.Write("Enter New Exam Date (dd/mm/yyyy): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newExamDate))
                    {
                        calendar.ChangeExamDate(examName, newExamDate, admin);
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                    }
                        break;
                    case 3:
                    calendar.CreateCourseDeadline(admin);
                        break;
                    case 4:
                    Console.Write("Enter Course Name: ");
                    string courseName = Console.ReadLine();
                    Console.Write("Enter New Course Deadline (dd/mm/yyyy): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newDeadline))
                    {
                        calendar.ChangeCourseDeadline(courseName, newDeadline, admin);
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                    }
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }

            Console.WriteLine(); 
            Console.WriteLine("*******************"); 
        }
    }
            public void ModuleMenu()
        {
            Module module = new Module();

            while (true)
            {
                Console.WriteLine("Module Menu:");
                Console.WriteLine("1. Add Module");
                Console.WriteLine("2. Edit Module");
                Console.WriteLine("3. Delete Module");
                Console.WriteLine("4. Display Module Details");
                Console.WriteLine("5. Add a courses to Module");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice (1-5): ");
                int choice;

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            module.Add();
                            break;

                        case 2:
                            module.Edit();
                            break;

                        case 3:
                            module.Delete();
                            break;

                        case 4:
                            module.DisplayDetails();
                            break;
                        case 5:
                            module.AddCoursesToModule();
                            break;

                        case 6:
                            Console.WriteLine("Exiting Module Menu. Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }
        public void CoursesMenu(CourseManager courseManager)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Courses Management");
            Console.WriteLine("1. Add Course");
            Console.WriteLine("2. Update Course");
            Console.WriteLine("3. Delete Course");
            Console.WriteLine("4. View Course Details");
            Console.WriteLine("5. Back to Administration Menu");
            Console.Write("Enter your choice (1-4): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter course name: ");
                        string courseName = Console.ReadLine();
                        Console.Write("Enter course details: ");
                        string courseDetails = Console.ReadLine();
                        courseManager.AddCourse(courseName, courseDetails);
                        break;
                    case 2:
                        Console.Write("Enter course name: ");
                        string updateCourseName = Console.ReadLine();
                        Console.Write("Enter updated course details: ");
                        string updatedCourseDetails = Console.ReadLine();
                        courseManager.UpdateCourse(updateCourseName, updatedCourseDetails);
                        break;
                    case 3:
                        Console.Write("Enter course name to delete: ");
                        string deleteCourseName = Console.ReadLine();
                        courseManager.DeleteCourse(deleteCourseName);
                        break;
                    case 4:
                        Console.Write("Enter course name to view content: ");
                        string viewContentCourseName = Console.ReadLine();
                        courseManager.ViewCourseContent(viewContentCourseName);
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }

            Console.WriteLine(); 
        }
    }


}
}
