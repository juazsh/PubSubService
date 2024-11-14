using PubSubService.Events;

namespace PubSubService.Services;

public class SubscribingService
{
    private readonly EventQueue _eventQueue;
    
    public SubscribingService(EventQueue eventQueue) => _eventQueue = eventQueue;

    public string Receive() => _eventQueue.Subscribe();
}