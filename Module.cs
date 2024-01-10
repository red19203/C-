using System;
using System.Collections.Generic;
using System.IO;

namespace Project
{
    class Module
    {
        public string ModuleName { get; set; }

        public static List<Module> ModulesList = new List<Module>();


        public void Add()
        {
            Console.WriteLine("Enter module details:");
            Console.Write("Module Name: ");
            ModuleName = Console.ReadLine();

            ModulesList.Add(this);

            CreateModuleFolder(ModuleName);

            Console.WriteLine("Module added successfully!");

        }


        public void Edit()
        {
            Console.Write("Enter module name to edit: ");
            string ModuleNameToEdit = Console.ReadLine();

            Module moduleToEdit = ModulesList.Find(m => m.ModuleName == ModuleNameToEdit);

            if (moduleToEdit != null)
            {
                Console.WriteLine("Enter new module details:");
                Console.Write("Module Name: ");
                moduleToEdit.ModuleName = Console.ReadLine();

                UpdateModuleFolderName(moduleToEdit.ModuleName);

                Console.WriteLine("Module details updated successfully!");
            }
            else
            {
                Console.WriteLine("Module not found!");
            }
        }

        public void Delete()
        {
            Console.Write("Enter module name to delete: ");
            string ModuleNameToDelete = Console.ReadLine();

            Module moduleToDelete = ModulesList.Find(m => m.ModuleName == ModuleNameToDelete);

            if (moduleToDelete != null)
            {
                ModulesList.Remove(moduleToDelete);

                DeleteModuleFolder(moduleToDelete.ModuleName);

                Console.WriteLine("Module deleted successfully!");
            }
            else
            {
                Console.WriteLine("Module not found!");
            }
        }

        public void DisplayDetails()
        {
            /*
            Console.Write("Enter module Name to display details: ");
            string ModuleNameToDisplay = Console.ReadLine();

            Module moduleToDisplay = ModulesList.Find(m => m.ModuleName == ModuleNameToDisplay);

            if (moduleToDisplay != null)
            {
                Console.WriteLine("Module Details:");
                Console.WriteLine($"Name: {moduleToDisplay.ModuleName}");
            }
            else
            {
                Console.WriteLine("Module not found!");
            }
            */
            List<Module> modules = Module.ModulesList;

foreach (Module module in modules)
{
    Console.WriteLine(module.ModuleName);
}
        }

        public void CreateModuleFolder(string ModuleName)
        {
            string moduleFolderPath = GetModuleFolderPath(ModuleName);

            if (!Directory.Exists(moduleFolderPath))
            {
                Directory.CreateDirectory(moduleFolderPath);
                Console.WriteLine($"Module folder '{moduleFolderPath}' created successfully!");
            }
        }

public void UpdateModuleFolderName(string newModuleName)
{
    string oldModuleFolderPath = GetModuleFolderPath(ModuleName);
    string newModuleFolderPath = GetModuleFolderPath(newModuleName);

    try
    {
        if (Directory.Exists(oldModuleFolderPath) && !Directory.Exists(newModuleFolderPath))
        {
            string destinationFolderPath = GetModuleFolderPath(newModuleName, includeOldName: true);

            Directory.Move(oldModuleFolderPath, destinationFolderPath);
            Console.WriteLine($"Module folder name updated to '{newModuleName}'!");
        }
        else
        {
            Console.WriteLine($"Failed to update module folder name. Source: '{oldModuleFolderPath}', Destination: '{newModuleFolderPath}'");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to update module folder name. Error: {ex.Message}");
    }
}

private string GetModuleFolderPath(string moduleName, bool includeOldName = false)
{
    return includeOldName ? $"{moduleName}" : $"{moduleName}";
}


        public void DeleteModuleFolder(string ModuleName)
        {
            string moduleFolderPath = GetModuleFolderPath(ModuleName);

            if (Directory.Exists(moduleFolderPath))
            {
                Directory.Delete(moduleFolderPath, true);
                Console.WriteLine($"Module folder '{moduleFolderPath}' deleted successfully!");
            }
        }

        private string GetModuleFolderPath(string ModuleName)
        {
            return $"{ModuleName}";
        }
public void AddCoursesToModule()
{
    Console.WriteLine("Existing Courses:");
    foreach (var courseFile in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt"))
    {
        string courseName = Path.GetFileNameWithoutExtension(courseFile);
        Console.WriteLine(courseName);
    }

    Console.Write("Enter the course name to add to the module: ");
    string courseNameToAdd = Console.ReadLine();

    Console.Write("Enter the module name where the course should be added: ");
    string moduleName = Console.ReadLine();

    Module selectedModule = Module.ModulesList.Find(m => m.ModuleName.Equals(moduleName, StringComparison.OrdinalIgnoreCase));

    if (selectedModule != null)
    {
        string moduleFolderPath = GetModuleFolderPath(selectedModule.ModuleName);
        string sourceCoursePath = $"{courseNameToAdd}.txt";
        string destinationCoursePath = Path.Combine(moduleFolderPath, $"{courseNameToAdd}.txt");

        if (File.Exists(sourceCoursePath) && Directory.Exists(moduleFolderPath))
        {
            if (!File.Exists(destinationCoursePath))
            {
                File.Move(sourceCoursePath, destinationCoursePath);
                Console.WriteLine($"Course '{courseNameToAdd}' added to module '{selectedModule.ModuleName}'.");
            }
            else
            {
                Console.WriteLine($"Course '{courseNameToAdd}' already exists in module '{selectedModule.ModuleName}'.");
            }
        }
        else
        {
            if (!File.Exists(sourceCoursePath))
            {
                Console.WriteLine($"Course '{courseNameToAdd}' does not exist.");
            }

            if (!Directory.Exists(moduleFolderPath))
            {
                Console.WriteLine($"Module folder '{moduleFolderPath}' not found. Please check the module name.");
            }
        }
    }
    else
    {
        Console.WriteLine($"Module '{moduleName}' does not exist. Please check the module name case sensitivity.");
    }
}

    }

}
