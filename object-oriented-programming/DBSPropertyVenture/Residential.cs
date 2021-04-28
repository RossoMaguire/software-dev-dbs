using System.Text.RegularExpressions;

namespace DBSPropertyVenture
{
    class Residential : Building
    {
        //Properties
        public double Valuation { get; set; }
        public string OwnerName { get; set; }
        public string Email { get; set; }

        public override string Address
        {
            get
            {
                return string.Join("\n", _address);
            }
            set
            {
                value = Regex.Replace(value, " *, *", ",");
                _address = value.Split(",");

                // I wanted to remove the whitespace here from after the commas if there were any, I found an answer on Stack Overflow 
                // that explained I could use Regex to achieve this:
                // https://stackoverflow.com/questions/33454971/remove-spaces-only-before-and-after-commas

            }
        }
        public override double SquareFootage { get; set; }
        public override string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }


        //Default Constructor
        public Residential()
        {

        }

        //Overloaded Constructor which we need for Sales inhertiance
        public Residential(string address, double squareFoot, string ownername, string email)
        {
            Address = address;
            SquareFootage = squareFoot;
            OwnerName = ownername;
            Email = email;
        }


    }
}
