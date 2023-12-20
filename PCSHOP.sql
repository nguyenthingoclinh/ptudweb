CREATE TABLE Menu(
    MenuID INT IDENTITY(1,1) PRIMARY KEY,
    MenuName nvarchar(50) not null,
	Link nvarchar(50),
	IsActive bit,
	ControllerName nvarchar(50),
	ActionName nvarchar(50),
	Levels int,
	ParentID int,
	MenuOrder int,
	Position int
);
CREATE TABLE AdminMenu(
    AdminMenuID bigint IDENTITY(1,1) PRIMARY KEY,
    ItemName nvarchar(50),
	ItemLevel int,
	ParentLevel int,
	ItemOrder int,
	IsActive bit,
	ItemTarget nvarchar(50),
	AreaName nvarchar(50),
	ControllerName nvarchar(50),
	ActionName nvarchar(50),
	Icon nvarchar(50),
	IdName nvarchar(50)
	
);
CREATE TABLE AdminUser(
    ID INT IDENTITY(1,1) PRIMARY KEY,
	UserName nvarchar(50),
	Email nvarchar(50),
	Password nvarchar(50),
	IsActive bit
);
CREATE TABLE Category(
    ID INT IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(MAX) not null,
	ParentId int,
	Orders int,
	CreatedAt datetime,
	UpdatedAt datetime,
	Status int not null,
	Image nvarchar(MAX)
);
CREATE TABLE Supplier(
    ID INT IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(MAX) not null,
	Image nvarchar(MAX),
	Orders int,
	Compony nvarchar(MAX),
	Address nvarchar(MAX),
	Phone nvarchar(MAX),
	Email nvarchar(MAX),
	CreatedAt datetime,
	UpdatedAt datetime,
	Status int	
);
CREATE TABLE Product(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryId int not null,
	SupplierId int not null,
	MenuID int not null,
	Name nvarchar(MAX) ,
	Price decimal(18, 0) ,
	Image nvarchar(50) ,
	Description nvarchar(255),
	Quantity int,
	Sold int ,
	Likes int ,
	UpdatedDate datetime,
	Status int,
	PriceSale decimal(18, 0),
	IsActive bit
);
CREATE TABLE Users(
    ID INT IDENTITY(1,1) PRIMARY KEY,
	FullName nvarchar(MAX),
	Avatar nvarchar(MAX),
	UserName nvarchar(MAX),
	Password nvarchar(MAX),
	Email nvarchar(MAX),
	Phone nvarchar(MAX),
	Address nvarchar(MAX),
	IsActive bit
);
CREATE TABLE Order(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserId int not null,
	DeliveryName nvarchar(MAX),
	DeliveryMail nvarchar(MAX),
	DeliveryPhone nvarchar(MAX),
	DeliveryAddress nvarchar(MAX) ,
	TotalAmount decimal(18, 0),
	CreatedAt datetime,
	UpdatedAt datetime,
	Status int
);
CREATE TABLE OrderDetail(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    OrderId int not null,
	ProductId int not null,
	Quantity int not null,
	DistCount int not null,
	Note nvarchar(MAX) ,
	CreatedAt datetime,
	UpdatedAt datetime,
	Status int
);
CREATE TABLE Transaction(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserId int not null,
	Payment nvarchar(MAX),
	ProductId int not null,
	Quantity int not null,
	Amount decimal(18, 0),
	Message int,
	CreatedAt datetime,
	UpdatedAt datetime,
	Status int
);



--đặt hàng,chi tiết đặt hàng,sản phẩm,loại,các nhà cung cấp,người dùng,giao dịch,
CREATE TABLE Post(
    ID bigint IDENTITY(1,1) PRIMARY KEY,
    Title nvarchar(255),
	Abstract nvarchar(255),
	Contents ntext,
	Images nvarchar(200),
	Link nvarchar(200),
	Author nvarchar(30),
	CreatedDate datetime,
	IsActive bit,
	PostOrder int,
	MenuID int,
	Category int,
	Status int
);
CREATE TABLE Slide(
    ID bigint IDENTITY(1,1) PRIMARY KEY,
    Title nvarchar(255),
	Abstract nvarchar(255),
	Images nvarchar(200),
	Link nvarchar(200),
	CreatedDate datetime,
	IsActive bit,
	SlideOrder int,
	Category int,
	Status int
);
