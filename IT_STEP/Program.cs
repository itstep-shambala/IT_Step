using System;
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

        static void ExportToFile(Student student, string path)
        {
            try
            {
                using var file = new StreamWriter(path, false);
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

        static void Main()
        {
            var student = new Student("Andrey", "Starinin", DateTime.Now, "SD", 1, 2);
            ShowMenu();
            var choice = Convert.ToChar(Console.ReadLine());
            switch (choice)
            {
                case '1':
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '5':
                    Console.Write("Введите имя файла: ");
                    var path = Console.ReadLine();
                    ExportToFile(student, path);
                    break;
            }
        }
    }
}