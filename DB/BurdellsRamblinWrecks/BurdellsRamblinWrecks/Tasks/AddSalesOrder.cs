using BurdellsRamblinWrecks.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Tasks
{
    public class AddSalesOrder
    {
        public decimal GetTotalPartsCost(string vin)
        {
            var query = new QueryExecutor();
            return query.QueryPartsCostTotal(vin);
        }

        public void InsertNewSalesOrder(string vin, string customerid, DateTime salesDate, decimal salesPrice, bool loanInsert, decimal downPayment = 0m, string startingMonth = "01/01/1900", int loanTerm = 0, decimal monthlyPayment = 0m, decimal interestRate = 0m)
        {
            var query = new QueryExecutor();
            var currentuser = Tasks.Login.GetLoginTask().CurrentUser;
            DateTime adjustedStartingMonth = default(DateTime);
            try { adjustedStartingMonth = DateTime.Parse(startingMonth); } catch { throw new FriendlyMessageException("Please enter a starting month for the loan in format YYYY-MM."); }
            query.InsertSalesOrder(vin, customerid, currentuser.username, salesDate, salesPrice, loanInsert, downPayment, adjustedStartingMonth, loanTerm, monthlyPayment, interestRate);            
        }
    }
}
