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

____

## Логическая модель

Логическая модель выполнена в нотации Дж. Мартина («Вороньи лапки»).

<p align="center">
<img src="https://github.com/SonyAkb/DB_course_4th_semester/blob/main/модель%202.drawio.png?raw=true" alt="image" style="width:90%; height:auto;">
</p>

На схеме логической модели отражены сведения о полях, требуемых для объединения таблиц, а также о ключевых элементах, таких как первичные и внешние ключи. Кроме того, представлены наименования триггеров и представлений.

[:arrow_up:Содержание](#Содержание)

____

## Физическая модель

Физическая модель выполнена в нотации Дж. Мартина («Вороньи лапки»).

<p align="center">
<img src="https://github.com/SonyAkb/DB_course_4th_semester/blob/main/модель%203.drawio.png?raw=true" alt="image" style="width:90%; height:auto;">
</p>

На диаграмме физической модели наглядно показаны типы полей, имена триггеров и представлений, а также информация обо всех полях таблиц.

[:arrow_up:Содержание](#Содержание)

____

## Создание базы данных

### Создание таблиц

Создание таблицы Регионы (Region)
```MySQL
CREATE TABLE Region (
    RegionID INT AUTO_INCREMENT PRIMARY KEY,
    RegionName NVARCHAR(255) NOT NULL
);
```
Создание таблицы Категории товаров (ProductCategory)
```MySQL
CREATE TABLE ProductCategory (
    CategoryID INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName NVARCHAR(255) NOT NULL,
    Description LONGTEXT NULL
);
```
Создание таблицы Отделы (Department)
```MySQL
CREATE TABLE Department (
    DepartmentID INT AUTO_INCREMENT PRIMARY KEY,
    DepartmentName NVARCHAR(255) NOT NULL,
    Description LONGTEXT NULL
);
```
Создание таблицы Должности (JobTitle)
```MySQL
CREATE TABLE JobTitle (
    JobTitleID INT AUTO_INCREMENT PRIMARY KEY,
    JobTitleName NVARCHAR(255) NOT NULL,
    Description LONGTEXT NULL
);
```
Создание таблицы Сотрудники (Employee)
```MySQL
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
```
Создание таблицы Склады (Warehouse)
```MySQL
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
```
Создание таблицы Клиенты (Customer)
```MySQL
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
```
Создание индекса для страны клиента
```MySQL
CREATE INDEX idx_customer_country ON Customer(Country);
```
Создание таблицы Контакты клиентов (Contact)
```MySQL
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
```
Создание таблицы Юридические реквизиты (LegalDetails)
```MySQL
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
```
Создание таблицы Банковские реквизиты (BankAccount)
```MySQL
CREATE TABLE BankAccount (
    AccountID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT NOT NULL,
    BankName NVARCHAR(255) NOT NULL,
    AccountNumber VARCHAR(50) NOT NULL,
    CorrespondentAccount VARCHAR(50) NOT NULL,
    BIC VARCHAR(20) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);
```
Создание таблицы Товары (Product)
```MySQL
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
```
Создание индексов для товаров
```MySQL
CREATE INDEX idx_product_price ON Product(Price);
CREATE INDEX idx_product_min_stock ON Product(MinimumStockLevel);
```
Создание таблицы Подробная информация о товаре (ProductDetail)
```MySQL
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
```
Создание таблицы Статусы заказов (OrderStatus)
```MySQL
CREATE TABLE OrderStatus (
    StatusID INT AUTO_INCREMENT PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL
);
```
Создание таблицы Заказы (Ordering)
```MySQL
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
```
Создание индексов для заказов
```MySQL
CREATE INDEX idx_ordering_date ON Ordering(OrderDate);
CREATE INDEX idx_ordering_total ON Ordering(TotalAmount);
```
Создание таблицы Товары в заказе (OrderItem)
```MySQL
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
```
Создание индекса для количества товаров в заказе
```MySQL
CREATE INDEX idx_order_item_quantity ON OrderItem(Quantity);
```
Создание таблицы Запасы (Inventory)
```MySQL
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
```
Создание таблицы Методы оплаты (PaymentMethod)
```MySQL
CREATE TABLE PaymentMethod (
    PaymentMethodID INT AUTO_INCREMENT PRIMARY KEY,
    PaymentMethodName NVARCHAR(255) NOT NULL
);
```
Создание таблицы Статусы оплаты (PaymentStatus)
```MySQL
CREATE TABLE PaymentStatus (
    StatusID INT AUTO_INCREMENT PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL
);
```
Создание таблицы Счета (Invoice)
```MySQL
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
```
Создание индекса для даты оплаты счета
```MySQL
CREATE INDEX idx_invoice_due_date ON Invoice(DueDate);
```
Создание таблицы Платежи (Payment)
```MySQL
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
```
Создание индекса для даты платежа
```MySQL
CREATE INDEX idx_payment_date ON Payment(PaymentDate);
```
Создание таблицы Отгрузки (Shipment)
```MySQL
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
```
Создание таблицы Типы документов (DocumentType)
```MySQL
CREATE TABLE DocumentType (
    DocumentTypeID INT AUTO_INCREMENT PRIMARY KEY,
    DocumentTypeName NVARCHAR(255) NOT NULL
);
```
Создание таблицы Документы по заказам (OrderDocument)
```MySQL
CREATE TABLE OrderDocument (
    OrderDocumentID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT NOT NULL,
    DocumentPath VARCHAR(255) NOT NULL,
    DocumentTypeID INT NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Ordering(OrderID),
    FOREIGN KEY (DocumentTypeID) REFERENCES DocumentType(DocumentTypeID)
);
```

[:arrow_up:Содержание](#Содержание)


### Создание триггеров для бд

Триггер для пересчета суммы заказа при изменении состава заказа
```MySQL
DELIMITER //
CREATE TRIGGER trg_order_total_update
AFTER INSERT ON OrderItem
FOR EACH ROW
BEGIN
    UPDATE Ordering 
    SET TotalAmount = (
        SELECT SUM(Quantity * UnitPrice) 
        FROM OrderItem 
        WHERE OrderID = NEW.OrderID
    )
    WHERE OrderID = NEW.OrderID;
END//
DELIMITER ;

DELIMITER //
CREATE TRIGGER trg_order_total_update_on_update
AFTER UPDATE ON OrderItem
FOR EACH ROW
BEGIN
    UPDATE Ordering 
    SET TotalAmount = (
        SELECT SUM(Quantity * UnitPrice) 
        FROM OrderItem 
        WHERE OrderID = NEW.OrderID
    )
    WHERE OrderID = NEW.OrderID;
END//
DELIMITER ;

DELIMITER //
CREATE TRIGGER trg_order_total_update_on_delete
AFTER DELETE ON OrderItem
FOR EACH ROW
BEGIN
    UPDATE Ordering 
    SET TotalAmount = (
        SELECT IFNULL(SUM(Quantity * UnitPrice), 0) 
        FROM OrderItem 
        WHERE OrderID = OLD.OrderID
    )
    WHERE OrderID = OLD.OrderID;
END//
DELIMITER ;
```
Триггер для проверки уровня запасов
```MySQL
DELIMITER //
CREATE TRIGGER check_stock_levels
AFTER UPDATE ON Inventory
FOR EACH ROW
BEGIN
    DECLARE min_level INT;
    DECLARE product_name VARCHAR(255);
    DECLARE error_message VARCHAR(500);
    
    —— Получаем минимальный уровень для товара
    SELECT MinimumStockLevel, ProductName INTO min_level, product_name
    FROM Product WHERE ProductID = NEW.ProductID;
    
    —— Проверяем, упал ли запас ниже минимального уровня
    IF NEW.QuantityInStock < min_level THEN
        —— Здесь можно добавить логирование или уведомление
        SET error_message = CONCAT('Внимание: Запас товара "', product_name, 
                                     '" на складе ID ', NEW.WarehouseID, 
                                     ' ниже минимального уровня! Текущий запас: ', 
                                     NEW.QuantityInStock, ', минимальный: ', min_level);
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = error_message;
    
    END IF;
END//
DELIMITER ;
```
Триггер для проверки кредитного лимита при создании заказа
```MySQL
DELIMITER //
CREATE TRIGGER trg_check_credit_limit_before_order
BEFORE INSERT ON Ordering
FOR EACH ROW
BEGIN
    DECLARE customer_credit DECIMAL(15,2);
    DECLARE customer_debt DECIMAL(15,2);
    DECLARE new_order_total DECIMAL(15,2);
    
    —— Получаем кредитный лимит клиента
    SELECT CreditLimit INTO customer_credit
    FROM Customer WHERE CustomerID = NEW.CustomerID;
    
    —— Если кредитный лимит не установлен, пропускаем проверку
    IF customer_credit IS NOT NULL THEN
        —— Считаем текущую задолженность клиента (сумма неоплаченных счетов)
        SELECT IFNULL(SUM(i.InvoiceAmount — IFNULL(p.TotalPaid, 0)), 0) INTO customer_debt
        FROM Invoice i
        LEFT JOIN (
            SELECT OrderID, SUM(Amount) AS TotalPaid
            FROM Payment
            GROUP BY OrderID
        ) p ON i.OrderID = p.OrderID
        WHERE i.OrderID IN (
            SELECT OrderID FROM Ordering WHERE CustomerID = NEW.CustomerID
        );
        
        —— Проверяем, не превысит ли новый заказ кредитный лимит
        IF (customer_debt + NEW.TotalAmount) > customer_credit THEN
            SIGNAL SQLSTATE '45000' 
            SET MESSAGE_TEXT = 'Превышен кредитный лимит клиента. Невозможно создать заказ.';
        END IF;
    END IF;
END//
DELIMITER ;
```
Триггер для обновления статуса заказа при полной оплате
```MySQL
DELIMITER //
CREATE TRIGGER trg_update_order_status_after_payment
AFTER INSERT ON Payment
FOR EACH ROW
BEGIN
    DECLARE total_paid DECIMAL(15,2);
    DECLARE invoice_amount DECIMAL(15,2);
    DECLARE current_payment_status INT;
    DECLARE order_has_credit BIT;
    
    —— 1. Проверяем, есть ли у клиента кредитный лимит
    SELECT 
        IF(CreditLimit > 0, 1, 0) 
    INTO 
        order_has_credit
    FROM 
        Customer c
    JOIN 
        Ordering o ON c.CustomerID = o.CustomerID
    WHERE 
        o.OrderID = NEW.OrderID;
    
    —— 2. Получаем сумму счета
    SELECT 
        InvoiceAmount
    INTO 
        invoice_amount
    FROM 
        Invoice
    WHERE 
        OrderID = NEW.OrderID
    LIMIT 1;
    
    —— 3. Считаем общую сумму оплат по заказу
    SELECT 
        IFNULL(SUM(Amount), 0) 
    INTO 
        total_paid
    FROM 
        Payment
    WHERE 
        OrderID = NEW.OrderID;
    
    —— 4. Обновляем только статус оплаты в Invoice (не трогаем статус заказа)
    IF total_paid >= invoice_amount THEN
        —— Полная оплата
        UPDATE Invoice
        SET InvoiceStatusID = (
            SELECT StatusID 
            FROM PaymentStatus 
            WHERE StatusName = 'Оплачен'
        )
        WHERE OrderID = NEW.OrderID;
        
    ELSEIF total_paid > 0 AND order_has_credit = 1 THEN
        —— Для клиентов с кредитом: частичная оплата
        UPDATE Invoice
        SET InvoiceStatusID = (
            SELECT StatusID 
            FROM PaymentStatus 
            WHERE StatusName = 'Частично оплачен'
        )
        WHERE OrderID = NEW.OrderID;
        
    ELSEIF total_paid > 0 THEN
        —— Для клиентов без кредита: частичная оплата
        UPDATE Invoice
        SET InvoiceStatusID = (
            SELECT StatusID 
            FROM PaymentStatus 
            WHERE StatusName = 'Частично оплачен'
        )
        WHERE OrderID = NEW.OrderID;
    END IF;
END//
DELIMITER ; 
```

[:arrow_up:Содержание](#Содержание)


### Создание представлений для бд

Клиенты с названиями регионов (запрос 1)
```MySQL
CREATE VIEW v_customer_with_region AS
SELECT 
    c.CustomerID,
    c.CustomerName,
    c.Country,
    r.RegionName AS Region,
    c.CreditLimit
FROM 
    Customer c
JOIN 
    Region r ON c.RegionID = r.RegionID
ORDER BY 
    r.RegionName;

Клиенты с просроченными платежами (запрос 2)
```MySQL
CREATE VIEW v_customer_debtors AS
SELECT 
    c.CustomerID,
    c.CustomerName,
    i.InvoiceID,
    i.InvoiceAmount,
    i.DueDate,
    DATEDIFF(CURRENT_DATE, i.DueDate) AS DaysOverdue
FROM 
    Customer c
JOIN 
    Ordering o ON c.CustomerID = o.CustomerID
JOIN 
    Invoice i ON o.OrderID = i.OrderID
LEFT JOIN 
    Payment p ON i.OrderID = p.OrderID
WHERE 
    i.InvoiceStatusID = (SELECT StatusID FROM PaymentStatus WHERE StatusName LIKE '%Ожидает оплаты%')
    AND i.DueDate < CURRENT_DATE
GROUP BY 
    i.InvoiceID
HAVING 
    SUM(IFNULL(p.Amount, 0)) < i.InvoiceAmount;
```
Средний чек по регионам (запрос 3)
```MySQL
CREATE VIEW v_avg_order_by_region AS
SELECT 
    r.RegionID,
    r.RegionName,
    COUNT(o.OrderID) AS TotalOrders,
    AVG(o.TotalAmount) AS AverageOrderAmount,
    SUM(o.TotalAmount) AS TotalSales
FROM 
    Region r
JOIN 
    Customer c ON r.RegionID = c.RegionID
JOIN 
    Ordering o ON c.CustomerID = o.CustomerID
GROUP BY 
    r.RegionID, r.RegionName;
```
Товары с низким остатком (запрос 4)
```MySQL
CREATE VIEW v_low_stock_products AS
SELECT 
    p.ProductID,
    p.ProductName,
    i.WarehouseID,
    w.Address AS WarehouseLocation,
    i.QuantityInStock,
    p.MinimumStockLevel,
    (p.MinimumStockLevel — i.QuantityInStock) AS Deficit
FROM 
    Product p
JOIN 
    Inventory i ON p.ProductID = i.ProductID
JOIN 
    Warehouse w ON i.WarehouseID = w.WarehouseID
WHERE 
    i.QuantityInStock < p.MinimumStockLevel
    AND p.IsActive = 1
ORDER BY 
    Deficit DESC;
```
Статистика по методам оплаты (запрос 5)
```MySQL
CREATE VIEW v_payment_method_stats AS
SELECT 
    pm.PaymentMethodID,
    pm.PaymentMethodName,
    COUNT(p.PaymentID) AS PaymentCount,
    SUM(p.Amount) AS TotalAmount,
    ROUND(COUNT(p.PaymentID) * 100.0 / (SELECT COUNT(*) FROM Payment), 2) AS Percentage
FROM 
    PaymentMethod pm
LEFT JOIN 
    Payment p ON pm.PaymentMethodID = p.PaymentMethodID
GROUP BY 
    pm.PaymentMethodID, pm.PaymentMethodName
ORDER BY 
    PaymentCount DESC;
```
Рейтинг сотрудников по продажам (запрос 6)
```MySQL
CREATE VIEW v_sales_performance AS
SELECT 
    e.EmployeeID,
    CONCAT(e.LastName, ' ', e.FirstName) AS EmployeeName,
    d.DepartmentName,
    COUNT(o.OrderID) AS TotalOrders,
    SUM(o.TotalAmount) AS TotalSales,
    ROUND(SUM(o.TotalAmount) * e.CommissionRate / 100, 2) AS EstimatedCommission
FROM 
    Employee e
JOIN 
    Department d ON e.DepartmentID = d.DepartmentID
JOIN 
    Ordering o ON e.EmployeeID = o.EmployeeID
WHERE 
    e.CommissionRate IS NOT NULL
GROUP BY 
    e.EmployeeID, e.LastName, e.FirstName, d.DepartmentName, e.CommissionRate
ORDER BY 
    TotalSales DESC;
```
Топ товаров по заказам (запрос 7)
```MySQL
CREATE VIEW v_top_products AS
SELECT 
    p.ProductID,
    p.ProductName,
    pc.CategoryName,
    COUNT(oi.OrderID) AS OrderCount,
    SUM(oi.Quantity) AS TotalQuantity,
    SUM(oi.Quantity * oi.UnitPrice) AS TotalRevenue
FROM 
    Product p
JOIN 
    ProductCategory pc ON p.CategoryID = pc.CategoryID
JOIN 
    OrderItem oi ON p.ProductID = oi.ProductID
JOIN 
    Ordering o ON oi.OrderID = o.OrderID
WHERE 
    p.IsActive = 1
GROUP BY 
    p.ProductID, p.ProductName, pc.CategoryName
ORDER BY 
    OrderCount DESC
LIMIT 10;
```
Заказы по названию статуса (запрос 8)
```MySQL
CREATE VIEW v_orders_with_status AS
SELECT 
    o.OrderID,
    c.CustomerName,
    os.StatusName,
    o.OrderDate,
    o.TotalAmount,
    s.ShipmentDate,
    s.EstimatedArrivalDate
FROM 
    Ordering o
JOIN 
    Customer c ON o.CustomerID = c.CustomerID
JOIN 
    OrderStatus os ON o.StatusID = os.StatusID
LEFT JOIN 
    Shipment s ON o.OrderID = s.OrderID;
```
Остатки товаров по регионам (запрос 9)
```MySQL
CREATE VIEW v_region_warehouse_stock AS
SELECT 
    r.RegionID,
    r.RegionName,
    p.ProductID,
    p.ProductName,
    SUM(i.QuantityInStock) AS TotalInStock,
    w.WarehouseID,
    w.Address AS WarehouseAddress
FROM 
    Region r
JOIN 
    Warehouse w ON r.RegionID = w.RegionID
JOIN 
    Inventory i ON w.WarehouseID = i.WarehouseID
JOIN 
    Product p ON i.ProductID = p.ProductID
GROUP BY 
    r.RegionID, r.RegionName, p.ProductID, p.ProductName, w.WarehouseID, w.Address
ORDER BY 
    r.RegionName, p.ProductName;
```
Количество сотрудников по отделам (запрос 11)
```MySQL
CREATE VIEW v_department_staff AS
SELECT 
    d.DepartmentID,
    d.DepartmentName,
    COUNT(e.EmployeeID) AS EmployeeCount,
    ROUND(AVG(e.Salary), 2) AS AverageSalary
FROM 
    Department d
LEFT JOIN 
    Employee e ON d.DepartmentID = e.DepartmentID
GROUP BY 
    d.DepartmentID, d.DepartmentName
ORDER BY 
    EmployeeCount DESC;
```
Клиенты с наибольшим количеством заказов за указанный период (запрос 10)
```MySQL
CREATE VIEW v_top_customers_last_quarter AS
SELECT 
    c.CustomerID,
    c.CustomerName,
    r.RegionName,
    COUNT(o.OrderID) AS OrderCount,
    SUM(o.TotalAmount) AS TotalSpent,
    o.OrderDate
FROM 
    Customer c
JOIN 
    Region r ON c.RegionID = r.RegionID
JOIN 
    Ordering o ON c.CustomerID = o.CustomerID
GROUP BY 
    c.CustomerID, c.CustomerName, r.RegionName, o.OrderDate
ORDER BY 
    OrderCount DESC
LIMIT 10;
Товары, которые заказывают вместе (запрос 12)
```MySQL
CREATE VIEW v_related_products AS
SELECT 
    main.ProductID AS MainProductID,
    main.ProductName AS MainProductName,
    related.ProductID AS RelatedProductID,
    related.ProductName AS RelatedProductName,
    COUNT(*) AS TimesOrderedTogether,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM OrderItem WHERE ProductID = main.ProductID), 2) AS AssociationPercentage
FROM 
    OrderItem oi1
JOIN 
    OrderItem oi2 ON oi1.OrderID = oi2.OrderID AND oi1.ProductID <> oi2.ProductID
JOIN 
    Product main ON oi1.ProductID = main.ProductID
JOIN 
    Product related ON oi2.ProductID = related.ProductID
GROUP BY 
    main.ProductID, main.ProductName, related.ProductID, related.ProductName
ORDER BY 
    TimesOrderedTogether DESC
LIMIT 20;
```

[:arrow_up:Содержание](#Содержание)


### Разграничение прав доступа
```MySQL
CREATE USER 'manager_wholesale'@'localhost' IDENTIFIED BY 'securepass123';
GRANT SELECT ON coursework_db_akbasheva.Ordering TO 'manager_wholesale'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Customer TO 'manager_wholesale'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Product TO 'manager_wholesale'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Region TO 'manager_wholesale'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Shipment TO 'manager_wholesale'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Invoice TO 'manager_wholesale'@'localhost';

CREATE USER 'order_specialist'@'localhost' IDENTIFIED BY 'orderpass456';
GRANT SELECT, INSERT, UPDATE ON coursework_db_akbasheva.Ordering TO 'order_specialist'@'localhost';
GRANT SELECT, UPDATE ON coursework_db_akbasheva.Customer TO 'order_specialist'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON coursework_db_akbasheva.Contact TO 'order_specialist'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Product TO 'order_specialist'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.OrderStatus TO 'order_specialist'@'localhost';
GRANT SELECT, INSERT ON coursework_db_akbasheva.OrderItem TO 'order_specialist'@'localhost';

CREATE USER 'customer_service'@'localhost' IDENTIFIED BY 'servicepass789';
GRANT SELECT ON coursework_db_akbasheva.Customer TO 'customer_service'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Ordering TO 'customer_service'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Shipment TO 'customer_service'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Product TO 'customer_service'@'localhost';

CREATE USER 'warehouse_worker'@'localhost' IDENTIFIED BY 'warehousepass321';
GRANT SELECT, INSERT, UPDATE ON coursework_db_akbasheva.Inventory TO 'warehouse_worker'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Warehouse TO 'warehouse_worker'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Product TO 'warehouse_worker'@'localhost';
GRANT SELECT, INSERT, UPDATE ON coursework_db_akbasheva.Shipment TO 'warehouse_worker'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.Ordering TO 'warehouse_worker'@'localhost';

CREATE USER 'accountant'@'localhost' IDENTIFIED BY 'accountpass654';
GRANT SELECT, INSERT, UPDATE ON coursework_db_akbasheva.Invoice TO 'accountant'@'localhost';
GRANT SELECT, INSERT, UPDATE ON coursework_db_akbasheva.Payment TO 'accountant'@'localhost';
GRANT SELECT, UPDATE ON coursework_db_akbasheva.Customer TO 'accountant'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON coursework_db_akbasheva.LegalDetails TO 'accountant'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON coursework_db_akbasheva.BankAccount TO 'accountant'@'localhost';

CREATE USER 'sysadmin'@'localhost' IDENTIFIED BY 'adminpass987';
GRANT ALL PRIVILEGES ON coursework_db_akbasheva.* TO 'sysadmin'@'localhost';
GRANT CREATE USER, GRANT OPTION ON *.* TO 'sysadmin'@'localhost';

GRANT SELECT ON coursework_db_akbasheva.v_top_customers_last_quarter TO 'manager_wholesale'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.v_avg_order_by_region TO 'manager_wholesale'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.v_sales_performance TO 'manager_wholesale'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.v_payment_method_stats TO 'manager_wholesale'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.v_region_warehouse_stock TO 'manager_wholesale'@'localhost';

GRANT SELECT ON coursework_db_akbasheva.v_orders_with_status TO 'order_specialist'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.v_low_stock_products TO 'order_specialist'@'localhost';

GRANT SELECT ON coursework_db_akbasheva.v_customer_with_region TO 'customer_service'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.v_orders_with_status TO 'customer_service'@'localhost';

GRANT SELECT ON coursework_db_akbasheva.v_low_stock_products TO 'warehouse_worker'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.v_region_warehouse_stock TO 'warehouse_worker'@'localhost';

GRANT SELECT ON coursework_db_akbasheva.v_payment_method_stats TO 'accountant'@'localhost';
GRANT SELECT ON coursework_db_akbasheva.v_customer_debtors TO 'accountant'@'localhost';
```

[:arrow_up:Содержание](#Содержание)

____

## Руководство пользователя

При запуске приложения пользователь должен ввести логин и пароль.

<p align="center">
<img src="https://github.com/user-attachments/assets/b74b3525-771e-47cc-b66c-277470c0167d" alt="image" style="width:30%; height:auto;">
</p>

Если логин и/или пароль не совпадут, то появится соответсвующее сообщение об ошибке.

<p align="center">
<img src="https://github.com/user-attachments/assets/259c12c8-6a11-489d-9cb5-a69526a68022" alt="image" style="width:30%; height:auto;">
</p>

Если были введены правильные логин и пароль, то перед пользователем открывается новое окно. В этом окне можно выбрать необходимую таблицу или представление. 

<p align="center">
<img src="https://github.com/user-attachments/assets/a712fdbb-c581-4624-9ae8-da3b46694d15" alt="image" style="width:50%; height:auto;">
</p>

Если у пользователя есть необходимый уровень прав, то он сможет редактировать таблицу,

<p align="center">
<img src="https://github.com/user-attachments/assets/a5b1b196-46d6-4e14-9d75-75083be0c3e1" alt="image" style="width:50%; height:auto;">
</p>

иначе – только просматривать.

<p align="center">
<img src="https://github.com/user-attachments/assets/d54eb9a6-feff-464d-aa11-6d41240bcbe7" alt="image" style="width:50%; height:auto;">
</p>

Если при редактировании таблицы пользователь введет некорректные данные, то приложение оповестит его об этом и не позволит сохранить изменения.

<p align="center">
<img src="https://github.com/user-attachments/assets/6837b7d5-3c68-4a4d-bd90-3279e2d501e3" alt="image" style="width:50%; height:auto;">
</p>

Каждому пользователю показываются только те таблицы и представления, к которым у него есть доступ. Например, специалист отдела приема заказов может взаимодействовать с таблицами и представлениями, которые связаны с заказами, но не может видеть таблицы, связанные со счетами клиентов, в отличие от бухгалтера.

Запросы позволяют получить определенные данные.

<p align="center">
<img src="https://github.com/user-attachments/assets/06b4d605-7216-4cde-8d32-b299b4b1f0e8" alt="image" style="width:40%; height:auto;">
</p>

При необходимости можно открыть дополнительное окно.
<p align="center">
<img src="https://github.com/user-attachments/assets/f992ec22-feb6-4e30-bf59-ed7e03586dc7" alt="image" style="width:50%; height:auto;">
</p>

Завершить работу приложения можно, нажав на соответствующие кнопки.

<p align="center">
<img src="https://github.com/user-attachments/assets/7bc1b462-6ca3-4b36-8ae1-b9f3bbe5a7d9" alt="image" style="width:50%; height:auto;">
</p>

[:arrow_up:Содержание](#Содержание)

____
