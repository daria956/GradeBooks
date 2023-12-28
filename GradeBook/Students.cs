using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using GradeBook.Enums;

namespace GradeBook
{
    public class Students
    {
        public string Name { get; set; }
        public StudentType Type { get; set; }
        public EnrollmentType Enrollment { get; set; }
        public List<double> Grades { get; set; }
        [JsonIgnore]
        public double AverageGrade
        {
            get
            {
                return Grades.Average();
            }
        }
        [JsonIgnore]
        public char LetterGrade { get; set; }
        [JsonIgnore]
        public double GPA { get; set; }

        public Students(string name, StudentType studentType, EnrollmentType enrollment)
        {
            Name = name;
            Type = studentType;
            Enrollment = enrollment;
            Grades = new List<double>();
        }


        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)

                throw new ArgumentException("Gardes must be between 0 and 100");
            Grades.Add(grade);

        }
        public void RemoveGrades(double grade)
        {

            Grades.Remove(grade);

        }
        //public void ShowGrades()
        //{

        //        if (Grades.Count == 0)
        //    { 
        //            Console.WriteLine($"Student {Name} doesn't have a grade");
        //        return;
        //    }

        //    foreach (double grade in Grades)
        //    {
        //        Console.WriteLine(grade);
        //    }
        //}


    }
}
