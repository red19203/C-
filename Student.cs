using System;
using System.Collections.Generic;

namespace Project
{
class Student
{
    public int StudentID { get; set; }
    public string Password { get; set; } 
    public string Name { get; set; }
    public string Prenom { get; set; }
    public string CurrentClass { get; set; }

    public string Niveau { get; set; }

    public string Special { get; set; }

    private static int lastAssignedId = 1000; 



    public Student()
    {
        StudentID = ++lastAssignedId;

    }




    public static List<Student> StudentsList = new List<Student>();


    public void Add()
    {
        Console.WriteLine("Enter student details:");
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("Prenom: ");
        Prenom = Console.ReadLine();
        Console.Write("Class: ");
        CurrentClass = Console.ReadLine();
        Console.Write("Niveau: ");
        Niveau = Console.ReadLine();
        Console.Write("Specialité: ");
        Special = Console.ReadLine();
        StudentID = ++lastAssignedId;
        Console.WriteLine($"Your new ID is: {StudentID}");
        Console.Write("Password: ");
        Password = Console.ReadLine(); 


        StudentsList.Add(this);

        Console.WriteLine("Student added successfully!");
    }

    public void Edit()
    {
        Console.Write("Enter student ID: ");
        int studentIdToEdit = int.Parse(Console.ReadLine());

        Console.Write("Enter password: ");
        string passwordToEdit = Console.ReadLine();

        Student studentToEdit = StudentsList.Find(s => s.StudentID == studentIdToEdit && s.Password == passwordToEdit);

        if (studentToEdit != null)
        {
            Console.WriteLine("Enter new details:");
            Console.Write("Name: ");
            studentToEdit.Name = Console.ReadLine();
            Console.Write("Prenom: ");
            studentToEdit.Prenom = Console.ReadLine();
            Console.Write("Class: ");
            studentToEdit.CurrentClass = Console.ReadLine();
            Console.Write("Niveau: ");
            studentToEdit.Niveau = Console.ReadLine();
            Console.Write("Specialité: ");
            studentToEdit.Special = Console.ReadLine();

            Console.WriteLine("Student details updated successfully!");
        }
        else
        {
            Console.WriteLine("Invalid student ID or password! Editing failed.");
        }
    }

    public void Delete()
    {
        Console.Write("Enter student ID: ");
        int studentIdToDelete = int.Parse(Console.ReadLine());

        Console.Write("Enter password: ");
        string passwordToDelete = Console.ReadLine();

        Student studentToDelete = StudentsList.Find(s => s.StudentID == studentIdToDelete && s.Password == passwordToDelete);

        if (studentToDelete != null)
        {
            StudentsList.Remove(studentToDelete);
            Console.WriteLine("Student deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid student ID or password! Deletion failed.");
        }
    }

    public void ViewDetails()
{
    Console.Write("Enter student ID: ");
    int studentIdToView = int.Parse(Console.ReadLine());

    Console.Write("Enter password: ");
    string passwordToView = Console.ReadLine();

    Student studentToView = StudentsList.Find(s => s.StudentID == studentIdToView && s.Password == passwordToView);

    if (studentToView != null)
    {
        Console.WriteLine("Student Details:");
        Console.WriteLine($"ID: {studentToView.StudentID}");
        Console.WriteLine($"Name: {studentToView.Name}");
        Console.WriteLine($"Prenom: {studentToView.Prenom}");
        Console.WriteLine($"Class: {studentToView.CurrentClass}");
        Console.WriteLine($"Niveau: {studentToView.Niveau}");
        Console.WriteLine($"Special: {studentToView.Special}");
        try
        {
            string courseContent = File.ReadAllText("course.txt");
            Console.WriteLine($"****Course****\n{courseContent}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Course file not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading Course file: {ex.Message}");
        }

        try
        {
            string calendarContent = File.ReadAllText("calendar.txt");
            Console.WriteLine($"****Calendar****\n{calendarContent}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Calendar file not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading calendar file: {ex.Message}");
        }
    }
    else
    {
        Console.WriteLine("Invalid student ID or password! Viewing details failed.");
    }
}

}

}