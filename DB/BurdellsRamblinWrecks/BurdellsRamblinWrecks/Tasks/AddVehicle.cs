using BurdellsRamblinWrecks.Entities;
using BurdellsRamblinWrecks.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Tasks
{
    public class AddVehicle
    {
        public List<Condition> GetConditions()
        {
            var query = new QueryExecutor();
            return query.QueryConditions();
        }

        public Vehicle InsertNewVehicle(string vin, string model_name, string model_year, string mileage, string description, DateTime purchase_date, decimal purchase_price, string vehicleTypeId,
            string manufacturerId, List<string> colorIds, string conditionId, string customerId)
        {
            var query = new QueryExecutor();
            var currentuser = Tasks.Login.GetLoginTask().CurrentUser;
            query.InsertVehiclePurchase(vin, model_name, model_year, mileage, description, purchase_date, purchase_price, vehicleTypeId, manufacturerId, colorIds, conditionId, customerId, currentuser.username);

            // there are no calculated fields so we can just return a constructed object
            return new Vehicle()
            {
                VIN = vin,
                vehicleTypeId = vehicleTypeId,
                model_year = model_year,
                manufacturerId = manufacturerId,
                model_name = model_name,
                color = colorIds.Aggregate((color1, color2) => color1 + "," + color2),
                mileage = mileage,
                purchase_price = purchase_price,
                description = description
            };
        }

    }
}
