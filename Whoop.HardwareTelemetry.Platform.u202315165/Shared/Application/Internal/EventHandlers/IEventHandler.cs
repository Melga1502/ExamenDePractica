using Cortex.Mediator.Notifications;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Model.Events;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Application.Internal.EventHandlers;

/// <summary>
///     Defines a handler for an integration event.
/// </summary>
/// <typeparam name="TEvent">Integration event type.</typeparam>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
}
