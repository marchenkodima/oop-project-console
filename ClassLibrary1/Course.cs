using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Course
    {
        string Name;
        string Task;

        public Course(string name)
        {
            Name = name;
            Task = "";
        }

        public void CreateTask(string task)
        {
            Task = task;
        }

        public bool SubmitTask(string result, Student student)
        {
            return Task == result;
        }

        public string GetTask()
        {
            return Task;
        }
    }
}
