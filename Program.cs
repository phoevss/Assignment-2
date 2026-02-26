using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Student
{
    public int StudentID { get; set; }
    public string Name { get; set; }
    public string Course { get; set; }
    public int Grade { get; set; }

    
    public Student(int studentID, string name, string course, int grade)
    {
        this.StudentID = studentID;
        this.Name = name;
        this.Course = course;
        this.Grade = grade;
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        string filePath = @"C:\Users\malin\Assignment2\students.txt";  // Update the path if necessary

        List<Student> students = new List<Student>
        {
            new Student(101, "Monkey D. Luffy", "Pirate King", 89),
            new Student(102, "Roronoa Zoro", "Swordsman", 92),
            new Student(103, "Nami", "Navigator", 75),
            new Student(104, "Usopp", "Sniper", 85),
            new Student(105, "Sanji", "Cook", 90)
        };

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.StudentID},{student.Name},{student.Course},{student.Grade}");
                }
            }

            Console.WriteLine("Student records have been written to students.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // Task 2
        List<Student> readStudents = new List<Student>();

        try
        {
            foreach (var line in File.ReadLines(filePath))
            {
                var data = line.Split(',');
                readStudents.Add(new Student(int.Parse(data[0]), data[1], data[2], int.Parse(data[3])));
            }

            
            var studentsAbove85 = readStudents.Where(s => s.Grade > 85).ToList();
            Console.WriteLine("\nStudents with Grade > 85:");
            foreach (var student in studentsAbove85)
            {
                Console.WriteLine($"{student.Name} - {student.Grade}");
            }

            var sortedByGrade = readStudents.OrderByDescending(s => s.Grade).ToList();
            Console.WriteLine("\nSorted by Grade (Descending):");
            foreach (var student in sortedByGrade)
            {
                Console.WriteLine($"{student.Name} - {student.Grade}");
            }

            var studentNames = readStudents.Select(s => s.Name).ToList();
            Console.WriteLine("\nStudent Names:");
            foreach (var name in studentNames)
            {
                Console.WriteLine(name);
            }

            var averageGrade = readStudents.Average(s => s.Grade);
            Console.WriteLine($"\nAverage Grade: {averageGrade:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}