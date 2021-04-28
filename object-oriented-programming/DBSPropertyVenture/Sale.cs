using System;

namespace DBSPropertyVenture
{
    class Sale : Residential
    {
        //Properties
        public EnumSalesStatus Status { get; set; }
        public double AskingPrice { get; set; }

        //Overloaded Constructor
        public Sale(EnumSalesStatus status, string address, double squareFoot, string name, string email, double price, string id)
            :base(address, squareFoot, name, email)
        {
            Status = status;
            AskingPrice = price;
            ID = generateID(id);
        }

        //Methods
        public string generateID(string id)
        {
            if (id == "") //if no id is passed (i.e we are not modifying a class) then generate a new one
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 1000); //just using 1000 here ideally it would be incremented using a counter

                return $"SL{randomNumber}";
            }
            else
            {
                return id.ToUpper(); 
            }
        }
        public override string ToString()
        {
            string statusAsString; //convert the enum to a string
            if(Status == EnumSalesStatus.For_Sale )
            {
                statusAsString = "For Sale";
            } 
            else if(Status == EnumSalesStatus.Sale_Agreed)
            {
                statusAsString = "Sale Agreed";
            }
            else
            {
                statusAsString = "Sold";
            }
            
            return 
                    $"\nID: {ID}" +
                    $"\nAddress:" +
                    $"\n{Address} " +
                    $"\nSquare Foot: {SquareFootage} " +
                    $"\nOwners name: {OwnerName}" +
                    $"\nContact Email address: {Email} " +
                    $"\nAsking price: {AskingPrice}" +
                    $"\nSales Status: {statusAsString}" +
                    $"\nDate entered: {DateEntered}";
        }



    }

}
