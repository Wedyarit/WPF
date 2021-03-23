using System;
using System.Collections.Generic;
using System.Text;

namespace _17._03._2021
{
    class StudentDatabase
    {
        private List<Student> _students;
        private int _displayingStudentIndex;

        public (Student, int) Previous { get { if (_displayingStudentIndex - 1 > 0) return (_students[--_displayingStudentIndex], _displayingStudentIndex); return (_students[_displayingStudentIndex = 0], _displayingStudentIndex); } }
        public (Student, int) Next { get { if (_displayingStudentIndex + 1 < _students.Count) return (_students[++_displayingStudentIndex], _displayingStudentIndex); return (_students[_displayingStudentIndex = _students.Count - 1], _displayingStudentIndex); } }
        public (Student, int) First { get => (_students[_displayingStudentIndex = 0], _displayingStudentIndex); }
        public (Student, int) Last { get => (_students[_displayingStudentIndex = _students.Count - 1], _displayingStudentIndex); }
        public int Count { get => _students.Count; }

        public StudentDatabase()
        {
            _displayingStudentIndex = 0;
            _students = new List<Student>();
            foreach (string line in System.IO.File.ReadAllLines("list.csv"))
            {
                string[] columns = line.Split(';');
                _students.Add(new Student(Int32.Parse(columns[0]), $"{columns[1]} {columns[2].Substring(0, 1)}. {columns[3].Substring(0, 1)}.", Int32.Parse(columns[4])));
            }
        }

        public (Student, int) GetStudentDataByID(int id)
        {
            int index = _students.FindIndex(student => student.Id == id);
            if (index < 0) return (null, -1);
            _displayingStudentIndex = index;
            return (_students[index], index);
        }
    }
}