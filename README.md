# Реляционная база данных и приложение для работы с ней для «Оптовой фирмы»

### Содержание

[Постановка задачи](#Постановка-задачи)
[Концептуальная модель](#Концептуальная-модель)
[Логическая модель](#Логическая-модель)
[Физическая модель](#Физическая-модель)
[Постановка задачи](#Постановка-задачи)
[Постановка задачи](#Постановка-задачи)
[Постановка задачи](#Постановка-задачи)
[Постановка задачи](#Постановка-задачи)
[Постановка задачи](#Постановка-задачи)

____

## Постановка задачи

Постройте реляционную базу данных Оптовая фирма на основе описания информационных потребностей заказчика разработки. Разработайте систему ввода, просмотра и корректировки данных базы. Разработайте систему решения задач на основе информации базы.

«Я – менеджер оптовой фирмы по продаже спортивных товаров, которая выполняет заказы предприятий розничной торговли по всему миру. Нашими заказчиками являются магазины (некоторые из наших служащих предпочитают называть их клиентами). Сейчас у нас 15 клиентов по всему миру, и мы стараемся увеличить их количество. Самыми крупными из них являются магазины «Big John's Sports Emporium» в Сан-Франциско (Калифорния, США) и «Womansport» в Сиэттле (Вашингтон, США). Мы должны знать индентификационный номер и имя каждого клиента. Можно также хранить его адрес (включая город, штат, почтовый индекс и страну) и номер телефона. Для наилучшего обслуживания клиентов у нас есть склады в различных регионах. Прежде всего нам необходимо знать номер каждого заказа. Но дата заказа, дата отгрузки и способ платежа тоже могут быть получены, если эта информация имеется. Весь мир мы условно поделим на шесть регионов: Северная Америка, Южная Америка, Африка, Средний Восток, Азия и Европа. Здесь нам достаточно иметь номер региона и его название. Чтобы знать, откуда лучше всего доставлять товары по каждому заказу, мы стараемся закрепить каждого клиента за каким-либо регионом. Каждый склад должен иметь номер. Можно также хранить его адрес (включая город, штат, почтовый индекс и страну) и номер телефона. Сейчас в каждом регионе у нас только один склад, но мы надеемся, что вскоре их станет больше».
«На нашей оптовой фирме по продаже спорттоваров я заведую отделом приема заказов. Отдел отвечает за размещение и контроль выполнения заказов клиентов. Нам необходимо знать номер и название каждого отдела. Иногда, если это не срочно, клиенты присылают заказ по почте, но чаще всего звонят или присылают факс. Мы надеемся расширить свой бизнес за счет немедленной информационной обработки каждого заказа. При наличии нужного товара на одном из наших складов мы можем обещать отгрузить его на следующий день. Если у нас есть информация, мы отслеживаем размер товарного запаса, минимальное количество, при котором необходимо пополнить запас, максимальное количество, причину отсутствия товара на складе и дату восполнения конкретного товара. Мы планируем автоматически отправлять файлы об отгрузке товаров через нашу систему отгрузки».

«Мой отдел просто следит за тем, чтобы клиенты получили правильную информацию по оплате, и чтобы на их счетах было достаточно средств для кредита. Кроме этого, мы можем хранить общие сведения о клиенте».

«Мы должны следить за тем, чтобы все товары, заказанные клиентами, присутствовали на складе. Для каждого товара мы храним его номер. Можно также хранить цену товара, количество в наличии и отгруженное количество, если такая информация имеется. Если нужный товар на складе есть, мы хотим обработать заказ и сообщить нашему заказчику номер заказа и его итоговую сумму. Если нужного количества товара на складе нет, заказчик должен сказать, что нам делать, и ждать, пока мы сможем отгрузить заказанный товар полностью или выполнить заказ частично».

«Бухгалтерия отвечает за ведение информации о клиентах – особенно за присвоение им новых номеров. Мой отдел может разрешить внести изменение в информацию о клиенте только в случае, если он сделал заказ, а его платежные реквизиты или адреса грузополучателей изменились. Нет, за сбор платежей мы не отвечаем. Этим занимается отдел дебиторских счетов. Думаю также, что в этом участвуют и торговые представители, т. к. размер их комиссионных зависит от клиентов, которые платят деньги. Нам необходимо знать номер и фамилию каждого торгового представителя или служащего. Иногда требуется его имя, имя пользователя (в базе данных), дата начала работы в компании, должность и месячный оклад. Можно также хранить данные о проценте комиссионных служащего и любые замечания о нем».

«Наш персонал по приему заказов прекрасно разбирается в нашей продукции. Мы часто проводим совещания с представителями отдела маркетинга, где они информируют нас о новых товарах. Это возможно благодаря тому, что мы заключаем сделки с небольшим количеством специально подобранных клиентов и поддерживаем для них специализированные линии товаров. Мы должны знать номер и наименование каждого продукта. Время от времени может потребоваться описание, предполагаемая цена и минимальное количество товара, которое можно хранить. В случае необходимости хотелось бы также иметь возможность получить очень длинные описания наших товаров и их фотографии».

[:arrow_up:Содержание](#Содержание)

____

## Концептуальная модель

Концептуальная модель построена в виде диаграммы в нотации Питера Чена. 

Было выделено 12 сущностей: клиент, заказ, товар, описание товара, склад, регион, сотрудник, платеж, контакт, реквизит, счет, отдел.

Главные сущности: клиент, заказ, товар. Именно вокруг этих объектов строится вся БД. Все остальные сущности являются сопутствующими. 

<p align="center">
<img src="https://github.com/SonyAkb/DB_course_4th_semester/blob/main/модель%201.drawio.png?raw=true" alt="image" style="width:90%; height:auto;">
</p>

Один клиент может размещать множество заказов (1:N). Заказ включает несколько товаров через связующую таблицу (M:N). Наличие товаров на складах фиксируется в соответствующей таблице (M:N). Каждый заказ закреплен за торговым представителем (1:N).
Виды связей: многие ко многим и один ко многим.

Клиент может не получить счет, так как не сделает заказ, поэтому связь необязательная. Может сложится такая ситуация, что в одном из регионов не будет ни одного клиента из-за этого связь необязательная. Также, не каждый товар может иметь подробное описание.

[:arrow_up:Содержание](#Содержание)

## Логическая модель

Логическая модель выполнена в нотации Дж. Мартина («Вороньи лапки»).

<p align="center">
<img src="https://github.com/SonyAkb/DB_course_4th_semester/blob/main/модель%202.drawio.png?raw=true" alt="image" style="width:90%; height:auto;">
</p>

На схеме логической модели отражены сведения о полях, требуемых для объединения таблиц, а также о ключевых элементах, таких как первичные и внешние ключи. Кроме того, представлены наименования триггеров и представлений.

[:arrow_up:Содержание](#Содержание)

## Физическая модель

Физическая модель выполнена в нотации Дж. Мартина («Вороньи лапки»).

<p align="center">
<img src="https://github.com/SonyAkb/DB_course_4th_semester/blob/main/модель%203.drawio.png?raw=true" alt="image" style="width:90%; height:auto;">
</p>

На диаграмме физической модели наглядно показаны типы полей, имена триггеров и представлений, а также информация обо всех полях таблиц.

[:arrow_up:Содержание](#Содержание)

## Создание базы данных

Создание таблицы Регионы (Region)
```MySQL
CREATE TABLE Region (
    RegionID INT AUTO_INCREMENT PRIMARY KEY,
    RegionName NVARCHAR(255) NOT NULL
);
```
Листинг А.2 — Создание таблицы Категории товаров (ProductCategory)
CREATE TABLE ProductCategory (
    CategoryID INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName NVARCHAR(255) NOT NULL,
    Description LONGTEXT NULL
);
Листинг А.3 — Создание таблицы Отделы (Department)
CREATE TABLE Department (
    DepartmentID INT AUTO_INCREMENT PRIMARY KEY,
    DepartmentName NVARCHAR(255) NOT NULL,
    Description LONGTEXT NULL
);
Листинг А.4 — Создание таблицы Должности (JobTitle)
CREATE TABLE JobTitle (
    JobTitleID INT AUTO_INCREMENT PRIMARY KEY,
    JobTitleName NVARCHAR(255) NOT NULL,
    Description LONGTEXT NULL
);
Листинг А.5 — Создание таблицы Сотрудники (Employee)
CREATE TABLE Employee (
    EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
    DepartmentID INT NOT NULL,
    JobTitleID INT NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    FirstName NVARCHAR(255) NOT NULL,
    Patronymic NVARCHAR(255) NULL,
    HireDate DATE NOT NULL,
    Salary DECIMAL(15, 2) NOT NULL,
    CommissionRate DECIMAL(5, 2) NULL,
    Description LONGTEXT NULL,
    CONSTRAINT chk_salary CHECK (Salary > 0),
    CONSTRAINT chk_commission CHECK (CommissionRate BETWEEN 0 AND 100 OR CommissionRate IS NULL),
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID),
    FOREIGN KEY (JobTitleID) REFERENCES JobTitle(JobTitleID)
);
Листинг А.6 — Создание таблицы Склады (Warehouse)
CREATE TABLE Warehouse (
    WarehouseID INT AUTO_INCREMENT PRIMARY KEY,
    RegionID INT NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    State NVARCHAR(50) NULL,
    PostalCode VARCHAR(20) NOT NULL,
    Country NVARCHAR(100) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (RegionID) REFERENCES Region(RegionID)
);
Листинг А.7 — Создание таблицы Клиенты (Customer)
CREATE TABLE Customer (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    PostalCode VARCHAR(20) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    State NVARCHAR(50) NULL,
    Country NVARCHAR(100) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Email VARCHAR(255) NULL,
    CreditLimit DECIMAL(15, 2) NULL,
    RegionID INT NOT NULL,
    CONSTRAINT chk_credit_limit CHECK (CreditLimit >= 0),
    CONSTRAINT chk_email CHECK (Email LIKE '%@%.%' OR Email IS NULL),
    FOREIGN KEY (RegionID) REFERENCES Region(RegionID)
);
Листинг А.8 — Создание индекса для страны клиента
CREATE INDEX idx_customer_country ON Customer(Country);
Листинг А.9 — Создание таблицы Контакты клиентов (Contact)
CREATE TABLE Contact (
    ContactID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    Patronymic NVARCHAR(50) NULL,
    Position NVARCHAR(255) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    FaxNumber VARCHAR(255) NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);
Листинг А.10 — Создание таблицы Юридические реквизиты (LegalDetails)
CREATE TABLE LegalDetails (
    LegalID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT NOT NULL,
    TaxID VARCHAR(50) NOT NULL,
    ReasonCode VARCHAR(50) NULL,
    RegistrationNumber VARCHAR(50) NOT NULL,
    LegalAddress NVARCHAR(255) NOT NULL,
    CEOFullName NVARCHAR(255) NOT NULL,
    CEOPosition NVARCHAR(255) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);
Листинг А.11 — Создание таблицы Банковские реквизиты (BankAccount)
CREATE TABLE BankAccount (
    AccountID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT NOT NULL,
    BankName NVARCHAR(255) NOT NULL,
    AccountNumber VARCHAR(50) NOT NULL,
    CorrespondentAccount VARCHAR(50) NOT NULL,
    BIC VARCHAR(20) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);
Листинг А.12 — Создание таблицы Товары (Product)
CREATE TABLE Product (
    ProductID INT AUTO_INCREMENT PRIMARY KEY,
    CategoryID INT NOT NULL,
    ProductName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(255) NULL,
    Price DECIMAL(15, 2) NOT NULL,
    MinimumStockLevel INT NOT NULL DEFAULT 5,
    MaximumStockLevel INT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT chk_price CHECK (Price > 0),
    CONSTRAINT chk_min_stock CHECK (MinimumStockLevel >= 0),
    FOREIGN KEY (CategoryID) REFERENCES ProductCategory(CategoryID)
);
Листинг А.13 — Создание индексов для товаров
CREATE INDEX idx_product_price ON Product(Price);
CREATE INDEX idx_product_min_stock ON Product(MinimumStockLevel);
Листинг А.14 — Создание таблицы Подробная информация о товаре (ProductDetail)
CREATE TABLE ProductDetail (
    DetailID INT AUTO_INCREMENT PRIMARY KEY,
    ProductID INT NOT NULL,
    FullDescription LONGTEXT NULL,
    ImageData LONGBLOB NULL,
    Weight DECIMAL(10,2) NULL,
    Dimensions NVARCHAR(255) NULL,
    CONSTRAINT chk_weight CHECK (Weight > 0 OR Weight IS NULL),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

Листинг А.15 — Создание таблицы Статусы заказов (OrderStatus)
CREATE TABLE OrderStatus (
    StatusID INT AUTO_INCREMENT PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL
);
Листинг А.16 — Создание таблицы Заказы (Ordering)
CREATE TABLE Ordering (
    OrderID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT NOT NULL,
    StatusID INT NOT NULL,
    EmployeeID INT NOT NULL,
    OrderDate DATE NOT NULL DEFAULT (CURRENT_DATE),
    Address NVARCHAR(255) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    State NVARCHAR(50) NULL,
    PostalCode VARCHAR(20) NOT NULL,
    Country NVARCHAR(100) NOT NULL,
    TotalAmount DECIMAL(15, 2) NOT NULL DEFAULT 0,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (StatusID) REFERENCES OrderStatus(StatusID),
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
);
Листинг А.17 — Создание индексов для заказов
CREATE INDEX idx_ordering_date ON Ordering(OrderDate);
CREATE INDEX idx_ordering_total ON Ordering(TotalAmount);
Листинг А.18 — Создание таблицы Товары в заказе (OrderItem)
CREATE TABLE OrderItem (
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    UnitPrice DECIMAL(15, 2) NOT NULL,
    PRIMARY KEY (OrderID, ProductID),
    CONSTRAINT chk_quantity CHECK (Quantity > 0),
    CONSTRAINT chk_unit_price CHECK (UnitPrice > 0),
    FOREIGN KEY (OrderID) REFERENCES Ordering(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
Листинг А.19 — Создание индекса для количества товаров в заказе
CREATE INDEX idx_order_item_quantity ON OrderItem(Quantity);
Листинг А.20 — Создание таблицы Запасы (Inventory)
CREATE TABLE Inventory (
    WarehouseID INT NOT NULL,
    ProductID INT NOT NULL,
    QuantityInStock INT NOT NULL DEFAULT 0,
    LastStockUpdate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Description LONGTEXT NULL,
    PRIMARY KEY (ProductID, WarehouseID),
    CONSTRAINT chk_quantity_in_stock CHECK (QuantityInStock >= 0),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouse(WarehouseID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
Листинг А.21 — Создание таблицы Методы оплаты (PaymentMethod)
CREATE TABLE PaymentMethod (
    PaymentMethodID INT AUTO_INCREMENT PRIMARY KEY,
    PaymentMethodName NVARCHAR(255) NOT NULL
);
Листинг А.22 — Создание таблицы Статусы оплаты (PaymentStatus)
CREATE TABLE PaymentStatus (
    StatusID INT AUTO_INCREMENT PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL
);
Листинг А.23 — Создание таблицы Счета (Invoice)
Листинг А. Создаем таблицу Invoice с DEFAULT значением для InvoiceStatusID
CREATE TABLE Invoice (
    InvoiceID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT NOT NULL,
    InvoiceDate DATE NOT NULL DEFAULT (CURRENT_DATE),
    DueDate DATE NOT NULL,
    InvoiceAmount DECIMAL(15, 2) NOT NULL,
    InvoiceStatusID INT NOT NULL DEFAULT (1),
    FOREIGN KEY (OrderID) REFERENCES Ordering(OrderID),
    FOREIGN KEY (InvoiceStatusID) REFERENCES PaymentStatus(StatusID)
);
Листинг А.24 — Создание индекса для даты оплаты счета
CREATE INDEX idx_invoice_due_date ON Invoice(DueDate);
Листинг А.25 — Создание таблицы Платежи (Payment)
CREATE TABLE Payment (
    PaymentID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT NOT NULL,
    PaymentMethodID INT NOT NULL,
    Amount DECIMAL(15, 2) NOT NULL,
    PaymentDate DATE NOT NULL DEFAULT (CURRENT_DATE),
    CONSTRAINT chk_amount CHECK (Amount > 0),
    FOREIGN KEY (OrderID) REFERENCES Ordering(OrderID),
    FOREIGN KEY (PaymentMethodID) REFERENCES PaymentMethod(PaymentMethodID)
);
Листинг А.26 — Создание индекса для даты платежа
CREATE INDEX idx_payment_date ON Payment(PaymentDate);
Листинг А.27 — Создание таблицы Отгрузки (Shipment)
CREATE TABLE Shipment (
    ShipmentID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT NOT NULL,
    WarehouseID INT NOT NULL,
    ShipmentDate DATE NOT NULL DEFAULT (CURRENT_DATE),
    EstimatedArrivalDate DATE NULL,
    TrackingNumber VARCHAR(100) NULL,
    FOREIGN KEY (OrderID) REFERENCES Ordering(OrderID),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouse(WarehouseID)
);
Листинг А.28 — Создание таблицы Типы документов (DocumentType)
CREATE TABLE DocumentType (
    DocumentTypeID INT AUTO_INCREMENT PRIMARY KEY,
    DocumentTypeName NVARCHAR(255) NOT NULL
);
Листинг А.29 — Создание таблицы Документы по заказам (OrderDocument)
CREATE TABLE OrderDocument (
    OrderDocumentID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT NOT NULL,
    DocumentPath VARCHAR(255) NOT NULL,
    DocumentTypeID INT NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Ordering(OrderID),
    FOREIGN KEY (DocumentTypeID) REFERENCES DocumentType(DocumentTypeID)
);
 
