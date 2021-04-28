using System;

namespace DBSPropertyVenture
{
    class Rental : Residential
    {
        //Properties
        public double Rent { get; set; }

        //Default Constructor
        public Rental()
        {

        }

        //Methods

        //Generate Random ID
        public string generateID()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);  //just using 1000 here ideally it would be incremented using a counter

            return $"RNT{randomNumber}";
        }


        public override string ToString()
        {
            return
                    $"\nID: {ID}" +
                    $"\nAddress:" +
                    $"\n{Address} " +
                    $"\nSquare Foot: {SquareFootage} " +
                    $"\nOwners name: {OwnerName}" +
                    $"\nContact Email address: {Email} " +
                    $"\nRent price per month: {Rent}" +
                    $"\nDate entered: {DateEntered}";
        }
    }

}
