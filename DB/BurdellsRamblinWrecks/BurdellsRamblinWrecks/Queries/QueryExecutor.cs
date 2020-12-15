using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurdellsRamblinWrecks.Entities;
using BurdellsRamblinWrecks.Forms;
using Npgsql;

using System.Globalization;
using static BurdellsRamblinWrecks.Global_Modules.GlobalFunctions;

namespace BurdellsRamblinWrecks.Queries
{
    /// <summary>
    /// ALL SQL Queries in a single file as requested by assignment instructions.
    /// </summary>
    public class QueryExecutor
    {
        private readonly string conn_string = "Server=cs6400db.ryan-moore.dev; Port=5432; User Id = DBUser; Password=group003; Database=CS6400";

        public PriviledgedUser AuthenticateUser(string user_name, string claimed_password)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.queryAuthenticateUserSQL, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("username_param", NpgsqlTypes.NpgsqlDbType.Varchar, user_name);

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows)
                            {
                                string password_from_db = reader.GetString(reader.GetOrdinal("password"));
                                if (string.Compare(claimed_password, password_from_db, StringComparison.Ordinal) == 0)
                                {
                                    PriviledgedUser priviledgedUser = new PriviledgedUser();
                                    priviledgedUser.username = user_name;
                                    priviledgedUser.first_name = reader.GetString(reader.GetOrdinal("first_name"));
                                    priviledgedUser.last_name = reader.GetString(reader.GetOrdinal("last_name"));
                                    return priviledgedUser;
                                }
                                else
                                {
                                    // user's password does not match 
                                    return null;
                                }
                            }
                            else
                            {
                                // no user found in the db with this username
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Authenticate. The Following Error Occurred: {e.Message}.", entLogTypes.eAlarm);
            }
            return null;
        }

        public UserRolesEnum QueryUserRoles(string user_name)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.queryUserRolesSQL, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("username_param", NpgsqlTypes.NpgsqlDbType.Varchar, user_name);

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows)
                            {
                                var colSchema = reader.GetColumnSchema();
                                string salesRole = reader.IsDBNull(reader.GetOrdinal("salesperson")) ? null : reader.GetString(reader.GetOrdinal("salesperson"));
                                string inventoryClerkRole = reader.IsDBNull(reader.GetOrdinal("inventoryclerk")) ? null : reader.GetString(reader.GetOrdinal("inventoryclerk"));
                                string managerRole = reader.IsDBNull(reader.GetOrdinal("manager")) ? null : reader.GetString(reader.GetOrdinal("manager"));
                                string ownerRole = reader.IsDBNull(reader.GetOrdinal("owner")) ? null : reader.GetString(reader.GetOrdinal("owner"));

                                UserRolesEnum assignedUserRoles = UserRolesEnum.PublicOnly;
                                if (!string.IsNullOrWhiteSpace(salesRole))
                                {
                                    assignedUserRoles &= ~UserRolesEnum.PublicOnly;
                                    assignedUserRoles = assignedUserRoles | UserRolesEnum.SalesPerson;
                                }
                                if (!string.IsNullOrWhiteSpace(inventoryClerkRole))
                                {
                                    assignedUserRoles &= ~UserRolesEnum.PublicOnly;
                                    assignedUserRoles = assignedUserRoles | UserRolesEnum.InventoryClerk;
                                }
                                if (!string.IsNullOrWhiteSpace(managerRole))
                                {
                                    assignedUserRoles &= ~UserRolesEnum.PublicOnly;
                                    assignedUserRoles = assignedUserRoles | UserRolesEnum.Manager;
                                }
                                if (!string.IsNullOrWhiteSpace(ownerRole))
                                {
                                    assignedUserRoles &= ~UserRolesEnum.PublicOnly;
                                    assignedUserRoles = assignedUserRoles | UserRolesEnum.Owner;
                                }
                                return assignedUserRoles;
                            }
                            else
                            {
                                // no user roles found, this user is mis-configured and doesn't have assigned roles
                                return UserRolesEnum.PublicOnly;
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Log($"Could Not Query User Roles. The Following Error Occurred: {e.Message}.", entLogTypes.eAlarm);
            }
            return UserRolesEnum.PublicOnly; //If we get here, return public
        }

        public List<Manufacturer> QueryManufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.queryManufacturer, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                manufacturers.Add(new Manufacturer() { ManufacturerId = reader.GetString(reader.GetOrdinal("ManufacturerId")) });
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Query Manufacturers Due To the Following Exception: {e.Message}", entLogTypes.eAlarm);
                manufacturers = null;

            }

            return manufacturers;
        }

        public List<VehicleColor> QueryColors()
        {
            List<VehicleColor> vehicleColors = new List<VehicleColor>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.queryColor, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vehicleColors.Add(new VehicleColor() { ColorId = reader.GetString(reader.GetOrdinal("ColorId")) });
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Query Colors Due To The Following: {e.Message}", entLogTypes.eAlarm);
            }
            return vehicleColors;
        }

        public List<VehicleType> QueryVehicleTypes()
        {
            List<VehicleType> vehicleTypes = new List<VehicleType>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.queryVehicleType, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vehicleTypes.Add(new VehicleType() { VehicleTypeId = reader.GetString(reader.GetOrdinal("VehicleTypeId")) });
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Query Vehicle Types Due To The Following: {e.Message}", entLogTypes.eAlarm);
            }
            return vehicleTypes;
        }

        public List<Vehicle> SearchForVehiclesPrivateAndPublic(string sqlText, string vehicleTypeId, string colorId, string manufacturerId, string modelYear, string keyword, string vin)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(sqlText, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        if (vehicleTypeId == null) { cmd.Parameters.AddWithValue("vehicleTypeId", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                        else { cmd.Parameters.AddWithValue("vehicleTypeId", NpgsqlTypes.NpgsqlDbType.Varchar, vehicleTypeId); }

                        if (manufacturerId == null) { cmd.Parameters.AddWithValue("manufacturerId", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                        else { cmd.Parameters.AddWithValue("manufacturerId", NpgsqlTypes.NpgsqlDbType.Varchar, manufacturerId); }

                        if (string.IsNullOrWhiteSpace(modelYear)) { cmd.Parameters.AddWithValue("model_year", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                        else { cmd.Parameters.AddWithValue("model_year", NpgsqlTypes.NpgsqlDbType.Varchar, modelYear); }

                        if (colorId == null) { cmd.Parameters.AddWithValue("color", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                        else { cmd.Parameters.AddWithValue("color", NpgsqlTypes.NpgsqlDbType.Varchar, colorId); }

                        if (string.IsNullOrWhiteSpace(keyword)) { cmd.Parameters.AddWithValue("keyword", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                        else { cmd.Parameters.AddWithValue("keyword", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + keyword + "%"); }

                        if (string.IsNullOrWhiteSpace(vin)) { cmd.Parameters.AddWithValue("vin", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                        else { cmd.Parameters.AddWithValue("vin", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + vin + "%"); }

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var newVehicle = new Vehicle()
                                {
                                    VIN = reader.GetString(reader.GetOrdinal("VIN")),
                                    model_name = reader.GetString(reader.GetOrdinal("model_name")),
                                    model_year = reader.GetString(reader.GetOrdinal("model_year")),
                                    mileage = reader.GetString(reader.GetOrdinal("mileage")),
                                    vehicleTypeId = reader.GetString(reader.GetOrdinal("vehicleTypeId")),
                                    manufacturerId = reader.GetString(reader.GetOrdinal("manufacturerId")),
                                    description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),
                                    purchase_price = reader.GetDecimal(reader.GetOrdinal("purchase_price")),
                                    color = reader.IsDBNull(reader.GetOrdinal("color")) ? null : reader.GetString(reader.GetOrdinal("color")),
                                    total_parts_cost = reader.IsDBNull(reader.GetOrdinal("total_parts_cost")) ? 0m : reader.GetDecimal(reader.GetOrdinal("total_parts_cost")),
                                };
                                vehicles.Add(newVehicle);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Serch For Vehicles Due To The Follwing: {e.Message}", entLogTypes.eAlarm);
            }

            return vehicles;
        }

        public List<Tuple<String, String>> GenerateAverageTimeInInventoryReport()
        {
            var results = new List<Tuple<String, String>>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.avgTimeInInventoryQuery, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                String vehicleType = reader.GetValue(reader.GetOrdinal("vehicleTypeId")).ToString();
                                Double avgTemp = reader.GetDouble(reader.GetOrdinal("avgTime"));
                                String avgTime;
                                if (avgTemp == 0)
                                {
                                    avgTime = "N/A";
                                }
                                else
                                {
                                    avgTime = avgTemp.ToString("0.00");
                                }
                                results.Add(Tuple.Create(vehicleType, avgTime));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Generate Average Time In Inventory Report Due To The Following: {e.Message}", entLogTypes.eAlarm);
            }

            return results;
        }

        public List<Tuple<String, short, String>> GeneratePartsStatisticsReport()
        {
            var results = new List<Tuple<String, short, String>>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.partsStatisticsQuery, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(Tuple.Create(reader.GetString(reader.GetOrdinal("Vendor_name")), reader.GetInt16(reader.GetOrdinal("num_of_parts")), Math.Round(reader.GetDouble(reader.GetOrdinal("avgCost")),2).ToString("C")));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Generate Parts Statistics Report Due To The Following: {e.Message}", entLogTypes.eAlarm);
            }

            return results;
        }

        public List<Tuple<String, String, String, String>> GenerateMonthlyLoanIncomeReport()
        {
            var results = new List<Tuple<String, String, String, String>>();
            try
            {
                for (int i = 0; i < 12; i++)
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                    {
                        using (var cmd = new NpgsqlCommand(SqlTextAll.MSIncomeQuery, conn))
                        {
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Parameters.AddWithValue("loop_param", NpgsqlTypes.NpgsqlDbType.Numeric, i);

                            conn.Open();
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    String month = reader.GetString(reader.GetOrdinal("month"));
                                    String year = reader.GetValue(reader.GetOrdinal("year")).ToString();
                                    double dbltotal_payment = Math.Round(reader.GetDouble(reader.GetOrdinal("total_payment")), 2);
                                    String total_payment = Math.Round(reader.GetDouble(reader.GetOrdinal("total_payment")), 2).ToString("C");
                                    String monthly_income = Math.Round(dbltotal_payment * 0.01, 2).ToString("C");
                                    results.Add(Tuple.Create(month, year, total_payment, monthly_income));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Generate Monthly Sales Income Report Due To The Following: {e.Message}", entLogTypes.eAlarm);
            }

            return results;
        }

        public List<Reports.ReportClasses.MonthlySalesReport> GenerateMonthlySalesReport()
        {
            List<Reports.ReportClasses.MonthlySalesReport> results = new List<Reports.ReportClasses.MonthlySalesReport>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.MSQuery, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var tempResult = new Reports.ReportClasses.MonthlySalesReport();
                                tempResult.sales_month = reader.GetValue(reader.GetOrdinal("sales_month")).ToString();
                                tempResult.sales_year = reader.GetValue(reader.GetOrdinal("sales_year")).ToString();
                                tempResult.vehicle_amt = reader.GetValue(reader.GetOrdinal("vehicle_amt")).ToString();
                                tempResult.sales_income = reader.GetDouble(reader.GetOrdinal("sales_income")).ToString();
                                tempResult.net_income = reader.GetDouble(reader.GetOrdinal("net_income")).ToString();
                                results.Add(tempResult);
                            }
                        }
                    }
                }

                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.MSQuery1, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var parts_cost = reader.GetDouble(reader.GetOrdinal("cost_2")).ToString();
                                var month = reader.GetValue(reader.GetOrdinal("sales_month")).ToString();
                                var year = reader.GetValue(reader.GetOrdinal("sales_year")).ToString();
                                foreach (var result in results)
                                {
                                    if (result.sales_month == month && result.sales_year == year)
                                    {
                                        double net_income = Convert.ToDouble(result.net_income);
                                        double final_income = net_income - Convert.ToDouble(parts_cost);
                                        result.net_income = final_income.ToString();
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (var result in results)
                {
                    var month_num = Convert.ToInt32(result.sales_month);
                    result.sales_month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month_num);
                    result.sales_income = String.Format("{0:C}", Convert.ToDouble(result.sales_income));
                    result.net_income = String.Format("{0:C}", Convert.ToDouble(result.net_income));
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Generate Monthly Sales Report Due To The Following: {e.Message}", entLogTypes.eAlarm);
            }

            return results;
        }

        public List<Reports.ReportClasses.MonthlySalesDrilldownReport> GenerateMonthlySalesDrilldownReport(Reports.ReportClasses.MonthlySalesReport inputDetails)
        {
            List<Reports.ReportClasses.MonthlySalesDrilldownReport> results = new List<Reports.ReportClasses.MonthlySalesDrilldownReport>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.MSDrilldownQuery, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        Double inputMonth = DateTime.ParseExact(inputDetails.sales_month.Trim(), "MMMM", CultureInfo.CurrentCulture).Month;
                        Double inputYear = Convert.ToDouble(inputDetails.sales_year);
                        cmd.Parameters.AddWithValue("month_param", NpgsqlTypes.NpgsqlDbType.Double, inputMonth);
                        cmd.Parameters.AddWithValue("year_param", NpgsqlTypes.NpgsqlDbType.Double, inputYear);


                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var tempResult = new Reports.ReportClasses.MonthlySalesDrilldownReport();
                                tempResult.spname = reader.GetValue(reader.GetOrdinal("spname")).ToString();
                                tempResult.sales_month = inputDetails.sales_month;
                                tempResult.sales_year = inputDetails.sales_year;
                                tempResult.vehicle_amt = reader.GetValue(reader.GetOrdinal("vehicle_amt")).ToString();
                                tempResult.total_sales = reader.GetDouble(reader.GetOrdinal("total_sales")).ToString("C");
                                results.Add(tempResult);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Generate Monthly Sales Report Due To The Following: {e.Message}", entLogTypes.eAlarm);
            }

            return results;
        }

        public List<Reports.ReportClasses.PricePerConditionReport> GeneratePricePerConditionReport()
        {
            List<Reports.ReportClasses.PricePerConditionReport> reportList = new List<Reports.ReportClasses.PricePerConditionReport>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.pricePerConditionQuery, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var results = new Reports.ReportClasses.PricePerConditionReport();
                                results.VehicleType = reader.GetString(reader.GetOrdinal("vehicle_type")).ToString();
                                results.cExcellent = reader.GetDouble(reader.GetOrdinal("Excellent")).ToString("C");
                                results.cVeryGood = reader.GetDouble(reader.GetOrdinal("Very Good")).ToString("C");
                                results.cGood = reader.GetDouble(reader.GetOrdinal("Good")).ToString("C");
                                results.cFair = reader.GetDouble(reader.GetOrdinal("Fair")).ToString("C");
                                reportList.Add(results);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Generate Price Per Condition Report Due To The Following: {e.Message}", entLogTypes.eAlarm);
            }

            return reportList;
        }

        //----
        public List<Customer> SearchForCustomers(string sqlText, string phone_number, string email, string address_street, string address_state, string address_postal_code, string address_city, string tax_identification_number, string business_name, string primary_contact_title, string primary_contact_first_name, string primary_contact_last_name, string drivers_license_number, string first_name, string last_name, bool individual)
        {
            List<Customer> customers = new List<Customer>();

            using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
            {
                using (var cmd = new NpgsqlCommand(sqlText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    if (string.IsNullOrWhiteSpace(phone_number)) { cmd.Parameters.AddWithValue("phone_number", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("phone_number", NpgsqlTypes.NpgsqlDbType.Varchar, phone_number); }

                    if (string.IsNullOrWhiteSpace(email)) { cmd.Parameters.AddWithValue("email", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("email", NpgsqlTypes.NpgsqlDbType.Varchar, email); }

                    if (string.IsNullOrWhiteSpace(address_street)) { cmd.Parameters.AddWithValue("address_street", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("address_street", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + address_street + "%"); }

                    if (string.IsNullOrWhiteSpace(address_state)) { cmd.Parameters.AddWithValue("address_state", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("address_state", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + address_state + "%"); }

                    if (string.IsNullOrWhiteSpace(address_postal_code)) { cmd.Parameters.AddWithValue("address_postal_code", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("address_postal_code", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + address_postal_code + "%"); }

                    if (string.IsNullOrWhiteSpace(address_city)) { cmd.Parameters.AddWithValue("address_city", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("address_city", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + address_city + "%"); }

                    if (string.IsNullOrWhiteSpace(drivers_license_number)) { cmd.Parameters.AddWithValue("drivers_license_number", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("drivers_license_number", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + drivers_license_number + "%"); }

                    if (string.IsNullOrWhiteSpace(tax_identification_number)) { cmd.Parameters.AddWithValue("tax_identification_number", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("tax_identification_number", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + tax_identification_number + "%"); }

                    if (string.IsNullOrWhiteSpace(business_name)) { cmd.Parameters.AddWithValue("business_name", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("business_name", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + business_name + "%"); }

                    if (string.IsNullOrWhiteSpace(primary_contact_title)) { cmd.Parameters.AddWithValue("primary_contact_title", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("primary_contact_title", NpgsqlTypes.NpgsqlDbType.Varchar, primary_contact_title); }

                    if (string.IsNullOrWhiteSpace(primary_contact_first_name)) { cmd.Parameters.AddWithValue("primary_contact_first_name", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("primary_contact_first_name", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + primary_contact_first_name + "%"); }

                    if (string.IsNullOrWhiteSpace(primary_contact_last_name)) { cmd.Parameters.AddWithValue("primary_contact_last_name", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("primary_contact_last_name", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + primary_contact_last_name + "%"); }

                    if (string.IsNullOrWhiteSpace(first_name)) { cmd.Parameters.AddWithValue("first_name", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("first_name", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + first_name + "%"); }

                    if (string.IsNullOrWhiteSpace(last_name)) { cmd.Parameters.AddWithValue("last_name", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("last_name", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + last_name + "%"); }

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!individual)
                            {
                                var newCustomer = new Customer()
                                {
                                    phone_number = reader.GetString(reader.GetOrdinal("phone_number")),
                                    email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email")),
                                    address_street = reader.GetString(reader.GetOrdinal("address_street")),
                                    address_state = reader.GetString(reader.GetOrdinal("address_state")),
                                    address_postal_code = reader.GetString(reader.GetOrdinal("address_postal_code")),
                                    address_city = reader.GetString(reader.GetOrdinal("address_city")),
                                    customerID = reader.GetString(reader.GetOrdinal("customerID")),
                                    primary_contact_title = reader.GetString(reader.GetOrdinal("primary_contact_title")),
                                    primary_contact_first_name = reader.GetString(reader.GetOrdinal("primary_contact_first_name")),
                                    primary_contact_last_name = reader.GetString(reader.GetOrdinal("primary_contact_last_name")),
                                    tax_identification_number = reader.GetString(reader.GetOrdinal("tax_identification_number")),
                                    business_name = reader.GetString(reader.GetOrdinal("business_name")),
                                    IsBusiness = true
                                };
                                customers.Add(newCustomer);
                            }
                            else
                            {
                                var newCustomer = new Customer()
                                {
                                    phone_number = reader.GetString(reader.GetOrdinal("phone_number")),
                                    email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email")),
                                    address_street = reader.GetString(reader.GetOrdinal("address_street")),
                                    address_state = reader.GetString(reader.GetOrdinal("address_state")),
                                    address_postal_code = reader.GetString(reader.GetOrdinal("address_postal_code")),
                                    address_city = reader.GetString(reader.GetOrdinal("address_city")),
                                    customerID = reader.GetString(reader.GetOrdinal("customerID")),
                                    first_name = reader.GetString(reader.GetOrdinal("first_name")),
                                    last_name = reader.GetString(reader.GetOrdinal("last_name")),
                                    drivers_license_number = reader.GetString(reader.GetOrdinal("drivers_license_number")),
                                    IsBusiness = false
                                };
                                customers.Add(newCustomer);
                            }
                        }
                    }
                }
            }

            return customers;
        }

        public Customer InsertCustomer(string customerid, string phone_number, string email, string address_street, string address_state, string address_postal_code, string address_city, string tax_identification_number, string business_name, string primary_contact_title, string primary_contact_first_name, string primary_contact_last_name, string drivers_license_number, string first_name, string last_name, bool individual)
        {
            string individualOrBusinessInsert = individual ? SqlTextAll.insertIndividual : SqlTextAll.insertBusiness;

            using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (NpgsqlTransaction trans = conn.BeginTransaction())
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.insertCustomer, conn, trans))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("customerid", NpgsqlTypes.NpgsqlDbType.Varchar, customerid);
                        cmd.Parameters.AddWithValue("phone_number", NpgsqlTypes.NpgsqlDbType.Varchar, phone_number);

                        if (string.IsNullOrWhiteSpace(email)) { cmd.Parameters.AddWithValue("email", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                        else { cmd.Parameters.AddWithValue("email", NpgsqlTypes.NpgsqlDbType.Varchar, email); }

                        cmd.Parameters.AddWithValue("address_street", NpgsqlTypes.NpgsqlDbType.Varchar, address_street);
                        cmd.Parameters.AddWithValue("address_state", NpgsqlTypes.NpgsqlDbType.Varchar, address_state);
                        cmd.Parameters.AddWithValue("address_postal_code", NpgsqlTypes.NpgsqlDbType.Varchar, address_postal_code);
                        cmd.Parameters.AddWithValue("address_city", NpgsqlTypes.NpgsqlDbType.Varchar, address_city);

                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = new NpgsqlCommand(individualOrBusinessInsert, conn, trans))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        if (individual)
                        {
                            cmd.Parameters.AddWithValue("customerid", NpgsqlTypes.NpgsqlDbType.Varchar, customerid);
                            cmd.Parameters.AddWithValue("drivers_license_number", NpgsqlTypes.NpgsqlDbType.Varchar, drivers_license_number);
                            cmd.Parameters.AddWithValue("first_name", NpgsqlTypes.NpgsqlDbType.Varchar, first_name);
                            cmd.Parameters.AddWithValue("last_name", NpgsqlTypes.NpgsqlDbType.Varchar, last_name);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Npgsql.PostgresException ex)
                            {
                                if (ex != null && ex.SqlState != null && ex.SqlState.Equals("23505"))
                                {
                                    try { trans.Rollback(); } catch { }
                                    throw new FriendlyMessageException("Sorry, it looks like a customer with this Driver's License Number already exists. Please search again or check the License Number.");
                                }
                            }
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("customerid", NpgsqlTypes.NpgsqlDbType.Varchar, customerid);
                            cmd.Parameters.AddWithValue("tax_identification_number", NpgsqlTypes.NpgsqlDbType.Varchar, tax_identification_number);
                            cmd.Parameters.AddWithValue("business_name", NpgsqlTypes.NpgsqlDbType.Varchar, business_name);
                            cmd.Parameters.AddWithValue("primary_contact_title", NpgsqlTypes.NpgsqlDbType.Varchar, primary_contact_title);
                            cmd.Parameters.AddWithValue("primary_contact_first_name", NpgsqlTypes.NpgsqlDbType.Varchar, primary_contact_first_name);
                            cmd.Parameters.AddWithValue("primary_contact_last_name", NpgsqlTypes.NpgsqlDbType.Varchar, primary_contact_last_name);


                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Npgsql.PostgresException ex)
                            {
                                if (ex != null && ex.SqlState != null && ex.SqlState.Equals("23505"))
                                {
                                    try { trans.Rollback(); } catch { }
                                    throw new FriendlyMessageException("Sorry, it looks like a business with this Tax ID Number already exists. Please search again or check the ID Number.");
                                }
                            }
                        }
                    }

                    trans.Commit();
                }

                return new Customer();
            }
        }

        public decimal QueryPartsCostTotal(string vin)
        {
            decimal totalPartsCost = 0.0m;
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.queryVehiclePartsCost, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("vin", NpgsqlTypes.NpgsqlDbType.Varchar, vin);

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                totalPartsCost += reader.IsDBNull(reader.GetOrdinal("totalpartscost")) ? 0.0m : decimal.Parse(reader.GetValue(reader.GetOrdinal("totalpartscost")).ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not query for parts cost due to error: {e.Message}", entLogTypes.eAlarm);
            }

            return totalPartsCost;
        }

        public void InsertSalesOrder(string VIN, string customerid, string username, DateTime salesdate, decimal salesprice, bool loanInsert,
            decimal downPayment, DateTime startingMonth, int loanTerm, decimal monthlyPayment, decimal interestRate)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (NpgsqlTransaction trans = conn.BeginTransaction())
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.insertPurchase, conn, trans))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("VIN", NpgsqlTypes.NpgsqlDbType.Varchar, VIN);
                        cmd.Parameters.AddWithValue("customerid", NpgsqlTypes.NpgsqlDbType.Varchar, customerid);
                        cmd.Parameters.AddWithValue("username", NpgsqlTypes.NpgsqlDbType.Varchar, username);
                        cmd.Parameters.AddWithValue("salesdate", NpgsqlTypes.NpgsqlDbType.Date, salesdate);
                        cmd.Parameters.AddWithValue("salesprice", NpgsqlTypes.NpgsqlDbType.Numeric, salesprice);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Npgsql.PostgresException ex)
                        {
                            if (ex != null && ex.SqlState != null && ex.SqlState.Equals("23505"))
                            {
                                try { trans.Rollback(); } catch { }
                                throw new FriendlyMessageException("Sorry, it looks like this vehicle has already been purchased. Perhaps while you were filling in the Sales Order another customer purchased it.");
                            }
                        }
                    }

                    if (loanInsert)
                    {
                        using (var cmd = new NpgsqlCommand(SqlTextAll.insertLoan, conn, trans))
                        {
                            cmd.CommandType = System.Data.CommandType.Text;

                            cmd.Parameters.AddWithValue("VIN", NpgsqlTypes.NpgsqlDbType.Varchar, VIN);
                            cmd.Parameters.AddWithValue("downPayment", NpgsqlTypes.NpgsqlDbType.Numeric, downPayment);
                            cmd.Parameters.AddWithValue("startingMonth", NpgsqlTypes.NpgsqlDbType.Date, startingMonth);
                            cmd.Parameters.AddWithValue("loanTerm", NpgsqlTypes.NpgsqlDbType.Numeric, loanTerm);
                            cmd.Parameters.AddWithValue("monthlyPayment", NpgsqlTypes.NpgsqlDbType.Numeric, monthlyPayment);
                            cmd.Parameters.AddWithValue("interestRate", NpgsqlTypes.NpgsqlDbType.Numeric, interestRate);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Npgsql.PostgresException ex)
                            {
                                if (ex != null && ex.SqlState != null && ex.SqlState.Equals("23505"))
                                {
                                    try { trans.Rollback(); } catch { }
                                    throw new FriendlyMessageException("Sorry, it looks like this vehicle has already been purchased. Perhaps while you were filling in the Sales Order another customer purchased it.");
                                }
                            }
                        }
                    }

                    trans.Commit();
                }
            }
        }

        public void InsertVendor(string vendor_name, string street, string city, string state, string postal, string phone)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (NpgsqlTransaction trans = conn.BeginTransaction())
                using (var cmd = new NpgsqlCommand(SqlTextAll.addvendor, conn, trans))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("vendor_name", NpgsqlTypes.NpgsqlDbType.Varchar, vendor_name);
                    cmd.Parameters.AddWithValue("address_street", NpgsqlTypes.NpgsqlDbType.Varchar, street);
                    cmd.Parameters.AddWithValue("address_city", NpgsqlTypes.NpgsqlDbType.Varchar, city);
                    cmd.Parameters.AddWithValue("address_state", NpgsqlTypes.NpgsqlDbType.Varchar, state);
                    cmd.Parameters.AddWithValue("address_postal_code", NpgsqlTypes.NpgsqlDbType.Varchar, postal);
                    cmd.Parameters.AddWithValue("phone_number", NpgsqlTypes.NpgsqlDbType.Varchar, phone);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Npgsql.PostgresException ex)
                    {
                        try { trans.Rollback(); } catch { }
                        Log($"Could Not Add Vendor Due To The Following Exception: {ex.MessageText}", entLogTypes.eAlarm);
                        throw new FriendlyMessageException("Sorry! A system error prevented the vendor from being added. Please try again!");
                    }
                    trans.Commit();
                }
            }
        }

        public List<Reports.ReportClasses.SellerHistoryReport> GenerateSellerHistoryReport()
        {
            List<Reports.ReportClasses.SellerHistoryReport> Report = new List<Reports.ReportClasses.SellerHistoryReport>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.SellerHistoryQuery, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                decimal tempAvgPuchasePrice = 0;
                                Decimal.TryParse(reader.GetValue(reader.GetOrdinal("Average Purchase Price")).ToString(), out tempAvgPuchasePrice);
                                decimal tempAvgPartCost = 0;
                                Decimal.TryParse(reader.GetValue(reader.GetOrdinal("Average Part Cost")).ToString(), out tempAvgPartCost);
                                decimal tempAvgNumberOfParts = 0;
                                Decimal.TryParse(reader.GetValue(reader.GetOrdinal("Average # of Parts")).ToString(), out tempAvgNumberOfParts);

                                var results = new Reports.ReportClasses.SellerHistoryReport();
                                results.Name = reader.GetValue(reader.GetOrdinal("Name")).ToString();
                                results.total_sold = reader.GetValue(reader.GetOrdinal("Total Sold")).ToString();
                                results.average_purchase_price = tempAvgPuchasePrice.ToString("C");
                                results.avg_num_parts = tempAvgNumberOfParts.ToString("0.00");
                                results.avg_part_cost = tempAvgPartCost.ToString("C");
                                Report.Add(results);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Generate Seller History Report Due To The Following: {e.Message}", entLogTypes.eAlarm);
            }

            return Report;
        }
        public void InsertPartsOrder(string orderid, string vin, string username, string ponumber, string vendor_name,
            List<Part> PartList)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (NpgsqlTransaction trans = conn.BeginTransaction())
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.InsertPartsOrder, conn, trans))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("orderid", NpgsqlTypes.NpgsqlDbType.Varchar, orderid);
                        cmd.Parameters.AddWithValue("vin", NpgsqlTypes.NpgsqlDbType.Varchar, vin);
                        cmd.Parameters.AddWithValue("username", NpgsqlTypes.NpgsqlDbType.Varchar, username);
                        cmd.Parameters.AddWithValue("ponumber", NpgsqlTypes.NpgsqlDbType.Varchar, ponumber);
                        cmd.Parameters.AddWithValue("vendorname", NpgsqlTypes.NpgsqlDbType.Varchar, vendor_name);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Npgsql.PostgresException ex)
                        {
                            try { trans.Rollback(); } catch { }
                            throw new FriendlyMessageException("Sorry, an error has occurred while adding the parts order: " + ex.MessageText);
                        }
                    }
                    using (var cmd = new NpgsqlCommand(SqlTextAll.AddPartToOrder, conn, trans))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        try
                        {
                            foreach (Part p in PartList)
                            {
                                cmd.Parameters.AddWithValue("partnumber", NpgsqlTypes.NpgsqlDbType.Varchar, p.partnumber);
                                cmd.Parameters.AddWithValue("orderId", NpgsqlTypes.NpgsqlDbType.Varchar, orderid);
                                if (string.IsNullOrWhiteSpace(p.description)) { cmd.Parameters.AddWithValue("description", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                                else { cmd.Parameters.AddWithValue("description", NpgsqlTypes.NpgsqlDbType.Varchar, p.description); }                                
                                cmd.Parameters.AddWithValue("cost", NpgsqlTypes.NpgsqlDbType.Numeric, p.cost);
                                cmd.Parameters.AddWithValue("statusId", NpgsqlTypes.NpgsqlDbType.Varchar, p.statusid);

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (PostgresException ex)
                                {
                                    throw new FriendlyMessageException("Sorry, an error has occurred while adding the parts order: " + ex.MessageText);

                                }
                            }
                        }
                        catch (Npgsql.PostgresException ex)
                        {
                            if (ex != null && ex.SqlState != null && ex.SqlState.Equals("23505"))
                            {
                                try { trans.Rollback(); } catch { }
                                throw new FriendlyMessageException("Sorry, an error has occurred while adding the parts order: " + ex.MessageText);
                            }
                        }
                    }

                    trans.Commit();
                }
            }
        }

        public List<Condition> QueryConditions()
        {
            List<Condition> conditions = new List<Condition>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.queryCondition, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                conditions.Add(new Condition() { ConditionId = reader.GetString(reader.GetOrdinal("ConditionId")) });
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Query Condition Due To the Following Exception: {e.Message}", entLogTypes.eAlarm);
                conditions = null;

            }

            return conditions;
        }

        public void InsertVehiclePurchase(string VIN, string model_name, string model_year, string mileage, string description, DateTime purchase_date,
          decimal purchase_price, string vehicleTypeId, string manufacturerId, List<string> colorIds, string conditionId, string customerid, string username)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (NpgsqlTransaction trans = conn.BeginTransaction())
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.addVechicle, conn, trans))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("VIN", NpgsqlTypes.NpgsqlDbType.Varchar, VIN);
                        cmd.Parameters.AddWithValue("model_name", NpgsqlTypes.NpgsqlDbType.Varchar, model_name);
                        cmd.Parameters.AddWithValue("model_year", NpgsqlTypes.NpgsqlDbType.Varchar, model_year);
                        cmd.Parameters.AddWithValue("mileage", NpgsqlTypes.NpgsqlDbType.Varchar, mileage);
                        cmd.Parameters.AddWithValue("vehicleTypeId", NpgsqlTypes.NpgsqlDbType.Varchar, vehicleTypeId);
                        cmd.Parameters.AddWithValue("manufacturerId", NpgsqlTypes.NpgsqlDbType.Varchar, manufacturerId);
                        if (string.IsNullOrWhiteSpace(description)) { cmd.Parameters.AddWithValue("description", NpgsqlTypes.NpgsqlDbType.Varchar, DBNull.Value); }
                        else { cmd.Parameters.AddWithValue("description", NpgsqlTypes.NpgsqlDbType.Varchar, description); }

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Npgsql.PostgresException ex)
                        {
                            if (ex != null && ex.SqlState != null && ex.SqlState.Equals("23505"))
                            {
                                try { trans.Rollback(); } catch { }
                                throw new FriendlyMessageException("Sorry, it looks like this vehicle has already been put into inventory.");
                            }
                        }
                    }

                    using (var cmd = new NpgsqlCommand(SqlTextAll.insertSold, conn, trans))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("VIN", NpgsqlTypes.NpgsqlDbType.Varchar, VIN);
                        cmd.Parameters.AddWithValue("customerid", NpgsqlTypes.NpgsqlDbType.Varchar, customerid);
                        cmd.Parameters.AddWithValue("conditionid", NpgsqlTypes.NpgsqlDbType.Varchar, conditionId);
                        cmd.Parameters.AddWithValue("purchase_date", NpgsqlTypes.NpgsqlDbType.Date, purchase_date);
                        cmd.Parameters.AddWithValue("purchase_price", NpgsqlTypes.NpgsqlDbType.Numeric, purchase_price);
                        cmd.Parameters.AddWithValue("username", NpgsqlTypes.NpgsqlDbType.Varchar, username);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Npgsql.PostgresException ex)
                        {
                            if (ex != null && ex.SqlState != null && ex.SqlState.Equals("23505"))
                            {
                                try { trans.Rollback(); } catch { }
                                throw new FriendlyMessageException("Sorry, it looks like this vehicle has already been put into inventory.");
                            }
                        }
                    }

                    foreach (string colorId in colorIds)
                    {
                        using (var cmd = new NpgsqlCommand(SqlTextAll.insertVehicleColor, conn, trans))
                        {
                            cmd.CommandType = System.Data.CommandType.Text;

                            cmd.Parameters.AddWithValue("VIN", NpgsqlTypes.NpgsqlDbType.Varchar, VIN);
                            cmd.Parameters.AddWithValue("colorId", NpgsqlTypes.NpgsqlDbType.Varchar, colorId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                }
            }
        }

        public int QueryTotalVehiclesWithPartsPending()
        {
            List<Condition> conditions = new List<Condition>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.queryTotalCarsWithPartsPending, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {                                
                                try { return reader.GetInt32(0); } catch { return 0; }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Query Condition Due To the Following Exception: {e.Message}", entLogTypes.eAlarm);
                conditions = null;
            }

            return 0;
        }

        public List<Entities.PartWithOrder> QueryPartsForVechicle(string vin)
        {
            List<Entities.PartWithOrder> parts = new List<Entities.PartWithOrder>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.queryPartsForVehicle, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("vin", NpgsqlTypes.NpgsqlDbType.Varchar, vin);

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var part = new PartWithOrder()
                                {
                                    vendor_name = reader.GetString(reader.GetOrdinal("vendor_name")),
                                    po_number = reader.GetString(reader.GetOrdinal("ponumber")),
                                    partnumber = reader.GetString(reader.GetOrdinal("partnumber")),
                                    orderid = reader.GetString(reader.GetOrdinal("orderid")),
                                    description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),
                                    cost = reader.GetDecimal(reader.GetOrdinal("cost")),
                                    statusid = reader.GetString(reader.GetOrdinal("statusid")),
                                    username = reader.GetString(reader.GetOrdinal("username"))
                                };
                                parts.Add(part);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Query Parts Due To the Following Exception: {e.Message}", entLogTypes.eAlarm);
                parts = new List<PartWithOrder>();
            }

            return parts;
        }

        public void UpdatePartStatus(string orderid, string partnumber, string newstatus)
        {            
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.updatePartStatus, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("orderid", NpgsqlTypes.NpgsqlDbType.Varchar, orderid);
                        cmd.Parameters.AddWithValue("partnumber", NpgsqlTypes.NpgsqlDbType.Varchar, partnumber);
                        cmd.Parameters.AddWithValue("newstatus", NpgsqlTypes.NpgsqlDbType.Varchar, newstatus);

                        conn.Open();
                        cmd.ExecuteNonQuery();                        
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not Update Parts Status Due To the Following Exception: {e.Message}", entLogTypes.eAlarm);                
            }
            
        }

        public List<string> getAllPoNumbersForVIN(string vin)
        {
            List<string> allPos = new List<string>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.getAllPoNumbersForVIN, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("vin", NpgsqlTypes.NpgsqlDbType.Varchar, vin);

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                allPos.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not query for all Purchase Orders Exception: {e.Message}", entLogTypes.eAlarm);
            }

            return allPos;
        }

        public List<Vendor> querySearchVendors(string vendor_name)
        {
            List<Entities.Vendor> vendors = new List<Vendor>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conn_string))
                {
                    using (var cmd = new NpgsqlCommand(SqlTextAll.searchVendors, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("vendor_name", NpgsqlTypes.NpgsqlDbType.Varchar, "%" + vendor_name + "%");

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var vendor = new Vendor()
                                {
                                    vendor_name = reader.GetString(reader.GetOrdinal("vendor_name")),
                                    address_street = reader.GetString(reader.GetOrdinal("address_street")),
                                    address_city = reader.GetString(reader.GetOrdinal("address_city")),
                                    address_state = reader.GetString(reader.GetOrdinal("address_state")),
                                    address_postal_code = reader.GetString(reader.GetOrdinal("address_postal_code")),
                                    phone_number = reader.GetString(reader.GetOrdinal("phone_number"))
                                };
                                vendors.Add(vendor);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log($"Could Not query for vendors Exception: {e.Message}", entLogTypes.eAlarm);
            }

            return vendors;
        }

    }
}

