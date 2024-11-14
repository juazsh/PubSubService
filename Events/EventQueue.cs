using System;
using System.Collections.Concurrent;

namespace PubSubService.Events;

public class EventQueue
{
    private readonly BlockingCollection<string> _queue = new();

    public void Publish(string message) => _queue.Add(message);
    

    public string Subscribe() => _queue.Take();
}