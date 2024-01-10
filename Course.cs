using System;
using System.Collections.Generic;
using System.IO;

namespace Project
{
class CourseManager
{

public void AddCourse(string courseName, string courseDetails)
{
    string courseFileName = $"{courseName}.txt";

    if (!File.Exists(courseFileName))
    {
        using (StreamWriter sw = File.CreateText(courseFileName))
        {
            sw.Write(courseDetails);
        }

        Console.WriteLine($"Course '{courseName}' added successfully.");
    }
    else
    {
        Console.WriteLine($"Course '{courseName}' already exists.");
    }
}

    public void UpdateCourse(string courseName, string newCourseDetails)
    {
        string courseFileName = $"{courseName}.txt";

        if (File.Exists(courseFileName))
        {
            File.WriteAllText(courseFileName, newCourseDetails);
            Console.WriteLine($"Course '{courseName}' updated successfully.");
        }
        else
        {
            Console.WriteLine($"Course '{courseName}' does not exist.");
        }
    }

    public void DeleteCourse(string courseName)
    {
        string courseFileName = $"{courseName}.txt";

        if (File.Exists(courseFileName))
        {
            File.Delete(courseFileName);
            Console.WriteLine($"Course '{courseName}' deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Course '{courseName}' does not exist.");
        }
    }
        public void ViewCourseContent(string courseName)
    {
        string courseFileName = $"{courseName}.txt";

        if (File.Exists(courseFileName))
        {
            string content = File.ReadAllText(courseFileName);
            Console.WriteLine($"Course Content for '{courseName}':");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine($"Course '{courseName}' does not exist.");
        }
    }
}
}