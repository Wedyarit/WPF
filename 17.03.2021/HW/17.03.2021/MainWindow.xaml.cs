using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _17._03._2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentDatabase _studentDatabase;

        private void DisplayStudent((Student student, int index) studentData)
        {
            tbStudentID.Text = studentData.student.Id.ToString();
            tbStudentName.Text = studentData.student.Name;
            tbStudentRollNo.Text = studentData.student.RollNo.ToString();
            tbStudentCurrent.Text = $"{studentData.index + 1} of {_studentDatabase.Count}";
        }

        public MainWindow()
        {
            InitializeComponent();
            _studentDatabase = new StudentDatabase();

            btnSearch.Click += Search;
            btnFirst.Click += First;
            btnPrev.Click += Prev;
            btnNext.Click += Next;
            btnLast.Click += Last;
        }

        private void Search(object sender, EventArgs e)
        {
            if (int.TryParse(tbInputStudentID.Text, out int id))
            {
                (Student Student, int Index) studentData = _studentDatabase.GetStudentDataByID(id);
                if (studentData.Index != -1)
                {
                    DisplayStudent(studentData);
                    tbInputStudentID.Text = "";
                }
            }
        }

        private void First(object sender, EventArgs e) => DisplayStudent(_studentDatabase.First);
        private void Prev(object sender, EventArgs e) => DisplayStudent(_studentDatabase.Previous);
        private void Next(object sender, EventArgs e) => DisplayStudent(_studentDatabase.Next);
        private void Last(object sender, EventArgs e) => DisplayStudent(_studentDatabase.Last);
    }
}
