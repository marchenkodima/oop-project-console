using project_console;

namespace unit_test
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void GroupGetsCreated()
        {
            new Group("group1");
        }

        [TestMethod]
        public void AdministratorAddsAGroup()
        {
            Group group1 = new Group("group1");
            Administrator admin = new Administrator("John Doe", "johndoe", "password");
            admin.AddGroup(group1);
        }

        [TestMethod]
        public void StudentGetsAttachedToAGroup()
        {
            Group group1 = new Group("group1");
            Student student1 = new Student("Student Name", "username1", "password");
            group1.AttachStudent(student1.Id);
            Assert.AreEqual(1, group1.GetStudents().Count);
            Assert.AreEqual(student1, group1.GetStudents()[0]);
        }

        [TestMethod]
        public void StudentGetsDetachedFromAGroup()
        {
            Group group1 = new Group("group1");
            Student student1 = new Student("Student Name", "username1", "password");
            group1.AttachStudent(student1.Id);
            group1.DetachStudent(student1.Id);
            Assert.AreEqual(0, group1.GetStudents().Count);
        }
    }
}