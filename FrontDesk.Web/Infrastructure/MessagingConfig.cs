using System.Threading;
using System.Timers;

namespace FrontDesk.Web.Controllers.Infrastructure
{
    public static class MessagingConfig
    {
        internal static void StartCheckingMessages()
        {
            var thread = new Thread(new ThreadStart(StartJob));
            thread.IsBackground = true;
            thread.Name = "ThreadFunc";
            thread.Start();
        }

        private static void StartJob()
        {
            var messageBroker = new MessageBroker();
            var timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(messageBroker.CheckMessages);
            timer.Interval = 5000;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
        }
        private class MessageBroker
        {
            public void CheckMessages(object sender, ElapsedEventArgs e)
            {
                #warning Implement fetching applicationEvent from a messaging queue.
                // Guid appointmentId = queue.GetValue();
                // Scheduling.Infrastructure.ApplicationEvents.AppointmentConfirmedEvent appointmentConfirmedEvent = new Scheduling.Infrastructure.ApplicationEvents.AppointmentConfirmedEvent();
                // DomainEvents.Raise(appointmentConfirmedEvent);
            }
        }
    }
}