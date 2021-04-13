using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30._03._2021
{
    class Question
    {
        public string Content { get; set; }
        public List<Option> Options { get; set; }

        public Question(string content, List<Option> options)
        {
            Content = content;
            Options = options;
        }
    }
}
