/* PLEASE EXECUTE IN THE FOLLOWING ORDER

1. CREATE TABLES & INSERT STATEMENTS
2. STORED PROCEDURES 1 x 1 IN ORDER OF APPEARANCE
3. VIEWS 1 x 1 IN ORDER OF APPEARANCE 

*************************/

/* ******************* CREATE TABLES */
CREATE TABLE [Member] (
  [MemberID] Int Identity(1,1),
  [FirstName] Varchar(40),
  [LastName] Varchar(40),
  [Address] Varchar(100),
  [Email] Varchar(40),
  [Phone] Varchar(40),
  [DateOfBirth] Date,
  [LastLogin] Datetime,
  [IsActive] Char(1),
  PRIMARY KEY ([MemberID])
);

CREATE TABLE [PaymentPlan] (
  [PlanID] Int Identity(1,1),
  [Type] Varchar(10),
  [CommsA] Char(1),
  [CommsB] Char(1),
  [FinalPaymentDate] Date,
  [MemberID] Int,
  FOREIGN KEY (MemberID) REFERENCES Member([MemberID])
  ON DELETE CASCADE,
  PRIMARY KEY ([PlanID])
);

CREATE TABLE [GymCard] (
  [CardNo] Int Identity(1,1),
  [Photo] Image,
  [IsActive] Char(1),
  [MemberID] Int,
  FOREIGN KEY (MemberID) REFERENCES Member([MemberID])
  ON DELETE CASCADE,
  PRIMARY KEY ([CardNo])
);


CREATE TABLE [Trainer] (
  [TrainerID] Int Identity(1,1),
  [FirstName] Varchar(40),
  [LastName] Varchar(40),
  [Phone] Varchar(40),
  [DateOfBirth] Date,
  [Address] Varchar(40),
  [Email] Varchar(40),
  [PPS] Varchar(40),
  PRIMARY KEY ([TrainerID])
);

CREATE TABLE [Program] (
  [ProgramID] Int Identity(1,1),
  [MemberID] Int,
  [TrainerID] Int,
  [Name] Varchar(40),
  [Description] Varchar(300),
  [DateCreated] Date,
  PRIMARY KEY ([ProgramID]),
  FOREIGN KEY ([MemberID]) REFERENCES Member([MemberID])
  ON DELETE CASCADE,
  FOREIGN KEY ([TrainerID]) REFERENCES Trainer([TrainerID])
);

CREATE TABLE [Exercise] (
  [ExerciseID] Int Identity(1,1),
  [ProgramID] Int,
  [Machine] Varchar(40),
  [WeightKG] Decimal,
  [Reps] Int,
  [TargetArea] Varchar(40),
  PRIMARY KEY ([ExerciseID]),
  FOREIGN KEY ([ProgramID]) REFERENCES Program([ProgramID])
  ON DELETE CASCADE 
);


/* *************************** INSERT INITIAL DATA */
INSERT INTO Member 
VALUES 
('****', '****', '****, Kimmage', '****@****', '****', '05-01-1989', '12-02-2019 14:52:02', 'Y'),
('****', '****', '****, Athgarvan', '****@****', '****', '10-17-1990', NULL, 'Y'),
('****', '****', '10 Ashgrove, ****', '****@****', '0860****', '02-12-1990',  '01-02-2019 14:52:02', 'Y'),
('****', '****', '22 ****, Clane', '****@****', '0872186633', '10-18-1989',  '07-13-2019 14:52:02', 'Y'),
('****', '****', '181 ****', '****@****', '****', '11-23-1989', '11-09-2019 14:52:02', 'Y'),
('****', '****', '20 ****', '****@****', '****', '06/09/1972', '04-12-2019', 'N'),
('****', '****', '212 ****, Dublin', '****@****', '0834587634', '05-14-1981',  NULL, 'Y');

SELECT * FROM Member

INSERT INTO PaymentPlan 
VALUES 
('Monthly', 'Y', 'Y', '12-01-2020', '1'),
('Annual', 'Y', 'N',  '05-28-2021', '2'),
('Quarterly', 'N', 'N', '10-20-2020', '3'),
('Annually', 'N', 'Y', '06-28-2021', '4'),
('Quarterly', 'Y', 'Y', '10-17-2020', '5'),
('Monthly', 'N', 'N', '04-12-2019', '6'),
('Monthly', 'Y', 'N', '01-12-2020', '7');

SELECT * FROM PaymentPlan

INSERT INTO Trainer 
VALUES 
('****', '****', '****', '01-17-1984', '22 The Meadows, Rathmines', '****@****', '894576Y'),
('****', '****', '****', '06-28-1991', '****, Harolds Cross', '****@****', '893596K'),
('****', '****', '****', '10-12-1993', '35 Old Town, Naas', '****@****', '997596J'),
('****', '****', '****', '04-09-1988', 'Apt 4 ****, Dublin', '****@****', '8827240P');

SELECT * FROM Trainer


INSERT INTO Program
VALUES
('2', '1', 'Bulk Up', 'Build Muscle over the course of a few months', '04-01-2020'),
('4', '1', 'Beginner', 'Simple exercises to get into a routine', '04-22-2020'),
('6', '3', 'Sports Performance', 'Specific plan for runners endurance', '06-13-2019'),
('7', '4', 'Ab Workout', 'Workout focused on abs', '09-03-2019'),
('1', '3', 'Beginner Plan', 'Simple workouts to ease into the gym', '05-28-2020');

SELECT * FROM Program

INSERT INTO GymCard
VALUES
(NULL, 'Y', '1'),
(NULL, 'Y', '7'),
(NULL, 'Y', '3'),
(NULL, 'Y', '4'),
(NULL, 'Y', '5'),
(NULL, 'N', '6'),
(NULL, 'N', '2'),
(NULL, 'N', '3'),
(NULL, 'N', '4'),
(NULL, 'N', '6');


INSERT INTO Exercise
VALUES
('4', 'Ab Crunch', '25.5', '30', 'abs'),
('4', 'Sit ups', '14', '30', 'abs'),
('4', 'Treadmill', NULL, NULL, 'cardio'),
('5', 'Lat Pulldown', '25.5', '10', 'lats'),
('5', 'Chest Press', '15', '10', 'chest'),
('5', 'Multi Hip', '25', '10', 'hips'),
('3', 'Sit ups', '25.5', '50', 'abs'),
('3', 'Treadmill 30mins', NULL, NULL, 'cardio'),
('3', 'Hack Squat', '25', '10', 'Torso'),
('2', 'Dumbells', '25.5', '10', 'bicep'),
('2', 'Leg Extension', '25.5', '10', 'legs'),
('2', 'Shoulder Press', '25', '10', 'Shoulders')

/* ************************** CREATE STORED PROCEDURES */
/* Please do 1 by 1 */

/* Create Member */
CREATE PROC usp_NewMember 
@FirstName Varchar(40),
@LastName Varchar(40),
@Address Varchar(40),
@Email Varchar (40),
@Phone Varchar (40),
@DOB Date
AS
BEGIN TRAN
INSERT INTO Member 
VALUES
(@FirstName, @LastName, @Address, @Email, @Phone, @DOB, NULL, 'Y')
IF @@ROWCOUNT <> 1 /* Just do a check we are affecting no more or less than 1 row */
 ROLLBACK
ELSE 
 COMMIT 
GO

/* Create Program */
CREATE PROC usp_NewProgram 
@MemberID Int,
@TrainerID Int,
@ProgramName Varchar(40),
@ProgramDesc Varchar (40)
AS
BEGIN TRAN
INSERT INTO Program 
VALUES
(@MemberID, @TrainerID, @ProgramName, @ProgramDesc, GETDATE())
IF @@ROWCOUNT <> 1 /* Just do a check we are affecting no more or less than 1 row */
 ROLLBACK
ELSE 
 COMMIT 
GO

  /* Add Excercises to Program */
    CREATE PROC usp_AddExercise
	@ProgramID Int,
	@Machine Varchar(40),
	@WeightKG Decimal,
	@Reps Int,
	@TargetArea Varchar(40)
	AS
	BEGIN TRAN
	INSERT INTO Exercise 
	VALUES
	(@ProgramID, @Machine, @WeightKG, @Reps, @TargetArea)
	IF @@ROWCOUNT <> 1 /* Just do a check we are affecting no more or less than 1 row */
	 ROLLBACK
	ELSE 
	 COMMIT 
	GO

/* Create Trainer */
CREATE PROC usp_NewTrainer 
@FirstName Varchar(40),
@LastName Varchar(40),
@Phone Varchar(40),
@DOB Date,
@Address Varchar(40),
@Email Varchar (40),
@PPS varchar (40)
AS
BEGIN TRAN
INSERT INTO Trainer 
VALUES
(@FirstName, @LastName, @Phone, @DOB, @Address, @Email, @PPS)
IF @@ROWCOUNT <> 1 /* Just do a check we are affecting no more or less than 1 row */
 ROLLBACK
ELSE 
 COMMIT 
GO


	/* Soft delete member */
	CREATE PROC usp_Soft_Delete_Member
	@MemberID Int,
	@Email Varchar(40)
	AS
	BEGIN TRAN
		UPDATE Member
		SET Address = 'GDPR', Phone = 'GDPR', DateOfBirth = NULL, IsActive = 'N'
		WHERE MemberID = @MemberID AND Email = @Email
		IF @@ROWCOUNT <> 1 /* Just do a check we are affecting no more or less than 1 row */
	       ROLLBACK
		ELSE 
		   COMMIT 
		GO

	/* Hard delete member */
	CREATE PROC usp_Hard_Delete_Member
	@MemberID Int,
	@Email Varchar(40)
	AS
	BEGIN TRAN
		IF exists (SELECT FinalPaymentDate FROM PaymentPlan /* check if the payment is older than 3 days */
		WHERE PaymentPlan.MemberID = @MemberID AND datediff(dd,FinalPaymentDate, GetDate()) > 30)
		Begin
		DELETE FROM Member
		WHERE MemberID = @MemberID AND Email = @Email
		End
		Else 
		print 'Will be deleted when final payment date is past 30 days'
		IF @@ROWCOUNT <> 1 /* Just do a check we are affecting no more or less than 1 row */
	       ROLLBACK
		ELSE 
		   COMMIT 
		GO

		/* Delete Member */
CREATE PROC usp_Delete_Member
@MemberID Int,
@Email Varchar(40)
AS
	IF EXISTS /* Check if sthey have comms b ticked or not */
	(SELECT CommsB FROM PaymentPlan
	WHERE MemberID = @MemberID AND CommsB = 'Y')
	Begin
    EXEC usp_Soft_Delete_Member /* Do soft delete */
	     @MemberID = @MemberID,
		 @Email = @Email
		 End

    IF EXISTS
	(SELECT CommsB FROM PaymentPlan
	WHERE MemberID = @MemberID AND CommsB = 'N')
	Begin
    EXEC usp_Hard_Delete_Member /* Do hard delete */
	@MemberID = @MemberID,
		 @Email = @Email
		 End
/* *************************** CREATE VIEWS */
/* Please do 1 by 1 */

/* MI Extract */
CREATE VIEW VW_MI_Single_View
AS
SELECT Member.MemberID, Member.FirstName, Member.LastName, Member.Address, 
Member.Email, Member.Phone, Member.DateOfBirth, IsActive,
ProgramID, Name AS ProgramName, Description, DateCreated, Trainer.TrainerID, 
Trainer.FirstName AS TrainerFirstName, Trainer.LastName AS TrainerLastName, 
Trainer.Phone AS TrainerPhone, Trainer.DateOfBirth AS TrainerDOB, 
Trainer.Address AS TrainerAddr, Trainer.Email AS TrainerEmail, PPS
FROM Member
INNER JOIN Program
ON Member.MemberID = Program.MemberID
INNER JOIN Trainer
ON Trainer.TrainerID = Program.TrainerID
WHERE Member.IsActive = 'Y'



/* Deleted Member View */
CREATE VIEW VW_Deleted_Members
AS
SELECT Member.MemberID, FirstName, LastName, Address, Email, Phone, DateOfBirth, LastLogin, 
IsActive, PlanID, Type, CommsA, CommsB, FinalPaymentDate  FROM Member
INNER JOIN PaymentPlan
ON Member.MemberID = PaymentPlan.MemberID
WHERE Member.IsActive = 'N' 
AND PaymentPlan.CommsB = 'Y'

















