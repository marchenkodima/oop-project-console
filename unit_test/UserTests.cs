using project_console;

namespace unit_test
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void AdministratorGetsCreated()
        {
            new Administrator("John Doe", "johndoe", "password");
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
            Administrator admin = new Administrator("Admin Name", "username2", "password");
            Assert.AreEqual(true, admin.SignIn("username2", "password"));
        }

        [TestMethod]
        public void UserCantSignInWithWrongCredentials()
        {
            Student student = new Student("Student Name", "username1", "password");
            Assert.AreEqual(false, student.SignIn("username1", "password123"));
            Administrator admin = new Administrator("Admin Name", "username2", "password");
            Assert.AreEqual(false, admin.SignIn("username3", "password"));
        }

        [TestMethod]
        public void AdministratorCreatesAUser()
        {
            Administrator admin = new Administrator("John Doe", "johndoe", "password");
            admin.AddAdministrator(new Administrator("Admin Name", "username1", "password"));
            admin.AddStudent(new Student("Student Name", "username2", "password"));
        }

        [TestMethod]
        public void AdministratorGetsUsers()
        {
            Administrator admin = new Administrator("John Doe", "johndoe", "password");

            Student student1 = new Student("User Name", "username1", "password1");
            Student student2 = new Student("User Name", "username2", "password1");
            Student student3 = new Student("User Name", "username3", "password1");
            Administrator admin1 = new Administrator("User Name", "username4", "password1");
            Administrator admin2 = new Administrator("User Name", "username5", "password1");

            admin.AddStudent(student1);
            admin.AddStudent(student2);
            admin.AddStudent(student3);
            admin.AddAdministrator(admin1);
            admin.AddAdministrator(admin2);

            List<Student> receivedStudents = admin.GetStudents();
            List<Administrator> receivedAdmins = admin.GetAdministrators();
            Assert.AreEqual(3, receivedStudents.Count);
            Assert.AreEqual(2, receivedAdmins.Count);

            List<Student> addedStudents = new List<Student>() { student1, student2, student3 };
            List<Administrator> addedAdmins = new List<Administrator>() { admin1, admin2 };
            CollectionAssert.AreEquivalent(addedStudents, receivedStudents);
            CollectionAssert.AreEquivalent(addedAdmins, receivedAdmins);
        }

        [TestMethod]
        public void AdministratorDeletesAUser()
        {
            Administrator admin = new Administrator("John Doe", "johndoe", "password");
            admin.AddAdministrator(new Administrator("Admin Name", "username1", "password"));
            admin.AddStudent(new Student("Student Name", "username2", "password"));
            admin.DeleteUser("username1");
            admin.DeleteUser("username2");
            Assert.AreEqual(0, admin.GetAdministrators().Count);
            Assert.AreEqual(0, admin.GetStudents().Count);
        }
    }
}