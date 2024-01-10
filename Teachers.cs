using System;
using System.Collections.Generic;

namespace Project
{
class Teacher
{
    public int TeacherID { get; set; }
    public string Password { get; set; } 
    public string Name { get; set; }
    public string Prenom { get; set; }
    public string Prof { get; set; }
    private static int lastAssignedId = 1;



    public Teacher()
    {
        TeacherID = ++lastAssignedId;

    }

    public static List<Teacher> TeachersList = new List<Teacher>();

    public void Add()
    {
        Console.WriteLine("Enter teacher details:");
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("Prenom: ");
        Prenom = Console.ReadLine();
        Console.Write("Prof de: ");
        Prof = Console.ReadLine();
        Console.WriteLine($"Your new ID is: {TeacherID}");
        Console.Write("Password: ");
        Password = Console.ReadLine(); 


        TeachersList.Add(this);

        Console.WriteLine("Teacher added successfully!");
    }

    public void Edit()
    {
        Console.Write("Enter teacher ID to edit: ");
        int teacherIdToEdit = int.Parse(Console.ReadLine());

        Console.Write("Enter password: ");
        string passwordToEdit = Console.ReadLine();

        Teacher teacherToEdit = TeachersList.Find(t => t.TeacherID == teacherIdToEdit && t.Password == passwordToEdit);

        if (teacherToEdit != null)
        {
            Console.WriteLine("Enter new details:");
            Console.Write("Name: ");
            teacherToEdit.Name = Console.ReadLine();
            Console.Write("Prof de: ");
            teacherToEdit.Prof = Console.ReadLine();


            Console.WriteLine("Teacher details updated successfully!");
        }
        else
        {
            Console.WriteLine("Teacher not found!");
        }
    }

    public void Delete()
    {
        Console.Write("Enter teacher ID to delete: ");
        int teacherIdToDelete = int.Parse(Console.ReadLine());

        Console.Write("Enter password: ");
        string passwordToDelete = Console.ReadLine();


        Teacher teacherToDelete = TeachersList.Find(t => t.TeacherID == teacherIdToDelete && t.Password == passwordToDelete);

        if (teacherToDelete != null)
        {
            TeachersList.Remove(teacherToDelete);
            Console.WriteLine("Teacher deleted successfully!");
        }
        else
        {
            Console.WriteLine("Teacher not found!");
        }
    }

    public void ViewDetails()
    {
        Console.Write("Enter teacher ID to view details: ");
        int teacherIdToView = int.Parse(Console.ReadLine());

        Console.Write("Enter password: ");
        string passwordToView = Console.ReadLine();

        Teacher teacherToView = TeachersList.Find(t => t.TeacherID == teacherIdToView && t.Password == passwordToView);

        if (teacherToView != null)
        {
            Console.WriteLine("Teacher Details:");
            Console.WriteLine($"ID: {teacherToView.TeacherID}");
            Console.WriteLine($"Name: {teacherToView.Name}");
            Console.WriteLine($"Prof de: {teacherToView.Prof}");
        }
        else
        {
            Console.WriteLine("Teacher not found!");
        }
    }

}
}