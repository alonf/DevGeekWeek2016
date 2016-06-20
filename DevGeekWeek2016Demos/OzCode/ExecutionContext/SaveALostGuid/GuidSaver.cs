using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SaveALostGuid
{
    public class GuidSaver
    {
        private readonly ConcurrentBag<Guid> _readyToBeSaved = 
            new ConcurrentBag<Guid>();

        private long _savedGuids = 0;
        private long _lostGuids = 0;

        public GuidSaver()
        {
            StartSavingGuids();
        }
        public long SavedGuids
        {
            get { return _savedGuids; }
        }

        public long LostGuids
        {
            get { return _lostGuids; }
        }

        public async void StartSavingGuids()
        {
            await Task.Yield();
            
            while (true)
            {
                if (_readyToBeSaved.Count < 100)
                {
                    _readyToBeSaved.Add(Guid.NewGuid());
                    _savedGuids++;
                }
                else
                {
                    _lostGuids++;
                }
            }
        }

        public Guid GetSavedGuid()
        {
            Guid guid;
            if (_readyToBeSaved.TryTake(out guid))
            {
                return guid;
            }

            _savedGuids++;
            return Guid.NewGuid();
        }
    }
}