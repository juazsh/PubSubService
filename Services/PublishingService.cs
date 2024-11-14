using PubSubService.Events;

namespace PubSubService.Services;

public class PublishingService
{
    private readonly EventQueue _eventQueue;

    public PublishingService(EventQueue eventQueue) => _eventQueue = eventQueue;

    public void Publish(string message) =>  _eventQueue.Publish(message);
    
}