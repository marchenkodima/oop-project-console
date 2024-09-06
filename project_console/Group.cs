using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    class Group
    {
        public string id;
        public string[] studentIds;

        public Group(string groupName)
        {
            id = groupName;
        }

        public void AddStudent(string studentId)
        {
            // Code to add a student to the group
            throw new NotImplementedException();
        }

        public void RemoveStudent(string studentId)
        {
            // Code to remove a student from the group
            throw new NotImplementedException();
        }
    }
}
