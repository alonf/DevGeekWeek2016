using System;

namespace WeakReferenceDemo
{
    class Publisher
    {
        WeakReference _client;

        public void Register(INotify client) { _client = new WeakReference(client); }

        static int _data;

        public void DoSomething()
        {
            _data++;
            Console.WriteLine($"Doing... data = {_data}");
            // notify
            INotify notify = (INotify)_client.Target;
            if (notify != null)
                notify.Notify(_data);
            else
                _client = null;
        }
    }
}