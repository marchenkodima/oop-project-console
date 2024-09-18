using project_console;

namespace unit_test
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void GroupGetsCreated()
        {
            new Course("course1");
        }

        [TestMethod]
        public void CanCreateTask()
        {
            Course course = new Course("course1");
            course.CreateTask("task1");
        }

        [TestMethod]
        public void CanSubmitTask()
        {
            Course course = new Course("course1");
            Student student = new Student("Student Name", "username1", "password");
            course.SubmitTask("task1", student);
        }

        [TestMethod]
        public void CanGetTask()
        {
            Course course = new Course("course1");
            course.CreateTask("task1");
            string task = course.GetTask();
            Assert.AreEqual("task1", task);
        }
    }
}