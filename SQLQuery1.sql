CREATE DATABASE DepartmentDB;
USE DepartmentDB;
DROP DATABASE DepartmentDB;

--Отделы предприятия
CREATE TABLE Departments(
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100),
    DepartmentDescription NVARCHAR(MAX)
);

--Далжности сотрудников
CREATE TABLE PostStaffs (
    PostID INT PRIMARY KEY IDENTITY(1,1),
    PostName NVARCHAR(100)
);

--Сотрудники
CREATE TABLE Staff (
    StaffID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(200),
    PostID INT FOREIGN KEY REFERENCES PostStaffs(PostID),
    Passport NVARCHAR(50),
    INN NVARCHAR(12),
    CertificateNumber NVARCHAR(14),
    Phone NVARCHAR(15),
    Education NVARCHAR(200),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID)
);

--Типы контрактов
CREATE TABLE ContractTypes (
    ContractTypeID INT PRIMARY KEY IDENTITY(1,1),
    ContractType NVARCHAR(50)
);

--Трудовой договор
CREATE TABLE Contracts (
    ContractID INT PRIMARY KEY IDENTITY(1,1),
    StaffID INT FOREIGN KEY REFERENCES Staff(StaffID),
    ContractTypeID INT FOREIGN KEY REFERENCES ContractTypes(ContractTypeID),
    ContractNumber NVARCHAR(50),
    DateСonclusion DATE,
    WorkDetails NVARCHAR(MAX),
    PaymentInformation DECIMAL(20, 2)
);

--Вакансии
CREATE TABLE Vacancies (
    VacancyID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Post NVARCHAR(100),
    Description NVARCHAR(MAX),
    PaymentInformation DECIMAL(18, 2),
    IsOpen BIT DEFAULT 1
);

INSERT INTO Departments (DepartmentName, DepartmentDescription)
VALUES 
('Маркетинг', 'Отдел, занимающийся продвижением продукции и исследованиями рынка.'),
('Финансовый', 'Отдел, отвечающий за финансовое планирование и учет.'),
('IT', 'Отдел информационных технологий, разрабатывающий и поддерживающий системы.'),
('HR', 'Отдел по управлению персоналом, занимается подбором и обучением сотрудников.');

INSERT INTO PostStaffs (PostName)
VALUES 
('Бухгалтер'),
('Аналитик'),
('Менеджер по персоналу'),
('Директор'),
('Помощник менеджера');

INSERT INTO ContractTypes (ContractType)
VALUES 
('Краткосрочный'),
('Долгосрочный'),
('Повременный');

INSERT INTO Staff (FullName, PostID, Passport, INN, CertificateNumber, Phone, Education, DepartmentID)
VALUES 
('Иванов Александр Николаевич', (SELECT PostID FROM PostStaffs WHERE PostName = 'Бухгалтер'), '1111 222233', '987654321012', '987-654-321 03', '+79995559988', 'Высшее', 1),
('Петрова Ольга Игоревна', (SELECT PostID FROM PostStaffs WHERE PostName = 'Аналитик'), '3333 444455', '876543210987', '654-321-789 04', '+79265552345', 'Высшее', 2),
('Сидоров Игорь Васильевич', (SELECT PostID FROM PostStaffs WHERE PostName = 'Менеджер по персоналу'), '5555 666677', '765432109876', '345-678-901 05', '+79876543210', 'Высшее', 3);

INSERT INTO Contracts (StaffID, ContractTypeID, ContractNumber, DateСonclusion, WorkDetails, PaymentInformation)
VALUES 
(1, (SELECT ContractTypeID FROM ContractTypes WHERE ContractType = 'Долгосрочный'), 'A1234', '2023-01-01', 'Управление маркетинговыми проектами, продвижение бренда.', 50000.00),
(2, (SELECT ContractTypeID FROM ContractTypes WHERE ContractType = 'Краткосрочный'), 'B5678', '2023-03-01', 'Поддержка и помощь в управлении проектами.', 25000.00),
(3, (SELECT ContractTypeID FROM ContractTypes WHERE ContractType = 'Долгосрочный'), 'C2345', '2022-06-01', 'Ведение бухгалтерии, финансовое планирование.', 60000.00);

INSERT INTO Vacancies (DepartmentID, Post, Description, PaymentInformation, IsOpen)
VALUES 
(1, 'Менеджер по рекламе', 'Поиск и реализация рекламных кампаний для продвижения продукции.', 70000.00, 1), 
(2, 'Финансовый аналитик', 'Анализ финансовых отчетов и планирование бюджета компании.', 80000.00, 1),
(3, 'Программист', 'Разработка и поддержка веб-приложений и внутренних систем.', 90000.00, 1),
(4, 'HR менеджер', 'Подбор персонала, организация тренингов и поддержка сотрудников.', 60000.00, 1);

--Прием сотрудников
INSERT INTO Staff (FullName, PostID, Passport, INN, CertificateNumber, Phone, Education, DepartmentID)
VALUES 
('Ермакова Екатерина Сергеевна', (SELECT PostID FROM PostStaffs WHERE PostName = 'Менеджер'), '1234 567890', '123456789012', '123-456-789 01', '+79051456511', 'Среднее', 1);

INSERT INTO Staff (FullName, PostID, Passport, INN, CertificateNumber, Phone, Education, DepartmentID)
VALUES 
('Вершинин Глеб Ильич', (SELECT PostID FROM PostStaffs WHERE PostName = 'Помощник менеджера'), '4321 098765', '098765432109', '123-457-799 02', '+79999999999', 'Среднее', 2);

--Увольнение сотрудников
DELETE FROM Contracts
WHERE StaffID = 3;
DELETE FROM Staff
WHERE StaffID = 3;

--Открытие новых отделов
INSERT INTO Departments (DepartmentName, DepartmentDescription)
VALUES ('Маркетинг', 'Отдел продвижения продукции');

--Изменение данных о сотрудниках
UPDATE Staff
SET PostID = (SELECT PostID FROM PostStaffs WHERE PostName = 'Директор'), 
    Phone = '+79050552516', 
    Education = 'Высшее'
WHERE StaffID = 4;

--Переход работника в другой отдел
UPDATE Staff
SET DepartmentID = 2 
WHERE StaffID = 4;

--Вывод списка сотрудников заданного отдела
SELECT S.StaffID, S.FullName, PS.PostName, S.Phone
FROM Staff S
JOIN PostStaffs PS ON S.PostID = PS.PostID
WHERE S.DepartmentID = 2;

--Вывод списка вакансий по всем отделам
SELECT V.VacancyID, D.DepartmentName, V.Post, V.PaymentInformation, V.IsOpen
FROM Vacancies V
JOIN Departments D ON V.DepartmentID = D.DepartmentID;

--Вывод информации о заданном работнике предприятия
SELECT S.StaffID, S.FullName, PS.PostName, S.CertificateNumber, 
       S.Phone, D.DepartmentName
FROM Staff S
JOIN Departments D ON S.DepartmentID = D.DepartmentID
JOIN PostStaffs PS ON S.PostID = PS.PostID
WHERE S.StaffID = 5;

SELECT * FROM Departments;
SELECT * FROM Staff;
SELECT * FROM Contracts;
SELECT * FROM Vacancies;