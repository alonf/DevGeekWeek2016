using System;

namespace WeakReferenceDemo
{
    class Subscriber : INotify
    {
        public void Notify(object data)
        {
            Console.WriteLine($"Received notification: {data}");
        }
    }
}