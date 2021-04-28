using System;
using System.Text.RegularExpressions;

namespace DBSPropertyVenture
{
class Application : IUtilities
{
////////////////////////////////
/////APPLICATION STARTED
///////////////////////////////
private bool _appRunning;

private bool AppRunning
{
    get
    {
        return _appRunning;
    }

    set
    {
        _appRunning = value;
    }
}
public Application(bool running)
{

    AppRunning = running;

}

public void RunApp()
{

    Listings propertyListings = new Listings(); //setup the list to hold the properties

    // Creating existing instances for Sales properties which have sold or sale agreed
    createTestData(propertyListings);
    //  I do this because a sale that is being added first time through the menu will be for sale by default the user can only change
    //    this if modifying , so I'm assuming that anything with sold or sale agreed has been modified sometime previous by a user, you 
    //      can see these by showing all Sales listing on start up


    Console.WriteLine("********************************");
    Console.WriteLine("WELCOME TO DBS PROPERTY");
    Console.WriteLine("********************************");

    // Menu
    do
    {
        Console.WriteLine();
        Console.WriteLine(" --------- MENU ---------");
        Console.WriteLine("What would you like to do today?");
        Console.WriteLine("(Enter the number corressponding to the action)");
        Console.WriteLine("1 - Add new Commercial Property");
        Console.WriteLine("2 - Add new Residential Property");
        Console.WriteLine("3 - Show all Commercial Listings");
        Console.WriteLine("4 - Show all Rental Listings");
        Console.WriteLine("5 - Show all Sales Listings");
        Console.WriteLine("6 - Modify a listing");
        Console.WriteLine("7 - Quit application");

        //error handling the user input
        int action;
        do
        {
            //check if its a number
            if (!int.TryParse(Console.ReadLine(), out action))
            {
                notOptionError();
            }

            else if (action != 0 && action < 1 || action > 7)
            {
                notOptionError();
                action = 0;
            }
        } while (action == 0);

        //check what the input was and call the corressponding method
        switch (action)
        {
            case 1: //add a commerical property
                Console.WriteLine();
                Console.WriteLine("Thank you. Let's get your Commercial Property added");
                addCommercialProperty(propertyListings, "");
                break;

            case 2: //add a residential property
                int rentalOrSale = 0;
                do
                {
                    Console.WriteLine("Is this property a rental or a sale?");
                    Console.WriteLine("(Enter the number corressponding to the action)");
                    Console.WriteLine("1 - Rental");
                    Console.WriteLine("2 - Sale");

                    if (!int.TryParse(Console.ReadLine(), out rentalOrSale))
                    {
                        notOptionError();
                    }
                    else if (rentalOrSale != 0 && rentalOrSale < 1 || rentalOrSale > 2)
                    {
                        notOptionError();
                        rentalOrSale = 0;
                    }
                } while (rentalOrSale == 0);

                if (rentalOrSale == 1)
                {
                       Console.WriteLine();
                       Console.WriteLine("Thank you. Let's get your Rental property added");
                        addRentalProperty(propertyListings, "");
                }
                else if(rentalOrSale == 2)
                {
                        Console.WriteLine();
                        Console.WriteLine("Thank you. Let's get your Sales property added");
                        addSalesProperty(propertyListings, "");
                }
                break;

            case 3: //show commerical listings
                if(propertyListings.GetListings(EnumListingTypes.CommercialBuilds))
                {
                    bool showingCommercialList = true;
                    while (showingCommercialList)
                    {
                        Console.WriteLine("Press x to close list");
                        if (Console.ReadLine() == "x")
                        {
                            Console.Clear();
                            showingCommercialList = false;
                        }
                    }
                }
                else
                {
                        Console.WriteLine();
                        Console.WriteLine("There are no Commerical properties in our system yet");
                }
                break;

            case 4: //show rental listings
                if (propertyListings.GetListings(EnumListingTypes.Rentals))
                {
                    bool showingRentalList = true;
                    while (showingRentalList)
                    {
                        Console.WriteLine("Press x to go close list");
                        if (Console.ReadLine() == "x")
                        {
                            Console.Clear();
                            showingRentalList = false;
                        }
                    }
                }
                else
                {
                        Console.WriteLine();
                        Console.WriteLine("There are no Rental properties in our system yet");
                }
                break;

            case 5: //show sales listings
                if (propertyListings.GetListings(EnumListingTypes.Sales))
                {
                    bool showingSalesList = true;
                    while (showingSalesList)
                    {

                        Console.WriteLine("Press x to go close list");
                        if (Console.ReadLine() == "x")
                        {
                            Console.Clear();
                            showingSalesList = false;
                        }
                    }
                }
                else
                {
                        Console.WriteLine();
                        Console.WriteLine("There are no Sales properties in our system yet");
                }
                break;

            case 6: //modify a listing
                    Console.WriteLine();
                    Console.WriteLine("Thank you. Let's get your Listing modified");
                    modifyProperty(propertyListings);
                    break;


            case 7: //exit
                Console.WriteLine("Exiting Application");
                AppRunning = false;
                break;

        }
    } while (AppRunning);
}

// Methods for handling the menu actions
public void addCommercialProperty(Listings commercialList, string id)
{
    CommercialBuild commercialProperty = new CommercialBuild();

            //add an id
            if (id == "")
            {
                //if no id is passed (i.e we are not modifying a class) then generate a new one
                commercialProperty.ID = commercialProperty.generateID();
            }
            else
            {
                //we are passing an ID which means we are modifying it
                commercialProperty.ID = id.ToUpper();
            }

            // Ask for the address
            string correct = "n";

            while (correct == "n")
            {
                Console.WriteLine("What is the address of this property?");
                Console.WriteLine("Please specify the number, street and county with a comma between each");
                commercialProperty.Address = Console.ReadLine(); //add the address to the class
 
                //asking the user to confirm
                Console.WriteLine("The address you entered is:");
                Console.WriteLine(commercialProperty.Address);
                Console.WriteLine("Is this correct? Y/N");
                correct = Console.ReadLine().ToLower();
                if (correct == "n")
                {
                    Console.WriteLine("Please enter the correct address");
                }
                else if (correct == "y")
                {
                    Console.WriteLine("Great! Thanks.");
                }
                else
                {
                    Console.WriteLine("Woops - this needs to be y or n");
                    correct = "n";
                }
            }

            ////////////////////////////////

            // Ask for the Square Footage
            double squareFoot = 0;
            Console.WriteLine("How many Square Foot is this property?");
            do
            {
                //check if its a number
                if (!double.TryParse(Console.ReadLine().Replace(",", ""), out squareFoot))
                {
                    notNumberError();
                }

            } while (squareFoot == 0);

            commercialProperty.SquareFootage = squareFoot; //add the squareFoot to the class

            ////////////////////////////////

            // Ask for the rates
            double rates = 0;
            Console.WriteLine("What is the Rateable Valuation on this property?");
            do
            {
                //check if its a number
                if (!double.TryParse(Console.ReadLine().Replace(",", ""), out rates))
                {
                    notNumberError();
                }

            } while (rates == 0);

            commercialProperty.Rates = rates; //add the rates to the class

            ////////////////////////////////

            // Ask for the intended purpose
            Console.WriteLine("What is the intended purpose of this property?");
            Console.WriteLine("Please enter the number corressponding to one of these options:");
            Console.WriteLine("1 - Retail");
            Console.WriteLine("2 - Industrial");
            Console.WriteLine("3 - Office");

            int intendedPurpose = 0;
            do
            {
                //check if its a number
                if (!int.TryParse(Console.ReadLine(), out intendedPurpose))
                {
                    notOptionError();
                }

                else if (intendedPurpose < 1 || intendedPurpose > 3)
                {
                    notOptionError();
                    intendedPurpose = 0;
                }
            } while (intendedPurpose == 0);

            //check input against Enum and add the option selected to the class
            switch (intendedPurpose)
            {
                case 1:
                    commercialProperty.IntendedPurpose = EnumIntendedPurpose.Retail;
                    break;
                case 2:
                    commercialProperty.IntendedPurpose = EnumIntendedPurpose.Industrial;
                    break;
                case 3:
                    commercialProperty.IntendedPurpose = EnumIntendedPurpose.Office;
                    break;
                default:
                    break;
            }

            ////////////////////////////////

            // Confirm the commercial property has been created
            Console.WriteLine("Thank you! Your property has been succecssfully created as follows:");
            Console.WriteLine(commercialProperty.ToString());
            Console.WriteLine("Press S to save and return to the main menu or any other key to quit without saving");
            string saveOrQuit = Console.ReadLine().ToLower();

            if (saveOrQuit == "s")
            {
                commercialList.Add(commercialProperty); //add to the list
                Console.Clear();
            }
            else
            {
                AppRunning = false;
            }


}

public void addRentalProperty(Listings rentalList, string id)
{
    Rental rentalProperty = new Rental();

            //add an id
            if (id == "")
            {
                //if no id is passed (i.e we are not modifying a class) then generate a new one
                rentalProperty.ID = rentalProperty.generateID();
            } 
            else
            {
                //we are passing an ID which means we are modifying it
                rentalProperty.ID = id.ToUpper();
            }

            // Ask for the address
            string correct = "n";

            while (correct == "n")
            {
                Console.WriteLine("What is the address of this property?");
                Console.WriteLine("Please specify the number, street and county with a comma between each");
                rentalProperty.Address = Console.ReadLine(); //add the address to the class
                

                //asking the user to confirm
                Console.WriteLine("The address you entered is:");
                Console.WriteLine(rentalProperty.Address);
                Console.WriteLine("Is this correct? Y/N");
                correct = Console.ReadLine().ToLower();
                if (correct == "n")
                {
                    Console.WriteLine("Please enter the correct address");
                }
                else if (correct == "y")
                {
                    Console.WriteLine("Great! Thanks.");
                }
                else
                {
                    Console.WriteLine("Woops - this needs to be y or n");
                    correct = "n";
                }
            }

            ////////////////////////////////

            // Ask for the Square Footage
            double squareFoot = 0;
            Console.WriteLine("How many Square Foot is this property?");
            do
            {
                //check if its a number
                if (!double.TryParse(Console.ReadLine().Replace(",", ""), out squareFoot))
                {
                    notNumberError();
                }

            } while (squareFoot == 0);

            rentalProperty.SquareFootage = squareFoot; //add the squareFoot to the class

            ////////////////////////////////

            // Ask for the rent price
            double rent = 0;
            Console.WriteLine("What is the rent price per month for this property?");
            do
            {
                //check if its a number
                if (!double.TryParse(Console.ReadLine().Replace(",", ""), out rent))
                {
                    notNumberError();
                }

            } while (rent == 0);

            rentalProperty.Rent = rent; //add the rent price to the class


            // Ask for the owner name
            Console.WriteLine("Enter the owners Full Name");
            rentalProperty.OwnerName = Console.ReadLine();

            ////////////////////////////////

            // Ask for the email address ************ TODO: Would like to check its a valid email here
            Console.WriteLine("Enter the contact email for this property");
            rentalProperty.Email = Console.ReadLine(); // add the email to the class

            ////////////////////////////////

            // Confirm the rental property has been created
            Console.WriteLine("Thank you! Your property has been successfully created as follows:");
            Console.WriteLine(rentalProperty.ToString());
            Console.WriteLine("Press S to save and return to the main menu or any other key to quit without saving");
            string saveOrQuit = Console.ReadLine().ToLower();

            if (saveOrQuit == "s")
            {
                rentalList.Add(rentalProperty); //add to the list
                Console.Clear();
            }
            else
            {
                AppRunning = false;
            }


}

public void addSalesProperty(Listings salesList, string id)
{
            // Using overloaded constructor for this one so that we are able to add the sale agreed and sold default properties as test data on startup
            // setting up the params here
            string address = "";
            double squareFoot = 0;
            double askingPrice = 0;
            EnumSalesStatus status = EnumSalesStatus.For_Sale; //for sale by default if its a new property being added
            string ownerName;
            string email;


            // Ask for the address
            string correct = "n";

            while (correct == "n")
            {
                Console.WriteLine("What is the address of this property?");
                Console.WriteLine("Please specify the number, street and county with a comma between each");
                address = Console.ReadLine();

                //asking the user to confirm
                Console.WriteLine("The address you entered is:");
                Console.WriteLine(formatAddressOnNewLines(address));
                Console.WriteLine("Is this correct? Y/N");
                correct = Console.ReadLine().ToLower();
                if (correct == "n")
                {
                    Console.WriteLine("Please enter the correct address");
                }
                else if (correct == "y")
                {
                    Console.WriteLine("Great! Thanks.");
                }
                else
                {
                    Console.WriteLine("Woops - this needs to be y or n");
                    correct = "n";
                }
            }

            ////////////////////////////////

            // Ask for the Square Footage
            Console.WriteLine("How many Square Foot is this property?");
            do
            {
                //check if its a number
                if (!double.TryParse(Console.ReadLine().Replace(",", ""), out squareFoot))
                {
                    notNumberError();
                }

            } while (squareFoot == 0);

            ////////////////////////////////

            // Ask for the asking price
            Console.WriteLine("What is the asking price for this property?");
            do
            {
                //check if its a number
                if (!double.TryParse(Console.ReadLine().Replace(",", ""), out askingPrice))
                {
                    notNumberError();
                }

            } while (askingPrice == 0);


            // Ask for the owner name
            Console.WriteLine("Enter the owners Full Name");
            ownerName = Console.ReadLine();

            ////////////////////////////////

            // Ask for the email address ************ TODO: Would like to check its a valid email here
            Console.WriteLine("Enter the contact email for this property");
            email = Console.ReadLine(); // add the email to the class

            ////////////////////////////////
            
            // Ask for the sales status if we are editing i.e if there is no id passed
            if(id != "")
            {

                Console.WriteLine("What is the sales status of this property?");
                Console.WriteLine("Please enter the number corressponding to one of these options:");
                Console.WriteLine("1 - For Sale");
                Console.WriteLine("2 - Sale Agreed");
                Console.WriteLine("3 - Sold");

                int salesStatusSelected = 0;
                do
                {
                    //check if its a number
                    if (!int.TryParse(Console.ReadLine(), out salesStatusSelected))
                    {
                        notOptionError();
                    }

                    else if (salesStatusSelected < 1 || salesStatusSelected > 3)
                    {
                        notOptionError();
                        salesStatusSelected = 0;
                    }
                } while (salesStatusSelected == 0);

                //check input against Enum and add the option selected to the sales status variable
                switch (salesStatusSelected)
                {
                    case 1:
                        status = EnumSalesStatus.For_Sale;
                        break;
                    case 2:
                        status = EnumSalesStatus.Sale_Agreed;
                        break;
                    case 3:
                        status = EnumSalesStatus.Sold;
                        break;
                    default:
                        break;
                }
            }


            // Create the property using overloaded constructor
            Sale salesProperty = new Sale(status, address, squareFoot, ownerName, email, askingPrice, id);

            ///////////////////////////////

            // Confirm the property has been created
            Console.WriteLine("Thank you! Your property has been created succecssfully added as follows:");
            Console.WriteLine(salesProperty.ToString());
            Console.WriteLine("Press S to save and return to main menu or any other key to quit without saving");
            string saveOrQuit = Console.ReadLine().ToLower();

            if (saveOrQuit == "s")
            {
                salesList.Add(salesProperty); //add to the list
                Console.Clear();
            }
            else
            {
                AppRunning = false;
            }
}

public void modifyProperty(Listings allPropertiesList)
{
            //setup the listingType variable so we know what type of property method to call
            // just set a default as didn't know if Enum type can be empty
            EnumListingTypes listingType = EnumListingTypes.CommercialBuilds;

            int x = 0;
            while (x == 0)
            { 
                Console.WriteLine("Please enter the type of listing you wish to modify:");
                Console.WriteLine("1 - Commercial Property");
                Console.WriteLine("2 - Rental Property");
                Console.WriteLine("3 - Sales Property");

                int optionSelected = int.Parse(Console.ReadLine());

                if (optionSelected == 1)
                {
                    listingType = EnumListingTypes.CommercialBuilds;
                    x = 1;
                }
                else if (optionSelected == 2)
                {
                    listingType = EnumListingTypes.Rentals;
                    x = 1;
                }
                else if (optionSelected == 3)
                {
                    listingType = EnumListingTypes.Sales;
                    x = 1;
                }
                else
                {
                    notOptionError();
                }
            }

            string id = "";
            string correct = "n";
            while (correct == "n")
            {
                    //grab the id of the one we wish to modify so we can use it when readding the property 
                    Console.WriteLine("Please enter the ID of the property you wish to modify:");
                    id = Console.ReadLine();

                    if (allPropertiesList.GetListingsByID(id, listingType))
                    {
                        Console.WriteLine("Is this the property you wish to modify? Y/N");
                        correct = Console.ReadLine().ToLower();
                        if (correct == "n")
                        {
                            Console.WriteLine("Please enter the correct ID");
                        }
                        else if (correct == "y")
                        {
                            Console.WriteLine("Great! Thanks.");
                        }
                        else
                        {
                            Console.WriteLine("Woops - this needs to be y or n");

                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry - that listing doesn't exist in this property type. Please try again.");
                    }
            }

            //use that listing type so we know which add property method to call
            switch (listingType)
            {
                        case EnumListingTypes.CommercialBuilds:
                            //first remove the property with this id
                            allPropertiesList.Remove(id);

                            //ask the user to add a new one but pass the same id so its like we modified it
                            addCommercialProperty(allPropertiesList, id);
                            break;

                        case EnumListingTypes.Rentals:

                            //first remove the property with this id
                            allPropertiesList.Remove(id);

                            //ask the user to add a new one but pass the same id so its like we modified it
                            addRentalProperty(allPropertiesList, id);
                            break;


                        case EnumListingTypes.Sales:
                            //first remove the property with this id
                            allPropertiesList.Remove(id);

                            //ask the user to add a new one but pass the same id so its like we modified it
                            addSalesProperty(allPropertiesList, id);
                            break;

            }
}

// Method to setup test sales data 
private void createTestData(Listings list)
{
    Sale defaultSaleProperty1 = new Sale(EnumSalesStatus.Sold, "29, Synge Street, Dublin 08", 2500, "Ross Maguire", "10556781@mydbs.ie", 500000, "");
    Sale defaultSaleProperty2 = new Sale(EnumSalesStatus.Sale_Agreed, "20, Main Street, Dublin 05", 1800, "Jenn Collins", "jen@mydbs.ie", 320000, "");
    Sale defaultSaleProperty3 = new Sale(EnumSalesStatus.Sold, "14, Kildare Lane, Naas", 1400.80, "David Jones", "djonez@mydbs.ie", 25000, "");
    Sale defaultSaleProperty4 = new Sale(EnumSalesStatus.Sale_Agreed, "30, The Elms, Newbridge", 1300, "Sarah Howard", "showard@mydbs.ie", 120000, "");

    list.Add(defaultSaleProperty1);
    list.Add(defaultSaleProperty2);
    list.Add(defaultSaleProperty3);
    list.Add(defaultSaleProperty4);
}

// Utility Methods
public void notNumberError()
{
    Console.WriteLine("Woops! This needs to be number.");
    Console.WriteLine("Please avoid using any other characters");
}

public void notOptionError()
{
    Console.WriteLine("Woops! This needs to be on of the numbers above - please try again");
}

public string formatAddressOnNewLines(string addrToFormat)
{
    string cleanAddress = Regex.Replace(addrToFormat, " *, *", ",");
    string[] newAddress = cleanAddress.Split(",");
    return string.Join("\n", newAddress);
}
}
}

