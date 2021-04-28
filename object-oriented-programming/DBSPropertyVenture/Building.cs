using System;

namespace DBSPropertyVenture
{
    abstract class Building
    {
        //Fields
        protected string[] _address;
        protected string _dateEntered;
        protected string _id;

        //Properties
        public abstract string Address { get; set; }
        public abstract double SquareFootage { get; set; }
        public abstract string ID { get; set; }
        public string DateEntered
        {
            get
            {
                return _dateEntered;
            }

            set
            {
                _dateEntered = value;
            }
        }


        //Constructor
        public Building()
        {
            //everytime an instance is created it would save the date 
            DateTime date = DateTime.Today;
            DateEntered = date.ToString();

            //TODO: Would like to to rework this in future so it doesn't save new date for a "modified" listing


        }

    }
}
