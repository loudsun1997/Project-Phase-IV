----------------------------------------------------------------------------------
-- Name    : Qi Yang
--
-- Course  : CS 3630
--
-- Phase IV: Creating tables and inserting records
--
-- Date    : April 26, 2019
----------------------------------------------------------------------------------

DROP TABLE UWP_Qualifications;
DROP TABLE UWP_WorkExperience;
DROP TABLE UWP_Staff;


prompt Creating table UWP_Staff
CREATE TABLE UWP_Staff(
   staffNo      char(4)   PRIMARY KEY,
   fName        varchar2(20),
   lName        varchar2(20),
   street       varchar2(40),
   city         varchar2(20),
   state        varchar2(20),
   zip          varchar2(9),
   phone        varchar2(13),
   DOB          date,
   gender       varchar2(6) CHECK (gender IN ('Male', 'Female')),
   NIN          varchar2(10),
   position     varchar2(20),
   curSalary    float,
   salaryScale  float,
   hrsPerWk     int,
   posPermTemp  varchar2(9) CHECK (posPermTemp IN ('Permanent', 'Temporary')),
   typeOfPay    varchar2(20)
);


prompt Creating table UWP_WorkExperience
CREATE TABLE UWP_WorkExperience(
   staffNo      char(4)    REFERENCES UWP_Staff,
   orgName      varchar2(20),
   position     varchar2(20),
   startDate    date,
   finishDate   date,
   PRIMARY KEY (staffNo, orgName, startDate)
);



prompt Creating table UWP_Qualifications
CREATE TABLE UWP_Qualifications(
   staffNo      char(4)    REFERENCES UWP_Staff,
   qualDate     date,
   type         varchar2(20),
   instName     varchar2(50),
   PRIMARY KEY (staffNo, type)
);



--Insert records into UWP_Staff
prompt Insert records into UWP_Staff

INSERT INTO
UWP_Staff
VALUES
('S001', 'John', 'Freeman', '101 Final Boulevard', 'Platteville', 'Wisconsin', '53818', 
 '608-867-5309', '12-APR-82', 'Male', '8888888888', 'Physician', 78400, 1000, 40,
 'Permanent', 'Salary');

INSERT INTO
UWP_Staff
VALUES
('S002', 'Gordon', 'Freeman', '8574 Main Street', 'Xomborland', 'Wisconsin', '81835', 
 '415-681-8136', '08-MAY-78', 'Male', '8999988888', 'Physician', 86400, 1500, 60,
 'Permanent', 'Salary');

INSERT INTO
UWP_Staff
VALUES
('S003', 'George', 'Fourmehn', '843 Market Street', 'Salem', 'Iowa', '53917', 
 '628-921-3816', '15-SEP-85', 'Male', '8888751388', 'Nurse', 42400, 500, 40,
 'Temporary', 'Weekly');

INSERT INTO
UWP_Staff
VALUES
('S004', 'Jolene', 'Frichtmahn', '986 Zanzabar Lane', 'Fennimore', 'Wisconsin', '53809', 
 '920-843-7286', '29-APR-85', 'Female', '8515684764', 'Director', 132400, 2500, 60,
 'Permanent', 'Salary');

INSERT INTO
UWP_Staff
VALUES
('S005', 'Jane', 'Harold', '779 Charlemagne Drive', 'Mineral Point', 'Wisconsin', '86181', 
 '836-183-3183', '16-DEC-69', 'Female', '123456890', 'Nurse', 43400, 600, 40,
 'Temporary', 'Weekly');

SELECT *
FROM UWP_Staff;


--Insert values into UWP_WorkExperience
prompt Insert records into UWP_WorkExperience
INSERT INTO
UWP_WorkExperience
VALUES
('S001', 'Southwest Hospital', 'Physician', '12-AUG-04', '25-MAR-06');

INSERT INTO
UWP_WorkExperience
VALUES
('S001', 'Medical Associate', 'Physician', '26-MAR-06', '28-MAR-06');

INSERT INTO
UWP_WorkExperience
VALUES
('S002', 'Black Mesa Clinic', 'Physician', '05-JUN-00', '06-JUL-05');

INSERT INTO
UWP_WorkExperience
VALUES
('S004', 'Riverview Hospital', 'Assistant Director', '22-MAY-07', '02-JAN-08');

INSERT INTO
UWP_WorkExperience
VALUES
('S005', 'Riverview Hospital', 'Nurse', '14-FEB-95', '02-JAN-08');

SELECT *
FROM UWP_WorkExperience;


--Insert values into UWP_Qualifications
prompt Insert records into UWP_Qualifications
INSERT INTO
UWP_Qualifications
VALUES
('S002', '22-MAY-98', 'Bachelor of Science', 'UW-Madison');

INSERT INTO
UWP_Qualifications
VALUES
('S002', '22-MAY-00', 'Master of Science', 'MIT');

INSERT INTO
UWP_Qualifications
VALUES
('S003', '21-MAY-05', 'Associate of Science', 'Midstate Technical College');

INSERT INTO
UWP_Qualifications
VALUES
('S004', '20-MAY-07', 'Bachelor of Science', 'UW-Platteville');

INSERT INTO
UWP_Qualifications
VALUES
('S005', '22-MAY-90', 'Associate of Science', 'Midstate Technical College');

SELECT *
FROM UWP_Qualifications;


--Commit the entered values
COMMIT;
