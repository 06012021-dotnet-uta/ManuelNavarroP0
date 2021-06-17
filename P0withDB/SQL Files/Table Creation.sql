CREATE DATABASE P0;

CREATE TABLE Customers (
cust_id int NOT NULL Identity(1, 1) PRIMARY KEY,
cust_Fname varchar(255),
cust_Lname varchar(255),
cust_phoneNum varchar(12),
cust_email varchar(255),
cust_username varchar(30),
cust_password varchar(30),
address_id int FOREIGN KEY REFERENCES CustomersAddress (address_id)
);

CREATE TABLE CustomersAddress (
address_id int NOT NULL Identity(1, 1) Primary Key,
address_street varchar(255),
address_city varchar(50),
address_state varchar(50)
);

CREATE TABLE Products (
product_id int NOT NULL Identity(1, 1) Primary Key,
product_name varchar(50),
product_desc varchar(255),
product_price decimal(8,2),
dept_id int FOREIGN KEY REFERENCES ProductDept (dept_id)
);

CREATE TABLE ProductDept (
dept_id int NOT NULL Identity(1, 1) PRIMARY KEY,
product_dept varchar(50)
);

CREATE TABLE Stores (
store_id int NOT NULL Identity(1, 1) Primary Key,
store_name varchar(255),
store_address varchar(255)
);

CREATE TABLE StoreInventory (
store_id int NOT NULL,
product_id int NOT NULL,
product_quantity int NULL,
Constraint PK_store_inventory PRIMARY KEY
(
	store_id,
	product_id
),
FOREIGN KEY (store_id) REFERENCES Stores (store_id),
FOREIGN KEY (product_id) REFERENCES Products (product_id)
);

CREATE TABLE Orders (
order_id int NOT NULL Identity(1, 1) PRIMARY KEY,
order_total decimal(8,2),
order_date DATETIME,
store_id int FOREIGN KEY REFERENCES Stores (store_id),
cust_id int FOREIGN KEY REFERENCES Customers (cust_id)
);

CREATE TABLE OrderProducts (
order_id int NOT NULL,
product_id int NOT NULL,
product_order_quantity int NOT NULL,
Constraint PK_order_products PRIMARY KEY
(
	order_id,
	product_id
),
FOREIGN KEY (order_id) REFERENCES Orders (order_id),
FOREIGN KEY (product_id) REFERENCES Products (product_id)
);
