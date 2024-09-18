using project_console;

namespace unit_test
{
    [TestClass]
    public class ChatTests
    {
        [TestMethod]
        public void ChatGetsCreated()
        {
            new Chat();
        }

        [TestMethod]
        public void CanSendMessage()
        {
            Student student = new Student("Student Name", "username1", "password");
            Teacher teacher = new Teacher("Teacher Name", "username2", "password");
            Chat chat = new Chat();
            chat.SendMessage(student, "Hello");
            chat.SendMessage(teacher, "Hi");
        }

        [TestMethod]
        public void GetMessages()
        {
            Student student = new Student("Student Name", "username1", "password");
            Teacher teacher = new Teacher("Teacher Name", "username2", "password");
            Chat chat = new Chat();
            chat.SendMessage(student, "Hello");
            chat.SendMessage(teacher, "Hi");
            List<ChatMessage> messages = chat.GetMessages();
            Assert.AreEqual(2, messages.Count);
        }

        [TestMethod]
        public void DeleteMessages()
        {
            Student student = new Student("Student Name", "username1", "password");
            Teacher teacher = new Teacher("Teacher Name", "username2", "password");
            Chat chat = new Chat();
            chat.SendMessage(student, "Hello");
            chat.SendMessage(teacher, "Hi");

            List<ChatMessage> messages1 = chat.GetMessages();
            chat.DeleteMessage(messages1[0]);
            chat.DeleteMessage(messages1[1]);

            List<ChatMessage> messages2 = chat.GetMessages();
            Assert.AreEqual(0, messages2.Count);
        }
    }
}