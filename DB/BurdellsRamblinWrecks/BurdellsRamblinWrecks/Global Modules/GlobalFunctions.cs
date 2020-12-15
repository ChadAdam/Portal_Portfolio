using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BurdellsRamblinWrecks.Logging.DiagnosticLog;

namespace BurdellsRamblinWrecks.Global_Modules
{
    class GlobalFunctions
    {
        public enum entLogTypes
        {
            eAlarm,
            eEvent,
            eMessage,
            eNote,
            eSQLQuery
        }
        public static void Log(string sMessage, entLogTypes LogType)
        {
            string sFinalMessage = "";
            switch (LogType)
            {
                case entLogTypes.eAlarm:
                    sFinalMessage = $"ALARM: {sMessage}";
                    break;
                case entLogTypes.eEvent:
                    sFinalMessage = $"EVENT: {sMessage}";
                    break;
                case entLogTypes.eMessage:
                    sFinalMessage = $"MESSAGE: {sMessage}";
                    break;
                case entLogTypes.eNote:
                    sFinalMessage = $"NOTE: {sMessage}";
                    break;
                case entLogTypes.eSQLQuery:
                    sFinalMessage = $"SQL QUERY: {sMessage}";
                    break;

            }
            Logging.DiagnosticLog.Log(sFinalMessage);
        }
    }
}
