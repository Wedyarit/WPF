using System;
using System.Collections.Generic;
using System.Text;

namespace _17._03._2021
{
    class Student
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int RollNo { get; private set; }

        public Student(int id, string name, int rollNo)
        {
            Id = id;
            Name = name;
            RollNo = rollNo;
        }

    }
}
