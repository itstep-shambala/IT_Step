using System;

namespace IT_STEP
{
    public class Student
    {
        public Student(string firstName, string lastName, DateTime dateOfBirth, string faculty, int numberOfGroup, double averageMark)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Faculty = faculty;
            NumberOfGroup = numberOfGroup;
            AverageMark = averageMark;
        }

        public Student() {}

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Faculty { get; set; }
        public int NumberOfGroup { get; set; }
        public double AverageMark { get; set; }
    }
}