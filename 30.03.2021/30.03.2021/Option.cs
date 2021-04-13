using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30._03._2021
{


    class Option
    {
        private bool _isCorrect;

        public string Content { get; set; }
        public string IsCorrectString { get; set; }

        public bool IsCorrect
        {
            get { return _isCorrect; }
            set
            {
                if (value)
                {
                    IsCorrectString = "Correct answer";
                }
                else
                {
                    IsCorrectString = "";
                }
                _isCorrect = value;
            }
        }

        public Option(string content)
        {
            Content = content;
            IsCorrect = false;
        }
    }
}
