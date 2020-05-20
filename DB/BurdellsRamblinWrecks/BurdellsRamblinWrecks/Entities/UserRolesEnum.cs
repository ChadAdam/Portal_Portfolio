using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Entities
{
    [Flags]
    public enum UserRolesEnum
    {
        PublicOnly = 1,
        SalesPerson = 2,
        InventoryClerk = 4,
        Manager = 8,
        Owner = 16
    }
}
