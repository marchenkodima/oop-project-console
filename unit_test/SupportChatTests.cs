using project_console;

namespace unit_test
{
    [TestClass]
    public class SupportChatTests
    {
        [TestMethod]
        public void ChatGetsCreated()
        {
            Student student = new Student("Student Name", "username1", "password");
            Administrator admin = new Administrator("Admin Name", "username2", "password");
            SupportChat chat = new SupportChat(student.Id, admin.Id);
            Assert.AreEqual(student.Id, chat.StudentId);
            Assert.AreEqual(admin.Id, chat.AdministratorId);
        }

        [TestMethod]
        public void UserSendsMessage()
        {
            Student student = new Student("Student Name", "username1", "password");
            Administrator admin = new Administrator("Admin Name", "username2", "password");
            SupportChat chat = new SupportChat(student.Id, admin.Id);
            chat.SendMessage(student.Id, "Hello");
            chat.SendMessage(admin.Id, "Hi");
        }

        [TestMethod]
        public void GetMessages()
        {
            Student student = new Student("Student Name", "username1", "password");
            Administrator admin = new Administrator("Admin Name", "username2", "password");
            SupportChat chat = new SupportChat(student.Id, admin.Id);
            chat.SendMessage(student.Id, "Hello");
            chat.SendMessage(admin.Id, "Hi");

            List<ChatMessage> messages = chat.GetMessages();
            Assert.AreEqual(2, messages.Count);

            Assert.AreEqual("Hello", messages[0].Message);
            Assert.AreEqual(chat.Id, messages[0].ChatId);
            Assert.AreEqual(student.Id, messages[0].SenderId);

            Assert.AreEqual("Hi", messages[1].Message);
            Assert.AreEqual(chat.Id, messages[1].ChatId);
            Assert.AreEqual(admin.Id, messages[1].SenderId);
        }

        [TestMethod]
        public void DeleteMessages()
        {
            Student student = new Student("Student Name", "username1", "password");
            Administrator admin = new Administrator("Admin Name", "username2", "password");
            SupportChat chat = new SupportChat(student.Id, admin.Id);
            chat.SendMessage(student.Id, "Hello");
            chat.SendMessage(admin.Id, "Hi");

            List<ChatMessage> messages1 = chat.GetMessages();
            chat.DeleteMessage(messages1[0].Id);
            chat.DeleteMessage(messages1[1].Id);

            List<ChatMessage> messages2 = chat.GetMessages();
            Assert.AreEqual(0, messages2.Count);
        }

        [TestMethod]
        public void StudentCanContactSupport()
        {
            Student student = new Student("Student Name", "username1", "password");
            student.ContactSupport();
        }
    }
}