using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Course
    {
        public string Name { get; set; }
        string Task { get; set; }
        string Answer { get; set; }
        string Faculty { get; set; }

        public Course(string name)
        {
            Name = name;
            Task = "";
        }

        public void CreateTask(string task, string answer, string faculty)
        {
            Task = task;
            Answer = answer;
            Faculty = faculty;
        }

        public bool SubmitTask(string result, Student student)
        {
            return Answer == result;
        }

        public string GetTask()
        {
            return Task;
        }
    }
}
