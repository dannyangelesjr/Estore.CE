using System;

namespace Estore.Ce.Contracts
{
    public interface IBaseSyncService
    {
        event Action<int, int> RecordUpdated;
        event Action<string> StatusUpdated;        

        void Sync();
    }
}
