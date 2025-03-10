using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ocp
{
    class Example
    {
        #region Wrong 
        public class NotificationManager
        {
            public void SendNotification(string type, string message)
            {
                if (type == "Email")
                {
                    // Логика отправки Email
                }
                else if (type == "SMS")
                {
                    // Логика отправки SMS
                }
            }
        }
        #endregion

        #region Correct
        class CoolerExample
        {
            public interface INotification
            {
                void Send(string message);
            }


            public class EmailNotification : INotification
            {
                public void Send(string message)
                {
                    // Логика отправки Email
                }
            }


            public class SMSNotification : INotification
            {
                public void Send(string message)
                {
                    // Логика отправки SMS
                }
            }


            public class NotificationManager
            {
                private List<INotification> _notifications;


                public NotificationManager(List<INotification> notifications)
                {
                    _notifications = notifications;
                }


                public void SendAll(string message)
                {
                    foreach (var notification in _notifications)
                    {
                        notification.Send(message);
                    }
                }
            }

        }

        #endregion
    }
}
