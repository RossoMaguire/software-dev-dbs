/* Form a Program by selecting all its execrices by ProgramID */
SELECT ExerciseID, Machine, WeightKG, Reps, TargetArea
FROM Exercise
WHERE 
Exercise.ProgramID = '4'

/* Test the MI Single View */
SELECT * FROM VW_MI_Single_View

/* Test Create Member SP */
EXEC usp_NewMember 
@FirstName = '****',
@LastName = '****',
@Address = '****',
@Email = '****@****',
@Phone = '0867549834',
@DOB = '10/16/1984'

/* Test it worked */
SELECT * FROM Member WHERE Email = '****@****'


/* Test Create New Program */
EXEC usp_NewProgram
@MemberID = '8',
@TrainerID = '4',
@ProgramName = 'Intermediate Cardio',
@ProgramDesc = 'Some medium weight cardio exercises'

/* Test adding an exercise to the Program */
EXEC usp_AddExercise
@ProgramID = '6',
@Machine = 'Tread Mill',
@WeightKG = NULL,
@Reps = NULL,
@TargetArea = 'Run for 45 mins on treadmill'

/* Test it worked */
SELECT * FROM Program WHERE Name = 'Intermediate Cardio'
SELECT * FROM Exercise WHERE ProgramID = '6'

/* Test Create New Trainer */
EXEC usp_NewTrainer
@FirstName = '****',
@LastName = '****',
@Phone = '0873482395',
@DOB = '05-14-1990',
@Address = '****',
@Email = '****@g****',
@PPS = '8020184Y'

/* Test it worked */
SELECT * FROM Trainer WHERE PPS = '****'


/*Test Hard Delete member SP on it's own */
EXEC usp_Hard_Delete_Member
@MemberID = '7',
@Email = '****@hotmail.com'

/* Test Soft Delete Member SP on it's own */
EXEC usp_Soft_Delete_Member
@MemberID = 4,
@Email = '****@hotmail.com'

/* Test it worked 
Gillan should be deleted, mason should be GDPR'd */
SELECT * FROM Member


/*********** Quick tool for viewing records needed for test */
/*Select all records with older than 30 days payment date and comms N */
SELECT * FROM PaymentPlan
INNER JOIN Member
ON Member.MemberID = PaymentPlan.MemberID
WHERE datediff(dd,FinalPaymentDate, GetDate()) > 30 AND CommsB = 'N'

/* Test Generic Delete Member SP with a member who final payment
is over 30 days and comms b is not ticked so will be hard deleted */
EXEC usp_Delete_Member
@MemberID = '6',
@Email = '****@gmail.com'

/* Test it worked */
SELECT * FROM Member

/* Test Generic Delete Member SP with a member who final payment
is less 30 days and comms b is not ticked so will return a message */
EXEC usp_Delete_Member
@MemberID = '3',
@Email = '****@gmail.com'

/* Test Generic Delete Member SP with member who
comms b is ticked so will be soft deleted */
EXEC usp_Delete_Member
@MemberID = '5',
@Email = '****@hotmail.com'

/* Test it worked */
SELECT * FROM Member

/* Test the Soft Deleted Members View */
SELECT * FROM VW_Deleted_Members







 
