CREATE TABLE VehicleType(
	vehicleTypeId varchar(50) PRIMARY KEY);

CREATE TABLE Manufacturer(
	manufacturerId varchar(50) PRIMARY KEY);
   
CREATE TABLE Color(
	colorId varchar(50) PRIMARY KEY);

CREATE TABLE Condition(
	conditionId varchar(50) PRIMARY KEY);

CREATE TABLE Vehicle(
    VIN varchar(50) PRIMARY KEY,
    model_name varchar(50) NOT NULL,
    model_year varchar(4) NOT NULL,
    mileage varchar(6) NOT NULL,
    vehicleTypeId varchar(50) NOT NULL,	
    manufacturerId varchar(50) NOT NULL,
    "description" varchar(200) NULL,
    CONSTRAINT FK_Vehicle_vehicleTypeId_VehicleType_vehicleTypeId FOREIGN KEY (vehicleTypeId) REFERENCES VehicleType(vehicleTypeId),
    CONSTRAINT FK_Vehicle_manufacturerId_Manufacturer_manufacturerId FOREIGN KEY (manufacturerId) REFERENCES Manufacturer(manufacturerId));

CREATE TABLE Vehicle_Color(
    VIN varchar(50) NOT NULL,
    colorId varchar(50) NOT NULL,	
    CONSTRAINT PK_Vehicle_Color PRIMARY KEY (VIN, colorId),
    CONSTRAINT FK_Vehicle_Color_VIN_Vehicle_VIN FOREIGN KEY (VIN) REFERENCES Vehicle(VIN),
    CONSTRAINT FK_Vehicle_Color_colorId_Color_colorId FOREIGN KEY (colorId) REFERENCES Color(colorId));

CREATE TABLE Customer(
    customerID varchar(50) PRIMARY KEY,
    phone_number varchar(12) NOT NULL,
    email varchar(50) NULL,
    address_street varchar(50) NOT NULL,
	address_city varchar(50) NOT NULL,
	address_state varchar(50) NOT NULL,
	address_postal_code varchar(10) NOT NULL);

CREATE TABLE Business(
    tax_identification_number varchar(50) PRIMARY KEY,
	customerID varchar(50) NOT NULL,
    business_name varchar(50) NOT NULL,
    primary_contact_first_name varchar(50) NOT NULL,
	primary_contact_last_name varchar(50) NOT NULL,
	primary_contact_title varchar(50) NOT NULL,
	CONSTRAINT FK_Business_customerID_Customer_customerID FOREIGN KEY (customerID) REFERENCES Customer(customerID));
    
CREATE TABLE Individual(
    drivers_license_number varchar(50) PRIMARY KEY,
	customerID varchar(50) NOT NULL,
    first_name varchar(50) NOT NULL,
    last_name varchar(50) NOT NULL,
	CONSTRAINT FK_Individual_customerID_Customer_customerID FOREIGN KEY (customerID) REFERENCES Customer(customerID));

CREATE TABLE PrivilegedUser(
	username varchar(50) PRIMARY KEY,
	"password" varchar(50) NOT NULL,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL);

CREATE TABLE SalesPerson(
	username varchar(50) PRIMARY KEY,
	CONSTRAINT FK_SalesPerson_userName_PrivilegedUser_userName FOREIGN KEY (username) REFERENCES PrivilegedUser(username));

CREATE TABLE InventoryClerk(
	username varchar(50) PRIMARY KEY,
	CONSTRAINT FK_InventoryClerk_username_PrivilegedUser_username FOREIGN KEY (username) REFERENCES PrivilegedUser(username));
	
CREATE TABLE Manager(
	username varchar(50) PRIMARY KEY,
	CONSTRAINT FK_Manager_username_PrivilegedUser_username FOREIGN KEY (username) REFERENCES PrivilegedUser(username));
	
CREATE TABLE Owner(
	username varchar(50) PRIMARY KEY,
	CONSTRAINT FK_Owner_username_PrivilegedUser_username FOREIGN KEY (username) REFERENCES PrivilegedUser(username));
	
CREATE TABLE Purchase(
    VIN varchar(50) PRIMARY KEY,
	customerID varchar(50) NOT NULL,    
	userName varchar(50) NOT NULL,
	sales_date date NOT NULL,
	sales_price numeric(8,2) NOT NULL,
	CONSTRAINT FK_Purchase_VIN_Vehicle_VIN FOREIGN KEY (VIN) REFERENCES Vehicle(VIN),
	CONSTRAINT FK_Purchase_customerID_Customer_customerID FOREIGN KEY (customerID) REFERENCES Customer(customerID),
	CONSTRAINT FK_Purchase_userName_PrivilegedUser_userName FOREIGN KEY (userName) REFERENCES PrivilegedUser(userName));

CREATE TABLE Loan(
    VIN varchar(50) PRIMARY KEY,
	down_payment numeric(8,2) NOT NULL,
	starting_month date NOT NULL,
	loan_term numeric NOT NULL,
	monthly_payment numeric(8,2) NOT NULL,
	interest_rate numeric(8,2) NOT NULL,	    
	CONSTRAINT FK_Loan_VIN_Purchase_VIN FOREIGN KEY (VIN) REFERENCES Purchase(VIN));

CREATE TABLE Sold(
    VIN varchar(50) NOT NULL,
	customerID varchar(50) NOT NULL,    
	conditionId varchar(50) NOT NULL,	
	purchase_date date NOT NULL,
    purchase_price numeric(8,2) NOT NULL,	
	userName varchar(50) NOT NULL,
	CONSTRAINT PK_Sold PRIMARY KEY (VIN, conditionId),
	CONSTRAINT FK_Sold_VIN_Vehicle_VIN FOREIGN KEY (VIN) REFERENCES Vehicle(VIN),
	CONSTRAINT FK_Sold_customerID_Customer_customerID FOREIGN KEY (customerID) REFERENCES Customer(customerID),
	CONSTRAINT FK_Sold_userName_PrivilegedUser_userName FOREIGN KEY (userName) REFERENCES PrivilegedUser(userName));

CREATE TABLE "Status"(
	statusId varchar(50) PRIMARY KEY);

CREATE TABLE Vendor(
	vendor_name varchar(50) PRIMARY KEY,	
    address_street varchar(50) NOT NULL,
	address_city varchar(50) NOT NULL,
	address_state varchar(50) NOT NULL,
	address_postal_code varchar(10) NOT NULL,
	phone_number varchar(12) NULL);
	
CREATE TABLE PartOrder(
    orderId varchar(50) PRIMARY KEY,
	VIN varchar(50) NOT NULL,
	userName varchar(50) NOT NULL,
	poNumber varchar(50) NOT NULL,
	vendor_name varchar(50) NOT NULL,
	CONSTRAINT FK_PartOrder_VIN_Vehicle_VIN FOREIGN KEY (VIN) REFERENCES Vehicle(VIN),
	CONSTRAINT FK_PartOrder_userName_PrivilegedUser_userName FOREIGN KEY (userName) REFERENCES PrivilegedUser(userName),
	CONSTRAINT FK_PartOrder_vendorName_Vendor_vendorname FOREIGN KEY (vendor_name) REFERENCES Vendor(vendor_name));
	
CREATE TABLE Part(
	partNumber varchar(50) NOT NULL,
	orderId varchar(50) NOT NULL,
	"description" varchar(200) NULL,
	cost numeric(8,2) NOT NULL,
	statusId varchar(50) NOT NULL,
	CONSTRAINT PK_Part PRIMARY KEY (partNumber, orderId),
	CONSTRAINT FK_Part_orderId_PartOrder_orderId FOREIGN KEY (orderId) REFERENCES PartOrder(orderId),
	CONSTRAINT FK_Part_statusId_Status_statusId FOREIGN KEY (statusId) REFERENCES "Status"(statusId));

    