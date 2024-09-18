using project_console;

namespace unit_test
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TeacherGetsCreated()
        {
            new Teacher("John Doe", "johndoe", "password");
        }

        [TestMethod]
        public void StudentGetsCreated()
        {
            new Student("John Doe", "johndoe", "password");
        }

        [TestMethod]
        public void UserCanSignInWithRightCredentials()
        {
            Student student = new Student("Student Name", "username1", "password");
            Assert.AreEqual(true, student.SignIn("username1", "password"));
            Teacher teacher = new Teacher("Teacher Name", "username2", "password");
            Assert.AreEqual(true, teacher.SignIn("username2", "password"));
        }

        [TestMethod]
        public void UserCantSignInWithWrongCredentials()
        {
            Student student = new Student("Student Name", "username1", "password");
            Assert.AreEqual(false, student.SignIn("username1", "password123"));
            Teacher teacher = new Teacher("Teacher Name", "username2", "password");
            Assert.AreEqual(false, teacher.SignIn("username3", "password"));
        }

        [TestMethod]
        public void UserCanAddChat()
        {
            Student student = new Student("Student Name", "username1", "password");
            Teacher teacher = new Teacher("Teacher Name", "username2", "password");
            Chat chat = new Chat();
            student.AddChat(chat);
            teacher.AddChat(chat);
        }
    }
}