using ClassLibrary1;
using System.Collections.ObjectModel;

namespace unit_test
{
    [TestClass]
    public class ChatTests
    {
        [TestMethod]
        public void ChatGetsCreated()
        {
            new Chat("chat 1");
        }

        [TestMethod]
        public void CanSendMessage()
        {
            Student student = new Student("Student Name", "username1", "password", "fac1");
            Teacher teacher = new Teacher("Teacher Name", "username2", "password");
            Chat chat = new Chat("chat 1");
            chat.SendMessage(new TextChatMessage(student.Id, "Hello"));
            chat.SendMessage(new TextChatMessage(teacher.Id, "Hi"));
        }

        [TestMethod]
        public void GetMessages()
        {
            Student student = new Student("Student Name", "username1", "password", "fac1");
            Teacher teacher = new Teacher("Teacher Name", "username2", "password");
            Chat chat = new Chat("chat 1");
            chat.SendMessage(new TextChatMessage(student.Id, "Hello"));
            chat.SendMessage(new TextChatMessage(teacher.Id, "Hi"));
            ObservableCollection<ChatMessage> messages = chat.Messages;
            Assert.AreEqual(2, messages.Count);
        }

        [TestMethod]
        public void DeleteMessages()
        {
            Student student = new Student("Student Name", "username1", "password", "fac1");
            Teacher teacher = new Teacher("Teacher Name", "username2", "password");
            Chat chat = new Chat("chat 1");
            chat.SendMessage(new TextChatMessage(student.Id, "Hello"));
            chat.SendMessage(new TextChatMessage(teacher.Id, "Hi"));

            ObservableCollection<ChatMessage> messages1 = chat.Messages;
            chat.DeleteMessage(messages1[0]);
            chat.DeleteMessage(messages1[0]);

            ObservableCollection<ChatMessage> messages2 = chat.Messages;
            Assert.AreEqual(0, messages2.Count);
        }
    }
}