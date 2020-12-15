-- salesperson user
INSERT INTO "public"."privilegeduser" ("username", "password", "first_name", "last_name")
 VALUES ('demo_salesperson', 'demo', 'Sal', 'Esperson');
INSERT INTO "public"."salesperson" ("username")
 VALUES ('demo_salesperson');    

-- inventoryclerk user
INSERT INTO "public"."privilegeduser" ("username", "password", "first_name", "last_name")
 VALUES ('demo_clerk', 'demo', 'Ivan', 'Tory');
INSERT INTO "public"."inventoryclerk" ("username")
 VALUES ('demo_clerk');  

-- sales and manager user
INSERT INTO "public"."privilegeduser" ("username", "password", "first_name", "last_name")
 VALUES ('demo_salesplusclerk', 'demo', 'Bossa', 'Sales');
INSERT INTO "public"."salesperson" ("username")
 VALUES ('demo_salesplusclerk');  
INSERT INTO "public"."inventoryclerk" ("username")
 VALUES ('demo_salesplusclerk');  

-- vehicle types
INSERT INTO "public"."vehicletype" ("vehicletypeid")
 VALUES ('Sedan');
INSERT INTO "public"."vehicletype" ("vehicletypeid")
 VALUES ('Coupe');
INSERT INTO "public"."vehicletype" ("vehicletypeid")
 VALUES ('Convertible');
INSERT INTO "public"."vehicletype" ("vehicletypeid")
 VALUES ('Truck');
INSERT INTO "public"."vehicletype" ("vehicletypeid")
 VALUES ('Van');
INSERT INTO "public"."vehicletype" ("vehicletypeid")
 VALUES ('Minivan');
INSERT INTO "public"."vehicletype" ("vehicletypeid")
 VALUES ('SUV');
INSERT INTO "public"."vehicletype" ("vehicletypeid")
 VALUES ('Other');

 --vehicle colors
 INSERT INTO "public"."color" ("colorid")
 VALUES ('Aluminum');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Beige');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Black');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Blue');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Brown');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Bronze');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Claret');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Copper');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Cream');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Gold');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Gray');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Green');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Maroon');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Metallic');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Navy');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Orange');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Pink');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Purple');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Red');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Rose');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Rust');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Silver');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Tan');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Turquoise');
INSERT INTO "public"."color" ("colorid")
 VALUES ('White');
INSERT INTO "public"."color" ("colorid")
 VALUES ('Yellow');

--vehicle manufacturers
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Acura');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Alfa Romeo');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Aston Martin');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Audi');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Bentley');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('BMW');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Buick');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Cadillac');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Chevrolet');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Chrysler');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Dodge');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Ferrari');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('FIAT');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Ford');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Freightliner');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Genesis');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('GMC');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Honda');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Hyundai');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('INFINITI');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Jaguar');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Jeep');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Kia');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Lamborghini');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Land Rover');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Lexus');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Lincoln');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Lotus');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Maserati');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('MAZDA');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('McLaren');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Mercedes-Benz');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('MINI');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Mitsubishi');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Nissan');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Porsche');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Ram');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Rolls-Royce');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('smart');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Subaru');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Tesla');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Toyota');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Volkswagen');
INSERT INTO "public"."manufacturer" ("manufacturerid")
 VALUES ('Volvo');

-- condition 
INSERT INTO "public"."condition" ("conditionid")
 VALUES ('Excellent');
INSERT INTO "public"."condition" ("conditionid")
 VALUES ('Very Good');
INSERT INTO "public"."condition" ("conditionid")
 VALUES ('Good');
INSERT INTO "public"."condition" ("conditionid")
 VALUES ('Fair');

 -- related vehicle tables
INSERT INTO "public"."customer" ("customerid", "phone_number", "email", "address_street", "address_city", "address_state", "address_postal_code")
 VALUES ('system_cust1', '5555555555', 'email@email.com', '1 street address', 'Boston', 'MA', '02110');

-- vehicles
INSERT INTO "public"."vehicle" ("vin", "model_name", "model_year", "mileage", "vehicletypeid", "manufacturerid", "description")
 VALUES ('bootstrap1_public', 'SQ5', '2019', '001021', 'SUV', 'Audi', null);
INSERT INTO "public"."vehicle" ("vin", "model_name", "model_year", "mileage", "vehicletypeid", "manufacturerid", "description")
 VALUES ('bootstrap2_public', 'R8 Spyder', '2018', '000456', 'Sedan', 'Audi', 'Way too expensive');
INSERT INTO "public"."vehicle" ("vin", "model_name", "model_year", "mileage", "vehicletypeid", "manufacturerid", "description")
 VALUES ('bootstrap3_public', 'Jetta', '2001', '123000', 'Sedan', 'Volkswagen', null);
INSERT INTO "public"."vehicle" ("vin", "model_name", "model_year", "mileage", "vehicletypeid", "manufacturerid", "description")
 VALUES ('bootstrap4_pendingparts', 'GTS Hybrid', '2001', '123000', 'Sedan', 'Porsche', null);

 -- sold relationship
INSERT INTO "public"."sold" ("vin", "customerid", "conditionid", "purchase_date", "purchase_price", "username")
 VALUES ('bootstrap1_public', 'system_cust1', 'Excellent', '10/02/2018', 56000.00, 'demo_salesperson');
INSERT INTO "public"."sold" ("vin", "customerid", "conditionid", "purchase_date", "purchase_price", "username")
 VALUES ('bootstrap2_public', 'system_cust1', 'Very Good', '10/01/2017', 55000.00, 'demo_salesperson');
INSERT INTO "public"."sold" ("vin", "customerid", "conditionid", "purchase_date", "purchase_price", "username")
 VALUES ('bootstrap3_public', 'system_cust1', 'Good', '05/01/2013', 12000.00, 'demo_salesperson'); 
INSERT INTO "public"."sold" ("vin", "customerid", "conditionid", "purchase_date", "purchase_price", "username")
 VALUES ('bootstrap4_pendingparts', 'system_cust1', 'Good', '01/01/2019', 7800.00, 'demo_salesperson');

-- part statuses
INSERT INTO "public"."Status" ("statusid")
 VALUES ('ordered');
INSERT INTO "public"."Status" ("statusid")
 VALUES ('received');
INSERT INTO "public"."Status" ("statusid")
 VALUES ('installed');

 -- vendor and part rder for single vehicle
 INSERT INTO "public"."vendor" ("vendor_name", "address_street", "address_city", "address_state", "address_postal_code", "phone_number")
 VALUES ('The Garage of Pain', 'street address 1', 'Some City', 'VT', '432422', '5555555555');
INSERT INTO "public"."partorder" ("orderid", "vin", "username", "ponumber", "vendor_name")
 VALUES ('bootstrap4_pendingparts-01', 'bootstrap4_pendingparts', 'demo_salesperson', '123456', 'The Garage of Pain');
INSERT INTO "public"."part" ("partnumber", "orderid", "description", "cost", "statusid")
 VALUES ('12345', 'bootstrap4_pendingparts-01' , 'Anti-Flux Capacitor', 450000.00, 'ordered');
INSERT INTO "public"."part" ("partnumber", "orderid", "description", "cost", "statusid")
 VALUES ('12346', 'bootstrap4_pendingparts-01' , 'Intertial Dampening Restraint', 45500.00, 'ordered');

-- some vehicle colors
INSERT INTO "public"."vehicle_color" ("vin", "colorid")
 VALUES ('bootstrap2_public', 'Gray');
INSERT INTO "public"."vehicle_color" ("vin", "colorid")
 VALUES ('bootstrap2_public', 'Green');
INSERT INTO "public"."vehicle_color" ("vin", "colorid")
VALUES ('bootstrap3_public', 'Navy');