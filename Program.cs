using System;

namespace Project
{
    class Program
    {
        static CourseManager courseManager = new CourseManager();

        static void StudentMenu(Student student)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Student Management");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Edit Student");
                Console.WriteLine("3. View Student Details");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Back to Main Menu");
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
                Console.WriteLine("******************"); 
            }
        }

        static void TeacherMenu(Teacher teacher)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Teacher Management");
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Edit Teacher");
                Console.WriteLine("3. View Teacher Details");
                Console.WriteLine("4. Delete Teacher");
                Console.WriteLine("5. Back to Main Menu");
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
                Console.WriteLine("******************"); 
            }
        }

        static void AdminMenu(Administration admin, Calendar calendar)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Administration Menu");
                Console.WriteLine("1. Manage Students");
                Console.WriteLine("2. Manage Teachers");
                Console.WriteLine("3. Calendar Management");
                Console.WriteLine("4. Courses Management");
                Console.WriteLine("5. Modules Management");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice (1-6): ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            admin.ManageStudents();
                            break;
                        case 2:
                            admin.ManageTeachers();
                            break;
                        case 3:
                            admin.CalendarMenu(calendar, admin);
                            break;
                        case 4:
                            admin.CoursesMenu(courseManager);
                            break;
                        case 5:
                            admin.ModuleMenu();
                            break;

                        case 6:
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
                Console.WriteLine("******************"); 
            }
        }


             static void Main()
        {
            Student student = new Student();
            Teacher teacher = new Teacher();
            Calendar calendar = new Calendar(); 
            Administration admin = new Administration(); 
            Module myModule = new Module();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("School Management System");
                Console.WriteLine("1. Student Management");
                Console.WriteLine("2. Teacher Management");
                Console.WriteLine("3. Administration Menu");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            StudentMenu(student);
                            break;
                        case 2:
                            TeacherMenu(teacher);
                            break;
                        case 3:
                            AdminMenu(admin, calendar);
                            break;
                        case 4:
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
                Console.WriteLine("******************"); 
            }
        }
    }
}
