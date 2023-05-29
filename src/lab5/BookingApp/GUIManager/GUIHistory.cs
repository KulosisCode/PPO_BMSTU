using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIManager
{
    public class GUIHistory
    {
        StaffManager staffManager;
        RequestManager requestManager;
        HistoryManager historyManager;

        public GUIHistory(StaffManager staffManager, RequestManager requestManager, HistoryManager historyManager)
        {
            this.staffManager = staffManager;
            this.requestManager = requestManager;
            this.historyManager = historyManager;
        }
    }
}
