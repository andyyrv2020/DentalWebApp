-- Dentists
SET IDENTITY_INSERT Dentists ON;
INSERT INTO Dentists (Id, FirstName, LastName, Description)
VALUES
    (1, 'John', 'Smith', 'Experienced general dentist.'),
    (2, 'Emily', 'Johnson', 'Specialist in orthodontics.'),
    (3, 'Michael', 'Brown', 'Expert in pediatric dentistry.'),
    (4, 'Linda', 'Garcia', 'Periodontics specialist.'),
    (5, 'Robert', 'Martinez', 'Endodontics expert.'),
    (6, 'Jennifer', 'Rodriguez', 'Cosmetic dentistry professional.'),
    (7, 'William', 'Lee', 'Dental surgeon.'),
    (8, 'Sophia', 'Hernandez', 'Implant specialist.'),
    (9, 'David', 'Lopez', 'Oral surgery specialist.'),
    (10, 'Olivia', 'Gonzalez', 'Family dentist.');
SET IDENTITY_INSERT Dentists OFF;

-- Patients
SET IDENTITY_INSERT Patients ON;
INSERT INTO Patients (Id, FirstName, LastName, Age, DateOfBirth, PrimaryDentistId)
VALUES
    (1, 'Alice', 'Williams', 28, '1996-04-15', 1),
    (2, 'Bob', 'Miller', 35, '1989-09-23', 2),
    (3, 'Charlie', 'Davis', 12, '2012-07-10', 3),
    (4, 'Diana', 'Wilson', 45, '1979-01-20', 4),
    (5, 'Ethan', 'Moore', 33, '1991-05-30', 5),
    (6, 'Fiona', 'Taylor', 19, '2005-03-18', 6),
    (7, 'George', 'Anderson', 50, '1974-11-05', 7),
    (8, 'Hannah', 'Thomas', 27, '1997-08-22', 8),
    (9, 'Ian', 'Jackson', 40, '1984-06-14', 9),
    (10, 'Julia', 'White', 22, '2002-12-09', 10);
SET IDENTITY_INSERT Patients OFF;

-- Appointments
SET IDENTITY_INSERT Appointments ON;
INSERT INTO Appointments (Id, AppointmentDate, DentistId, PatientId, Description)
VALUES
    (1, '2024-04-10 09:30', 1, 1, 'Routine check-up'),
    (2, '2024-04-12 11:00', 2, 2, 'Orthodontic consultation'),
    (3, '2024-04-15 14:00', 3, 3, 'Dental cleaning and assessment'),
    (4, '2024-04-17 10:00', 4, 4, 'Periodontal examination'),
    (5, '2024-04-19 09:00', 5, 5, 'Root canal treatment'),
    (6, '2024-04-20 15:00', 6, 6, 'Cosmetic teeth whitening'),
    (7, '2024-04-22 12:30', 7, 7, 'Dental surgery consultation'),
    (8, '2024-04-24 13:00', 8, 8, 'Implant planning'),
    (9, '2024-04-26 11:30', 9, 9, 'Oral surgery follow-up'),
    (10, '2024-04-28 16:00', 10, 10, 'General dental check-up');
SET IDENTITY_INSERT Appointments OFF;
