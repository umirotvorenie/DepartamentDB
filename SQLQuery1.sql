CREATE DATABASE DepartmentDB;
USE DepartmentDB;
DROP DATABASE DepartmentDB;

--������ �����������
CREATE TABLE Departments(
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100),
    DepartmentDescription NVARCHAR(MAX)
);

--��������� �����������
CREATE TABLE PostStaffs (
    PostID INT PRIMARY KEY IDENTITY(1,1),
    PostName NVARCHAR(100)
);

--����������
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

--���� ����������
CREATE TABLE ContractTypes (
    ContractTypeID INT PRIMARY KEY IDENTITY(1,1),
    ContractType NVARCHAR(50)
);

--�������� �������
CREATE TABLE Contracts (
    ContractID INT PRIMARY KEY IDENTITY(1,1),
    StaffID INT FOREIGN KEY REFERENCES Staff(StaffID),
    ContractTypeID INT FOREIGN KEY REFERENCES ContractTypes(ContractTypeID),
    ContractNumber NVARCHAR(50),
    Date�onclusion DATE,
    WorkDetails NVARCHAR(MAX),
    PaymentInformation DECIMAL(20, 2)
);

--��������
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
('���������', '�����, ������������ ������������ ��������� � �������������� �����.'),
('����������', '�����, ���������� �� ���������� ������������ � ����.'),
('IT', '����� �������������� ����������, ��������������� � �������������� �������.'),
('HR', '����� �� ���������� ����������, ���������� �������� � ��������� �����������.');

INSERT INTO PostStaffs (PostName)
VALUES 
('���������'),
('��������'),
('�������� �� ���������'),
('��������'),
('�������� ���������');

INSERT INTO ContractTypes (ContractType)
VALUES 
('�������������'),
('������������'),
('�����������');

INSERT INTO Staff (FullName, PostID, Passport, INN, CertificateNumber, Phone, Education, DepartmentID)
VALUES 
('������ ��������� ����������', (SELECT PostID FROM PostStaffs WHERE PostName = '���������'), '1111 222233', '987654321012', '987-654-321 03', '+79995559988', '������', 1),
('������� ����� ��������', (SELECT PostID FROM PostStaffs WHERE PostName = '��������'), '3333 444455', '876543210987', '654-321-789 04', '+79265552345', '������', 2),
('������� ����� ����������', (SELECT PostID FROM PostStaffs WHERE PostName = '�������� �� ���������'), '5555 666677', '765432109876', '345-678-901 05', '+79876543210', '������', 3);

INSERT INTO Contracts (StaffID, ContractTypeID, ContractNumber, Date�onclusion, WorkDetails, PaymentInformation)
VALUES 
(1, (SELECT ContractTypeID FROM ContractTypes WHERE ContractType = '������������'), 'A1234', '2023-01-01', '���������� �������������� ���������, ����������� ������.', 50000.00),
(2, (SELECT ContractTypeID FROM ContractTypes WHERE ContractType = '�������������'), 'B5678', '2023-03-01', '��������� � ������ � ���������� ���������.', 25000.00),
(3, (SELECT ContractTypeID FROM ContractTypes WHERE ContractType = '������������'), 'C2345', '2022-06-01', '������� �����������, ���������� ������������.', 60000.00);

INSERT INTO Vacancies (DepartmentID, Post, Description, PaymentInformation, IsOpen)
VALUES 
(1, '�������� �� �������', '����� � ���������� ��������� �������� ��� ����������� ���������.', 70000.00, 1), 
(2, '���������� ��������', '������ ���������� ������� � ������������ ������� ��������.', 80000.00, 1),
(3, '�����������', '���������� � ��������� ���-���������� � ���������� ������.', 90000.00, 1),
(4, 'HR ��������', '������ ���������, ����������� ��������� � ��������� �����������.', 60000.00, 1);

--����� �����������
INSERT INTO Staff (FullName, PostID, Passport, INN, CertificateNumber, Phone, Education, DepartmentID)
VALUES 
('�������� ��������� ���������', (SELECT PostID FROM PostStaffs WHERE PostName = '��������'), '1234 567890', '123456789012', '123-456-789 01', '+79051456511', '�������', 1);

INSERT INTO Staff (FullName, PostID, Passport, INN, CertificateNumber, Phone, Education, DepartmentID)
VALUES 
('�������� ���� �����', (SELECT PostID FROM PostStaffs WHERE PostName = '�������� ���������'), '4321 098765', '098765432109', '123-457-799 02', '+79999999999', '�������', 2);

--���������� �����������
DELETE FROM Contracts
WHERE StaffID = 3;
DELETE FROM Staff
WHERE StaffID = 3;

--�������� ����� �������
INSERT INTO Departments (DepartmentName, DepartmentDescription)
VALUES ('���������', '����� ����������� ���������');

--��������� ������ � �����������
UPDATE Staff
SET PostID = (SELECT PostID FROM PostStaffs WHERE PostName = '��������'), 
    Phone = '+79050552516', 
    Education = '������'
WHERE StaffID = 4;

--������� ��������� � ������ �����
UPDATE Staff
SET DepartmentID = 2 
WHERE StaffID = 4;

--����� ������ ����������� ��������� ������
SELECT S.StaffID, S.FullName, PS.PostName, S.Phone
FROM Staff S
JOIN PostStaffs PS ON S.PostID = PS.PostID
WHERE S.DepartmentID = 2;

--����� ������ �������� �� ���� �������
SELECT V.VacancyID, D.DepartmentName, V.Post, V.PaymentInformation, V.IsOpen
FROM Vacancies V
JOIN Departments D ON V.DepartmentID = D.DepartmentID;

--����� ���������� � �������� ��������� �����������
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