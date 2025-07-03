using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Contracts;
using System.Windows.Forms;

namespace Estore.Ce.Services
{
    public abstract class BaseSyncService : IBaseSyncService
    {
        public event Action<string> StatusUpdated;
        public event Action<int, int> RecordUpdated;

        public abstract void Sync();

        public void UpdateStatus(string message)
        {
            if (StatusUpdated != null)
            {
                StatusUpdated(message);
                Application.DoEvents();
            }
        }

        public void UpdateProgressBar(int recordsFound, int recordsUpdated)
        {
            if (RecordUpdated != null)
            {
                RecordUpdated(recordsFound, recordsUpdated);
                Application.DoEvents();
            }
        }
    }
}
