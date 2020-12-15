using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Queries
{
    public class FriendlyMessageException : Exception
    {
        public string FriendlyMessage { get; }

        public FriendlyMessageException(string friendlyMessage)
        {
            this.FriendlyMessage = friendlyMessage;
        }
    }
}
