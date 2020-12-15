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
              s1.purchase_price,
              v1.description,
              (SELECT SUM(p.cost) FROM PartOrder po INNER JOIN part p ON po.orderid = p.orderid WHERE po.VIN = v1.VIN) as total_parts_cost       
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
              AND(@color IS NULL OR EXISTS (SELECT colorid FROM vehicle_color vc2 WHERE vc2.VIN = v1.VIN AND vc2.colorid = @color))
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
              s1.purchase_price,
              v1.description,
              (SELECT SUM(p.cost) FROM PartOrder po INNER JOIN part p ON po.orderid = p.orderid WHERE po.VIN = v1.VIN) as total_parts_cost       
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
              AND(@color IS NULL OR EXISTS (SELECT colorid FROM vehicle_color vc2 WHERE vc2.VIN = v1.VIN AND vc2.colorid = @color))
              AND(@keyword IS NULL OR (v1.manufacturerId LIKE @keyword OR v1.model_year LIKE @keyword OR v1.model_name LIKE @keyword OR v1.description LIKE
                @keyword))
              AND(@vin IS NULL OR v1.VIN LIKE @vin)
              ORDER BY v1.VIN;";

        public static string queryIndividualSearch =
              @"SELECT c1.customerID,
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
              @"SELECT c1.customerID,
              c1.phone_number,
              c1.email,
              c1.address_street,
              c1.address_city,
              c1.address_state,
              c1.address_postal_code,
              b1.tax_identification_number,
              b1.business_name,
              b1.primary_contact_first_name ,
              b1.primary_contact_last_name,
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
              AND(@business_name IS NULL OR b1.business_name LIKE @business_name)  
              AND(@primary_contact_first_name IS NULL OR b1.primary_contact_first_name LIKE @primary_contact_first_name)
              AND(@primary_contact_last_name IS NULL OR b1.primary_contact_last_name LIKE @primary_contact_last_name)
              AND(@primary_contact_title IS NULL OR b1.primary_contact_title LIKE @primary_contact_title)
              ORDER BY c1.customerId;";

        public static string insertCustomer =
            @"INSERT INTO ""customer"" (customerid, phone_number, email, address_street, address_city, address_state, address_postal_code)
              VALUES(@customerid, @phone_number, @email, @address_street, @address_city, @address_state, @address_postal_code);";

        public static string insertIndividual =
            @"INSERT INTO ""individual"" (drivers_license_number, customerid, first_name, last_name)
              VALUES(@drivers_license_number, @customerid, @first_name, @last_name);";

        public static string insertBusiness =
            @"INSERT INTO ""business"" (tax_identification_number, customerid, business_name, primary_contact_first_name, primary_contact_last_name, primary_contact_title)
              VALUES(@tax_identification_number, @customerid, @business_name, @primary_contact_first_name, @primary_contact_last_name, @primary_contact_title);";

        public static string avgTimeInInventoryQuery =
            @"SELECT v1.vehicleTypeId,
              avg((CAST(p1.sales_date AS date)) - (CAST(s1.purchase_date AS date))) as ""avgTime""
              FROM vehicleType as v1
              LEFT OUTER JOIN vehicle v2
                    ON v1.vehicleTypeId = v2.vehicleTypeId
              LEFT OUTER JOIN sold s1
                    ON v2.VIN = s1.VIN
              LEFT OUTER JOIN purchase p1
                    ON v2.VIN = p1.VIN
              WHERE s1.purchase_date IS NOT NULL
                    AND p1.sales_date IS NOT NULL
              GROUP BY v1.vehicleTypeId;";

        public static string partsStatisticsQuery =
            @"SELECT v1.vendor_name, count(p1.partnumber) as ""num_of_parts"", avg(p1.cost) as ""avgCost""
                FROM vendor v1
                INNER JOIN partorder po
                    ON v1.vendor_name = po.vendor_name
                INNER JOIN part p1
                    ON po.orderid = p1.orderid
                GROUP BY v1.vendor_name";

        public static string MSIncomeQuery =
            @"SELECT to_char((now() - INTERVAL '1 Year' + INTERVAL '1 Month' * (@loop_param + 1)), 'Mon') as ""month"", to_char((now() - INTERVAL '1 Year' + INTERVAL '1 Month' * (@loop_param + 1)), 'YYYY') as ""year"", SUM(monthly_payment) as ""total_payment""
                FROM loan
                WHERE(starting_month + INTERVAL '1 Month' * loan_term) >= (now() - INTERVAL '1 Year' + INTERVAL '1 Month' * @loop_param)
                    AND starting_month< (now() - INTERVAL '1 Year' + INTERVAL '1 Month' * (@loop_param + 1))
                    AND to_char(starting_month, 'Mon') != to_char((now() - INTERVAL '1 Year' + INTERVAL '1 Month' * (@loop_param + 1)), 'Mon')
                GROUP BY year, month;";


        public static string pricePerConditionQuery =
            @"SELECT vehicle_type, ""Excellent"", ""Very Good"", ""Good"", ""Fair""
                FROM crosstab(
                $$SELECT vt.vehicletypeid, c.conditionid, avg(s.purchase_price) as ""Average Price Paid""
                FROM vehicletype vt
                LEFT OUTER JOIN vehicle v
                ON vt.vehicletypeid = v.vehicletypeid
                INNER JOIN sold s
                ON v.VIN = s.VIN
                INNER JOIN condition c
                ON s.conditionid = c.conditionid
                GROUP BY vt.vehicletypeid, c.conditionid
                ORDER BY vt.vehicletypeid, c.conditionid$$)
                AS(vehicle_type varchar(50), ""Excellent"" numeric(8,2), ""Very Good"" numeric(8,2), ""Good"" numeric(8,2), ""Fair"" numeric(8,2));";

        public static string MSQuery =
             @"SELECT EXTRACT(MONTH FROM sales_date) as ""sales_month"", sales_year, COUNT(VIN) AS ""vehicle_amt"", SUM(Sales_Price) AS ""sales_income"", (SUM(Sales_Price) -SUM(Purchase_Price)) AS ""net_income""
                FROM
                (SELECT p.sales_date as sales_date, EXTRACT(YEAR FROM p.sales_date) as sales_year, v.VIN , p.Sales_Price, s.Purchase_Price
                    FROM Vehicle v
                    INNER JOIN sold s ON v.VIN = s.VIN
                    INNER JOIN purchase p ON s.VIN = p.VIN) as inner_query
                GROUP BY sales_year, sales_month
                ORDER BY sales_year, sales_month;";

        public static string MSQuery1 =
            @"SELECT EXTRACT(MONTH FROM sales_date) as ""sales_month"",  EXTRACT(YEAR FROM p.sales_date) as sales_year, SUM(pa.cost) as ""cost_2""
                FROM partorder po
                    INNER JOIN part pa ON po.orderid = pa.orderid
                    INNER JOIN purchase p on p.VIN = po.VIN
                WHERE po.VIN = p.VIN
                GROUP BY sales_year, sales_month
                ORDER BY sales_year, sales_month;";

        public static string MSDrilldownQuery =
            @"SELECT spname, COUNT(VIN) AS ""vehicle_amt"", SUM(Sales_Price) AS ""total_sales""
                FROM
                    (SELECT CONCAT_WS(u.first_name,' ', u.last_name) AS ""spname"" , v.VIN , p.sales_price
                    FROM Vehicle v
                    INNER JOIN purchase p
                        ON v.VIN = p.VIN
                    INNER JOIN privilegeduser u
                        ON p.username = u.username
                    where EXTRACT(YEAR FROM p.sales_date) = @year_param
                        AND EXTRACT(MONTH FROM p.sales_date) = @month_param) as inner_query
                    GROUP BY spname
                    ORDER BY vehicle_amt, total_sales DESC;";

        public static string SellerHistoryQuery =
            @"(((SELECT concat_ws(i.first_name, ' ', i.last_name) AS ""Name"",
                count(s.customerid) AS ""Total Sold"",
                avg(s.purchase_price) AS ""Average Purchase Price"",
                (select avg(p1.cost) from part p1 inner join partorder po1 on p1.orderid = po1.orderid where po1.vin in (select s1.vin from sold s1 where s1.customerid = s.customerid)) AS ""Average Part Cost"",
                (select avg(num_count) from(select count(p1.partNumber) as ""num_count"" from part p1 inner join partorder po1 on p1.orderid = po1.orderid where po1.vin in (select s1.vin from sold s1 where s1.customerid = s.customerid) group by po1.vin) as foo) AS ""Average # of Parts""
                FROM individual i
                INNER JOIN sold as s ON s.customerid = i.customerid
                GROUP BY s.customerid, ""Name"")
                UNION All
                (SELECT b.business_name AS ""Name"",
                count(s.customerid) AS ""Total Sold"",
                avg(s.purchase_price) AS ""Average Purchase Price"",
                (select avg(p1.cost) from part p1 inner join partorder po1 on p1.orderid = po1.orderid where po1.vin in (select s1.vin from sold s1 where s1.customerid = s.customerid)) AS ""Average Part Cost"",
                (select avg(num_count) from(select count(p1.partNumber) as ""num_count"" from part p1 inner join partorder po1 on p1.orderid = po1.orderid where po1.vin in (select s1.vin from sold s1 where s1.customerid = s.customerid) group by po1.vin) as foo) AS ""Average # of Parts""
                FROM business b
                INNER JOIN sold as s ON s.customerid = b.customerid
                GROUP BY s.customerid, ""Name"" ))
                ORDER BY ""Total Sold"" DESC, ""Average Purchase Price"");";

        public static string queryVehiclePartsCost =
            @"SELECT SUM(p.cost) as TotalPartsCost
              FROM vehicle v
              INNER JOIN partorder po
                ON v.VIN = po.VIN
              INNER JOIN part p
                ON po.orderId = p.orderId
              WHERE v.VIN = @vin";

        public static string insertPurchase = 
            @"INSERT INTO ""purchase""(vin, customerid, username, sales_date, sales_price)
             VALUES(@VIN, @customerid, @username, @salesDate, @salesPrice);";

        public static string insertLoan =
            @"INSERT INTO loan(vin, down_payment, starting_month, loan_term, monthly_payment, interest_rate)
            VALUES(@VIN, @downPayment, @startingMonth, @loanTerm, @monthlyPayment, @interestRate);";

        public static string addvendor =
            @"INSERT INTO ""vendor"" (vendor_name, address_street, address_city, address_state, address_postal_code, phone_number)
            VALUES (@vendor_name, @address_street, @address_city, @address_state, @address_postal_code, @phone_number);";

        public static string InsertPartsOrder =
            @"INSERT INTO partorder (orderid, vin, username, ponumber, vendor_name)
            VALUES (@orderId, @VIN, @username, @poNumber, @vendorName);";

        public static string AddPartToOrder =
            @"INSERT INTO part (partnumber, orderid, description, cost, statusid)
            VALUES (@partNumber, @orderId, @description, @cost, @statusId);";

        public static string queryCondition =
           @"SELECT conditionId FROM condition;";

        public static string addVechicle =
            @"INSERT INTO ""vehicle"" (vin, model_name, model_year, mileage, vehicletypeid, manufacturerid, description)
            VALUES(@vin, @model_name, @model_year, @mileage, @vehicletypeid , @manufacturerId, @description);";

        public static string insertSold =
            @"INSERT INTO ""sold"" (vin, customerid, conditionid, purchase_date, purchase_price, username)
              VALUES(@vin, @customerid, @conditionid, @purchase_date, @purchase_price, @username);";

        public static string insertVehicleColor =
            @"INSERT INTO ""vehicle_color"" (vin, colorid)
              VALUES(@vin, @colorId);";


        public static string queryTotalCarsWithPartsPending =
              @"SELECT count(v1.vin)
              FROM vehicle v1
              WHERE NOT EXISTS(
                    SELECT p1.VIN
                    FROM Purchase p1
                    WHERE p1.VIN = v1.VIN)
              AND EXISTS(
                    SELECT p.partNumber
                    FROM part p
                    INNER JOIN partorder po
                        ON p.orderid = po.orderid
                    WHERE p.statusid != 'installed'
                    AND po.vin = v1.vin
              )";
                
         public static string queryPublicVehicleSearchPreviouslySold =
            @"SELECT v1.VIN,
              v1.vehicleTypeId,
              V1.model_year,
              v1.manufacturerId,
              V1.model_name,
              (SELECT string_agg(c1.colorId, ',') FROM Color c1 INNER JOIN vehicle_color vc1 ON c1.colorId = vc1.colorId WHERE vc1.VIN = v1.VIN) as color,
              V1.mileage,
              s1.purchase_price,
              v1.description,
              (SELECT SUM(p.cost) FROM PartOrder po INNER JOIN part p ON po.orderid = p.orderid WHERE po.VIN = v1.VIN) as total_parts_cost       
              FROM vehicle v1
              INNER JOIN sold s1
                    ON v1.VIN = s1.VIN             
              WHERE EXISTS(
                    SELECT p1.VIN
                    FROM Purchase p1
                    WHERE p1.VIN = v1.VIN)
              AND(@vehicleTypeId IS NULL OR v1.vehicleTypeId = @vehicleTypeId)
              AND(@manufacturerId IS NULL OR v1.manufacturerId = @manufacturerId)
              AND(@model_year IS NULL OR v1.model_year = @model_year)
              AND(@color IS NULL OR EXISTS (SELECT colorid FROM vehicle_color vc2 WHERE vc2.VIN = v1.VIN AND vc2.colorid = @color))
              AND(@keyword IS NULL OR (v1.manufacturerId LIKE @keyword OR v1.model_year LIKE @keyword OR v1.model_name LIKE @keyword OR v1.description LIKE
                @keyword))
              AND(@vin IS NULL OR v1.VIN LIKE @vin)
              ORDER BY v1.VIN;";

        public static string queryVehicleSearchNoRestrictions =
          @"SELECT v1.VIN,
              v1.vehicleTypeId,
              V1.model_year,
              v1.manufacturerId,
              V1.model_name,
              (SELECT string_agg(c1.colorId, ',') FROM Color c1 INNER JOIN vehicle_color vc1 ON c1.colorId = vc1.colorId WHERE vc1.VIN = v1.VIN) as color,
              V1.mileage,
              s1.purchase_price,
              v1.description,
              (SELECT SUM(p.cost) FROM PartOrder po INNER JOIN part p ON po.orderid = p.orderid WHERE po.VIN = v1.VIN) as total_parts_cost       
              FROM vehicle v1
              INNER JOIN sold s1
                    ON v1.VIN = s1.VIN             
              AND(@vehicleTypeId IS NULL OR v1.vehicleTypeId = @vehicleTypeId)
              AND(@manufacturerId IS NULL OR v1.manufacturerId = @manufacturerId)
              AND(@model_year IS NULL OR v1.model_year = @model_year)
              AND(@color IS NULL OR EXISTS (SELECT colorid FROM vehicle_color vc2 WHERE vc2.VIN = v1.VIN AND vc2.colorid = @color))
              AND(@keyword IS NULL OR (v1.manufacturerId LIKE @keyword OR v1.model_year LIKE @keyword OR v1.model_name LIKE @keyword OR v1.description LIKE
                @keyword))
              AND(@vin IS NULL OR v1.VIN LIKE @vin)
              ORDER BY v1.VIN;";

        public static string queryPartsForVehicle =
            @"select po.vin, po.orderid, po.username, po.ponumber, po.vendor_name, p.partnumber, p.description, p.cost, p.statusid
              from partorder po
              inner join part p
                on po.orderid = p.orderid              
              where po.vin = @vin
              order by po.orderid, p.statusid;";

        public static string updatePartStatus =
            @"update part
              set statusid = @newstatus
              where orderid = @orderid and partnumber = @partnumber";

        public static string getAllPoNumbersForVIN =
            @"SELECT ponumber FROM ""partorder"" WHERE vin = @vin";

        public static string searchVendors =
            @"select vendor_name, address_street, address_city, address_state, address_postal_code, phone_number from vendor where vendor_name like @vendor_name";

    }
}