using FrontDesk.SharedKernel.Interfaces;

namespace Scheduling.Infrastructure.Services.Interfaces
{
    public interface IMessagePublisher
    {
        void Publish(IApplicationEvent applicationEvent);
    }
}