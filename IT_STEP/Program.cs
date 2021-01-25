using System;
using System.Collections.Generic;
using System.IO;

namespace IT_STEP
{
    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("Режимы работы:");
            Console.WriteLine("1. Показ данных всех студентов");
            Console.WriteLine("2. Добавление нового студента");
            Console.WriteLine("3. Изменение данных о студенте");
            Console.WriteLine("4. Удаление данных о студенте");
            Console.WriteLine("5. Сохранение данных в файл");
        }

        static void ExportToFile(List<Student> students, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = "export.csv";
            }
            foreach (var student in students)
            {
                try
                {
                    using var file = new StreamWriter(path, true);
                    file.WriteLine(
                        $"{student.FirstName};{student.LastName};{student.DateOfBirth:G};{student.Faculty};{student.NumberOfGroup};{student.AverageMark}");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Отказано в доступе");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine(
                        "Параметр path пуст или path содержит имя системного устройства (com1, com2 и т. д.).");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Указан недопустимый путь (например, он ведет на несопоставленный диск)");
                }
                catch (IOException)
                {
                    Console.WriteLine(
                        "Параметр path включает неверный или недопустимый синтаксис имени файла, имени каталога или метки тома");
                }
            }
        }

        static void AddStudentToList(ref List<Student> students)
        {
            string select;
            string firstName;
            string lastName;
            DateTime dateOfBirth;
            string faculty;
            int numberOfGroup;
            double averageMark;
            Student tempStudent;
            
            do
            {
                Console.Write("Введите имя: ");
                firstName = Console.ReadLine();
                Console.Write("Введите фамилию: ");
                lastName = Console.ReadLine();
                Console.WriteLine("Введите дату рождения: ");
                dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Введите факультет: ");
                faculty = Console.ReadLine();
                Console.Write("Введите номер группы: ");
                numberOfGroup = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите среднюю оценку: ");
                averageMark = Convert.ToDouble(Console.ReadLine());

                tempStudent = new Student(firstName, lastName, dateOfBirth, faculty, numberOfGroup, averageMark);
                students.Add(tempStudent);

                Console.Write("Нажмите Y - если хотите ввести данные ещё одного студента");
                select = Console.ReadLine();
            } while (select == "Y" || select == "y");
        }

        static void ShowStudent(Student student)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}, {student.DateOfBirth:d}, {student.Faculty} {student.NumberOfGroup}, {student.AverageMark}");
        }
        static void ShowStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                ShowStudent(student);
            }
        }

        static void Main()
        {
            var student = new Student("Andrey", "Starinin", DateTime.Now, "SD", 1, 2);
            var students = new List<Student>();
            students.Add(student);

            string select;

            do
            {
                ShowMenu();
                var choice = Convert.ToChar(Console.ReadLine());
                switch (choice)
                {
                    case '1':
                        ShowStudents(students);
                        break;
                    case '2':
                        AddStudentToList(ref students);
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        Console.Write("Введите имя файла: ");
                        var path = Console.ReadLine();
                        ExportToFile(students, path);
                        break;
                }
                
                Console.Write("Нажмите Y - если хотите продолжить");
                select = Console.ReadLine();
            } while (select == "Y" || select == "y");
            
            Console.WriteLine("До свидания...");
        }
    }
}