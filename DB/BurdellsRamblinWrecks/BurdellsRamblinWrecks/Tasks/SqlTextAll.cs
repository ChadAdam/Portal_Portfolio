using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Queries
{
    public static class SqlTextAll
    {
        public static string queryAuthenticateUserSQL =
            @"SELECT password, first_name, last_name
              FROM privilegeduser
              WHERE username = @username_param;";

        public static string queryUserRolesSQL =
            @"SELECT sp.username as ""salesperson"", ic.username as ""inventoryclerk"", m.username as ""manager"", o.username as ""owner""
              FROM privilegeduser pu      
              LEFT OUTER JOIN salesperson sp ON pu.username = sp.username
              LEFT OUTER JOIN inventoryclerk ic ON pu.username = ic.username
              LEFT OUTER JOIN manager m ON pu.username = m.username
              LEFT OUTER JOIN owner o ON pu.username = o.username
              WHERE pu.username = @username_param;";

        public static string queryVehicleType =
            @"SELECT vehicletypeid FROM vehicletype;";

        public static string queryManufacturer =
            @"SELECT manufacturerid FROM manufacturer;";

        public static string queryColor =
            @"SELECT colorid FROM color;";

        public static string queryPublicVehicleSearch =
            @"SELECT v1.VIN,
              v1.vehicleTypeId,
              V1.model_year,
              v1.manufacturerId,
              V1.model_name,
              (SELECT string_agg(c1.colorId, ',') FROM Color c1 INNER JOIN vehicle_color vc1 ON c1.colorId = vc1.colorId WHERE vc1.VIN = v1.VIN) as color,
              V1.mileage,
              s1.purchase_price as ""Sales Price"",
              v1.description
              FROM vehicle v1
              INNER JOIN sold s1
                    ON v1.VIN = s1.VIN
              WHERE NOT EXISTS(
                    SELECT po1.orderId
                    FROM partorder po1
                    INNER JOIN part p1
                      ON po1.orderId = p1.orderId                      
                    WHERE p1.statusid != 'installed'
                    AND po1.VIN = v1.VIN)
              AND NOT EXISTS(
                    SELECT p1.VIN
                    FROM Purchase p1
                    WHERE p1.VIN = v1.VIN)
              AND(@vehicleTypeId IS NULL OR v1.vehicleTypeId = @vehicleTypeId)
              AND(@manufacturerId IS NULL OR v1.manufacturerId = @manufacturerId)
              AND(@model_year IS NULL OR v1.model_year = @model_year)
              AND(@color IS NULL OR EXISTS (SELECT colorid FROM vehicle_color vc2 WHERE vc2.VIN = v1.VIN))
              AND(@keyword IS NULL OR (v1.manufacturerId LIKE @keyword OR v1.model_year LIKE @keyword OR v1.model_name LIKE @keyword OR v1.description LIKE
                @keyword))
              AND(@vin IS NULL OR v1.VIN LIKE @vin)
              ORDER BY v1.VIN;";

        public static string queryPriviledgedVehicleSearch =
              @"SELECT v1.VIN,
              v1.vehicleTypeId,
              V1.model_year,
              v1.manufacturerId,
              V1.model_name,
              (SELECT string_agg(c1.colorId, ',') FROM Color c1 INNER JOIN vehicle_color vc1 ON c1.colorId = vc1.colorId WHERE vc1.VIN = v1.VIN) as color,
              V1.mileage,
              s1.purchase_price as ""Sales Price"",
              v1.description
              FROM vehicle v1
              INNER JOIN sold s1
                    ON v1.VIN = s1.VIN             
              WHERE NOT EXISTS(
                    SELECT p1.VIN
                    FROM Purchase p1
                    WHERE p1.VIN = v1.VIN)
              AND(@vehicleTypeId IS NULL OR v1.vehicleTypeId = @vehicleTypeId)
              AND(@manufacturerId IS NULL OR v1.manufacturerId = @manufacturerId)
              AND(@model_year IS NULL OR v1.model_year = @model_year)
              AND(@color IS NULL OR EXISTS (SELECT colorid FROM vehicle_color vc2 WHERE vc2.VIN = v1.VIN))
              AND(@keyword IS NULL OR (v1.manufacturerId LIKE @keyword OR v1.model_year LIKE @keyword OR v1.model_name LIKE @keyword OR v1.description LIKE
                @keyword))
              AND(@vin IS NULL OR v1.VIN LIKE @vin)
              ORDER BY v1.VIN;";

        public static string queryIndividualSearch =
              @"SELECT 
              c1.phone_number,
              c1.email,
              c1.address_street,
              c1.address_city,
              c1.address_state,
              c1.address_postal_code,
              Ind.drivers_license_number,
              Ind.first_name ,
              Ind.last_name
              FROM Customer c1
              INNER JOIN Individual Ind
                    ON c1.customerID = Ind.customerID           
              AND(@phone_number IS NULL OR c1.phone_number = @phone_number)
              AND(@email IS NULL OR c1.email = @email)
           
              AND(@address_street IS NULL OR c1.address_street LIKE @address_street)
              AND(@address_state IS NULL OR c1.address_state LIKE @address_state)
              AND(@address_city IS NULL OR c1.address_city LIKE @address_city)
              AND(@address_postal_code IS NULL OR c1.address_postal_code LIKE @address_postal_code)
              AND(@drivers_license_number IS NULL OR Ind.drivers_license_number LIKE @drivers_license_number)
              AND(@first_name IS NULL OR Ind.first_name LIKE @first_name)
              AND(@last_name IS NULL OR Ind.last_name LIKE @last_name)
              ORDER BY c1.customerId;";

        public static string queryBusinessSearch =
                      @"SELECT 
              c1.phone_number,
              c1.email,
              c1.address_street,
              c1.address_city,
              c1.address_state,
              c1.address_postal_code,
              b1.tax_identification_number,
              b1.primary_first_name ,
              b1.primary_last_name,
              b1.primary_contact_title
              FROM Customer c1
              INNER JOIN Business b1
                    ON c1.customerID = b1.customerID           
              AND(@phone_number IS NULL OR c1.phone_number = @phone_number)
              AND(@email IS NULL OR c1.email = @email)
              
              AND(@address_street IS NULL OR c1.address_street LIKE @address_street)
              AND(@address_state IS NULL OR c1.address_state LIKE @address_state)
              AND(@address_city IS NULL OR c1.address_city LIKE @address_city)
              AND(@address_postal_code IS NULL OR c1.address_postal_code LIKE @address_postal_code)
              AND(@tax_identification_number IS NULL OR b1.tax_identification_number LIKE @tax_identification_number)
              AND(@primary_first_name IS NULL OR b1.primary_first_name LIKE @primary_first_name)
              AND(@primary_last_name IS NULL OR b1.primary_last_name LIKE @primary_last_name)
              AND(@primary_contact_title IS NULL OR b1.primary_contact_title LIKE @primary_contact_title)
              ORDER BY c1.customerId;";
    }
}