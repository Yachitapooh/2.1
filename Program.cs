using System;
using System.Collections.Generic;


enum Menu
{
    ResisterNewStudent = 1,
    ResisterNewTeacher,
    GetListPersons
}
namespace HW2satcode
{
    class Program
    {
        static PersonList personList;

        static void Main(string[] args)
        {
            PreparePersonListWhenProgramIsLoad();
            PrintMenuScreen();
        }

        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.personList = new PersonList(); 
        }
        static void PrintMenuScreen()
        {
            Console.Clear();
            PrintHeader();               
            PrintMenuScreen();
        }
        static void PrintHeader()
        {
            Console.WriteLine("Welcome to registration new user school application.");
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("1.Registration new student.");
            Console.WriteLine("2.Registration new teacher.");
            Console.WriteLine("3.Get List Persons.");

            Console.Write("Please select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));
            PresentMenu(menu);
        }

        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.ResisterNewStudent)
            {
                ShowInputRegistrationNewStudentScreen();
            }
            else if (menu == Menu.ResisterNewTeacher)
            {
                ShowInputRegistrationNewTeacherScreen();
            }
            else if (menu == Menu.GetListPersons)
            {
                ShowGetListPersonScreen();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }
        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.personList.FetchPersonList();
            InputExitFromKeyboard();
        }
        static void InputExitFromKeyboard()
        {
            string text = "";
            while (text != "exit")
            {
                Console.Write("Input: ");
                text = Console.ReadLine();
            }
            Console.Clear();
            PrintMenuScreen();
        }
        static void ShowInputRegistrationNewTeacherScreen()
        {
            Console.Clear();
            PrintHeaderRegisterTeacher();

            int totalTeacher = TotalNewTeacher();
            InputNewTeacherFromKeyboard(totalTeacher);
        }
        static void InputNewTeacherFromKeyboard(int totalTeacher)
        {
            for (int i = 0; i < totalTeacher; i++)
            {
                Console.Clear();
                PrintHeaderRegisterTeacher();

                Teacher teacher = CreateNewTeacher();
                Program.personList.AddNewPerson(teacher);
            }
        }
        static Teacher CreateNewTeacher()
        {
            return new Teacher(InputName(), InputAddress(), InputCitizenID(), InputEmployeetID());
        }
        static string InputEmployeetID()
        {
            Console.Write("EmployeeID: ");

            return Console.ReadLine();
        }
        static int TotalNewTeacher()
        {
            Console.Write("Input total new Teacher: ");

            return int.Parse(Console.ReadLine());
        }
        static void ShowInputRegistrationNewStudentScreen()
        {
            Console.Clear();
            PrintHeaderRegisretStudent();

            int totalStudent = TotalNewStudent();

            InputNewStudentFromKeyboard(totalStudent);
        }
        static void InputNewStudentFromKeyboard(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();
                PrintHeaderRegisretStudent();

                Student student = CreateNewStudent();

               Program.personList.AddNewPerson(student);
            }
        }

        static Student CreateNewStudent()
        {
            return new Student(InputName(), InputAddress(), InputCitizenID(), InputStudentID());
        }
        static string InputName() 
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }
        static string InputAddress()
        {
            Console.Write("Address: ");
            return Console.ReadLine();
        }
        static string InputCitizenID()
        {
            Console.Write("CitizenID: ");
            return Console.ReadLine();
        }
        static string InputStudentID()
        {
            Console.Write("StudentID: ");
            return Console.ReadLine();
        }

        static int TotalNewStudent()
        {
            Console.Write("Input total new student: ");
            return int.Parse(Console.ReadLine());
        }
        static void PrintHeaderRegisretStudent()
        {
            Console.WriteLine("Register new Student");
            Console.WriteLine("--------------------");
        }
        static void PrintHeaderRegisterTeacher()
        {
            Console.WriteLine("Register new Teacher");
            Console.WriteLine("--------------------");
        }
        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu incorrect Please try again.");
        }
        //////////////////////////////////////////////
        class Person
        {
            protected string name; 
            protected string address;
            protected string citizenID;

            public Person(string name, string address, string citizenID)
            {
                this.name = name;
                this.address = address;
                this.citizenID = citizenID;
            }

            public string GetName()
            {
                return this.name;
            }
        }
        //////////////////////////////////////////////
        class Student : Person
        {
            private string studentID;

            public Student(string name, string address, string citizenID, string studentID) : base(name, address, citizenID)
            {              
                this.studentID = studentID;   
            }
        }
        //////////////////////////////////////////////
        class PersonList  
        {
            private List<Person> personList;

            public PersonList()

            {
                this.personList = new List<Person>();
            }

            public void AddNewPerson(Person person)
            {
                this.personList.Add(person);
            }

            public void FetchPersonList()
            {
                Console.WriteLine("List Persons");
                Console.WriteLine("------------");

                foreach (Person person in this.personList)
                {
                    if (person is Student)
                    {
                        Console.WriteLine("Name: {0} \n Type: Student", person.GetName());
                    }
                    else if (person is Teacher)
                    {
                        Console.WriteLine("Name: {0} \n Type: Teacher", person.GetName());
                    }
                }
            }
        }
        //////////////////////////////////////////////
        class Teacher : Person
        {
            private string employeeID;

            public Teacher(string name, string address, string citizenID, string employeeID) : base(name, address, citizenID)
            {             
                this.employeeID = employeeID;  
            }
        }

    }
} 

