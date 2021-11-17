using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessenger email = new Email();
            Notification notification1 = new Notification(email, "notification by email");
            IMessenger envelop = new Envelop();
            Notification notification2 = new Notification(envelop, "notification by envelop");
            IMessenger sms = new Sms();
            Notification notification3 = new Notification(sms, "notification by sms");

            List<Notification> notifications = new List<Notification>();

            notifications.Add(notification1);
            notifications.Add(notification2);
            notifications.Add(notification3);

            for (int i = 0; i<notifications.Count; i++)
            {
                notifications[i].Notify();
            }
        }
        public interface IMessenger
        {
            void Send(string message);
        }
        public class Email:IMessenger
        {
            public void Send(string message)
            {
                Console.WriteLine($"sending by email: {message}");
            }
        }
        public class Sms:IMessenger
        {
            public void Send(string message)
            {
                Console.WriteLine($"sending by sms: {message}");
            }
        }
        public class Envelop : IMessenger
        {
            public void Send(string message)
            {
                Console.WriteLine($"sending by envelop: {message}");
            }
        }
        public class Notification
        {
            private readonly IMessenger _messenger;
            private string _message;
            public Notification(IMessenger messenger, string message)
            {
                _messenger = messenger;
                _message = message;
            }
            public void Notify()
            {
                _messenger.Send(_message);
            }
        }
    }
}
