using FrontDesk.SharedKernel.Interfaces;

namespace Scheduling.Core.Application.Services.Interfaces
{
    public interface IMessagePublisher
    {
        void Publish(IApplicationEvent applicationEvent);
    }
}