using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Infrastructure.Services.Interfaces;

namespace Scheduling.Infrastructure
{
    public class ServiceBrokerMessagePublisher : IMessagePublisher
    {
        public ServiceBrokerMessagePublisher()
        {
            #warning List dependencies needed to send the applicationEvent to some messaging queue.
        }

        public void Publish(IApplicationEvent applicationEvent)
        {
            #warning Implement publishing applicationEvent to a messaging queue.
            #warning Send event to queue as JSON.
        }
    }
}