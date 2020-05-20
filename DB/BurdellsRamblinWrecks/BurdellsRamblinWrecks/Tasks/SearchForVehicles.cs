using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurdellsRamblinWrecks.Entities;
using BurdellsRamblinWrecks.Queries;

namespace BurdellsRamblinWrecks.Tasks
{
    public class SearchForVehicles
    {
        public List<Vehicle> Search(string vehicleTypeId, string colorId, string manufacturerId, string modelYear, string keyword, string vin)
        {
            var query = new QueryExecutor();
            UserRolesEnum userRoles = Tasks.Login.GetLoginTask().GetUserRoles();
            if ((userRoles & UserRolesEnum.Manager) == UserRolesEnum.Manager ||
                     (userRoles & UserRolesEnum.Owner) == UserRolesEnum.Owner ||
                     (userRoles & UserRolesEnum.InventoryClerk) == UserRolesEnum.InventoryClerk)
            {
                return query.SearchForVehiclesPrivateAndPublic(SqlTextAll.queryPriviledgedVehicleSearch, vehicleTypeId, colorId, manufacturerId, modelYear, keyword, vin);
            }
            else if ((userRoles & UserRolesEnum.PublicOnly) == UserRolesEnum.PublicOnly ||
                (userRoles & UserRolesEnum.SalesPerson) == UserRolesEnum.SalesPerson)
            {
                return query.SearchForVehiclesPrivateAndPublic(SqlTextAll.queryPublicVehicleSearch, vehicleTypeId, colorId, manufacturerId, modelYear, keyword, vin);
            }

            //default search will be public
            return query.SearchForVehiclesPrivateAndPublic(SqlTextAll.queryPublicVehicleSearch, vehicleTypeId, colorId, manufacturerId, modelYear, keyword, null);
        }

        public List<Vehicle> SearchSold(string vehicleTypeId, string colorId, string manufacturerId, string modelYear, string keyword, string vin)
        {
            var query = new QueryExecutor();
            return query.SearchForVehiclesPrivateAndPublic(SqlTextAll.queryPublicVehicleSearchPreviouslySold, vehicleTypeId, colorId, manufacturerId, modelYear, keyword, vin);
        }

        public List<Vehicle> SearchPublicOnly(string vehicleTypeId, string colorId, string manufacturerId, string modelYear, string keyword, string vin)
        {
            var query = new QueryExecutor();
            return query.SearchForVehiclesPrivateAndPublic(SqlTextAll.queryPublicVehicleSearch, vehicleTypeId, colorId, manufacturerId, modelYear, keyword, null);
        }


        public List<Manufacturer> GetManufacturers()
        {
            var query = new QueryExecutor();
            return query.QueryManufacturers().OrderBy(m => m.ManufacturerId).ToList();
        }

        public List<VehicleColor> GetColors()
        {
            var query = new QueryExecutor();
            return query.QueryColors().OrderBy(c => c.ColorId).ToList();
        }

        public List<VehicleType> GetVehicleTypes()
        {
            var query = new QueryExecutor();
            return query.QueryVehicleTypes().OrderBy(vt => vt.VehicleTypeId).ToList();
        }

        public int GetTotalVehiclesPartsPending()
        {
            var query = new QueryExecutor();
            return query.QueryTotalVehiclesWithPartsPending();
        }
    }
}