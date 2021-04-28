using System;
using System.Text.RegularExpressions;

namespace DBSPropertyVenture
{
    class CommercialBuild : Building
    {
        //Properties
        public double Rates { set; get; }
        public EnumIntendedPurpose IntendedPurpose { get; set; }
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
        public CommercialBuild()
        {
        }

        //Methods
        public double calculateRates(double rate)
        {
            double annualRateOnValuation = .268; //this changes every year based on DCSS annual budget meeting
            return rate * annualRateOnValuation;
        }

        public string generateID()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);  //just using 1000 here ideally it would be incremented using a counter

            return $"CB{randomNumber}";
        }

        public override string ToString()
        {
            return 
                    $"\nID: {ID}" +
                    $"\nAddress:" +
                    $"\n{Address} " +
                    $"\nSquare Foot: {SquareFootage} " +
                    $"\nIntended Purpose: { IntendedPurpose } " +
                    $"\nRates: {calculateRates(Rates)} per year at {Rates} provided rate" +
                    $"\nDate entered: {DateEntered}";

        }

    }
}
