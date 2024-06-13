-- Создание базы данных
CREATE DATABASE EMiasDB;
GO

-- Использование базы данных
USE EMiasDB;
GO

-- Создание таблицы Specialities
CREATE TABLE Specialities (
    IdSpeciality INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);
GO

-- Создание таблицы Status
CREATE TABLE Status (
    IdStatus INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);
GO

-- Создание таблицы Patient
CREATE TABLE Patient (
    OMS BIGINT IDENTITY PRIMARY KEY,
    Surname NVARCHAR(50) NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    Patronymic NVARCHAR(50) NULL,
    BirthDate DATE NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    LivingAddress NVARCHAR(255) NULL,
    Phone NVARCHAR(18) NULL,
    Email NVARCHAR(50) NULL,
    Nickname NVARCHAR(50) NULL
);
GO

-- Создание таблицы Doctor
CREATE TABLE Doctor (
    IdDoctor INT IDENTITY PRIMARY KEY,
    Surname NVARCHAR(50) NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    Patronymic NVARCHAR(50) NULL,
    IdSpeciality INT NOT NULL FOREIGN KEY REFERENCES Specialities(IdSpeciality),
    EnterPassword NVARCHAR(50) NOT NULL,
    WorkAddress NVARCHAR(50) NOT NULL
);
GO

-- Создание таблицы Directions
CREATE TABLE Directions (
    IdDirection INT IDENTITY PRIMARY KEY,
    IdSpeciality INT NOT NULL FOREIGN KEY REFERENCES Specialities(IdSpeciality),
    OMS BIGINT NOT NULL FOREIGN KEY REFERENCES Patient(OMS)
);
GO

-- Создание таблицы Appointments
CREATE TABLE Appointments (
    IdAppointment INT IDENTITY PRIMARY KEY,
    OMS BIGINT NULL FOREIGN KEY REFERENCES Patient(OMS),
    IdDoctor INT NOT NULL FOREIGN KEY REFERENCES Doctor(IdDoctor),
    AppointmentDate DATE NOT NULL,
    AppointmentTime TIME NOT NULL,
    IdStatus INT NULL FOREIGN KEY REFERENCES Status(IdStatus)
);
GO

-- Создание таблицы AppointmentDocument
CREATE TABLE AppointmentDocument (
    IdAppointment INT NOT NULL FOREIGN KEY REFERENCES Appointments(IdAppointment),
    Rtf NVARCHAR(MAX) NOT NULL
);
GO

-- Создание таблицы AnalysDocument
CREATE TABLE AnalysDocument (
    IdAppointment INT NOT NULL FOREIGN KEY REFERENCES Appointments(IdAppointment),
    Rtf NVARCHAR(MAX) NOT NULL
);
GO

-- Создание таблицы ResearchDocument
CREATE TABLE ResearchDocument (
    IdAppointment INT NOT NULL FOREIGN KEY REFERENCES Appointments(IdAppointment),
    Rtf NVARCHAR(MAX) NOT NULL,
    Attachment VARBINARY(MAX) NULL
);
GO

-- Создание таблицы Admin
CREATE TABLE Admin (
    IdAdmin INT IDENTITY PRIMARY KEY,
    Surname NVARCHAR(50) NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    Patronymic NVARCHAR(50) NULL,
    EnterPassword NVARCHAR(50) NOT NULL
);
GO
