using System;
namespace StudentAdmissionManagement
{
    class Student
    {
        private int studentId;
        private string studentName;
        private int age;
        private string course;
        private double admissionFees;

        public Student(int id, string name, int age, string course, double fees)
        {
            studentId = id;
            studentName = name;
            this.age = age;
            this.course = course;
            admissionFees = fees;
        }

        public void DisplayStudent()
        {
            Console.WriteLine("\n------ Student Admission Details ------");
            Console.WriteLine("Student ID      : " + studentId);
            Console.WriteLine("Student Name    : " + studentName);
            Console.WriteLine("Age             : " + age);
            Console.WriteLine("Course          : " + course);
            Console.WriteLine("Admission Fees  : " + admissionFees);
        }

        public void UpdateCourse(string newCourse)
        {
            course = newCourse;
            Console.WriteLine("\nCourse Updated Successfully.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student(101, "Isha Thaker", 20, "B.Tech", 45000);

            student1.DisplayStudent();

            student1.UpdateCourse("M.Tech");

            student1.DisplayStudent();

            Console.ReadLine();
        }
    }}
