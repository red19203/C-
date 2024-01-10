using System;
using System.Collections.Generic;
using System.IO;

namespace Project
{
    class Calendar
    {
        private Dictionary<string, DateTime> examDates;
        private Dictionary<string, DateTime> courseDeadlines;

        public Calendar()
        {
            examDates = new Dictionary<string, DateTime>();
            courseDeadlines = new Dictionary<string, DateTime>();
            LoadCalendarData(); 
        }




        public void DisplayExamDates()
        {
            Console.WriteLine("Exam Dates:");
            foreach (var exam in examDates)
            {
                Console.WriteLine($"{exam.Key}: {exam.Value.ToShortDateString()}");
            }
        }

        public void DisplayCourseDeadlines()
        {
            Console.WriteLine("Course Deadlines:");
            foreach (var deadline in courseDeadlines)
            {
                Console.WriteLine($"{deadline.Key}: {deadline.Value.ToShortDateString()}");
            }
        }

        public void ChangeExamDate(string examName, DateTime newDate, Administration admin)
        {
            if (admin != null)
            {
                examDates[examName] = newDate;
                Console.WriteLine($"Exam date for {examName} updated.");
                SaveCalendarData(); 
            }
            else
            {
                Console.WriteLine("Access denied. Only admin can change exam dates.");
            }
        }

        public void ChangeCourseDeadline(string courseName, DateTime newDeadline, Administration admin)
        {
            if (admin != null)
            {
                courseDeadlines[courseName] = newDeadline;
                Console.WriteLine($"Course deadline for {courseName} updated.");
                SaveCalendarData(); 
            }
            else
            {
                Console.WriteLine("Access denied. Only admin can change course deadlines.");
            }
        }

        public void CreateExamDate(Administration admin)
        {
            if (admin != null)
            {
                Console.Write("Enter Exam Name: ");
                string examName = Console.ReadLine();
                Console.Write("Enter Exam Date (dd/mm/yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime examDate))
                {
                    examDates[examName] = examDate;
                    Console.WriteLine($"Exam date for {examName} created.");
                    SaveCalendarData(); 
                }
                else
                {
                    Console.WriteLine("Invalid date format.");
                }
            }
            else
            {
                Console.WriteLine("Access denied. Only admin can create exam dates.");
            }
        }

        public void CreateCourseDeadline(Administration admin)
        {
            if (admin != null)
            {
                Console.Write("Enter Course Name: ");
                string courseName = Console.ReadLine();
                Console.Write("Enter Course Deadline (dd/mm/yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime deadline))
                {
                    courseDeadlines[courseName] = deadline;
                    Console.WriteLine($"Course deadline for {courseName} created.");
                    SaveCalendarData();
                }
                else
                {
                    Console.WriteLine("Invalid date format.");
                }
            }
            else
            {
                Console.WriteLine("Access denied. Only admin can create course deadlines.");
            }
        }

private void SaveCalendarData()
{
    using (StreamWriter sw = new StreamWriter("calendar.txt"))
    {
        foreach (var exam in examDates)
        {
            sw.WriteLine($"{exam.Value.DayOfWeek}: Exam {exam.Key}");
        }

        foreach (var deadline in courseDeadlines)
        {
            sw.WriteLine($"{deadline.Value.DayOfWeek}: Course {deadline.Key}");
        }
    }
}

        private void LoadCalendarData()
        {
            if (File.Exists("calendar.txt"))
            {
                foreach (var line in File.ReadLines("calendar.txt"))
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 3)
                    {
                        string type = parts[0];
                        string itemName = parts[1];
                        if (DateTime.TryParse(parts[2], out DateTime date))
                        {
                            if (type == "ExamDate")
                            {
                                examDates[itemName] = date;
                            }
                            else if (type == "CourseDeadline")
                            {
                                courseDeadlines[itemName] = date;
                            }
                        }
                    }
                }
            }
        }
}
}