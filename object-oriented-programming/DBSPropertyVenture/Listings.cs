using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DBSPropertyVenture 
{
    class Listings
    {
        List<Building> listofProperties = new List<Building>();

        //Method for showing the different property listings by type
        public bool GetListings(EnumListingTypes listingType)
        {
            bool found = false;

            switch (listingType)
            {
                case EnumListingTypes.CommercialBuilds:
                    //get all commercial builds
                    foreach (Building property in listofProperties)
                    {
                        if (property.GetType() == typeof(CommercialBuild))
                        {
                            Console.WriteLine(property.ToString());
                            Console.WriteLine("------------------");
                            found = true;
                        }
                    }
                    break;

                case EnumListingTypes.Rentals:
                    //get all rentals 
                    foreach (Building property in listofProperties)
                    {
                        if (property.GetType() == typeof(Rental))
                        {
                            Console.WriteLine(property.ToString());
                            Console.WriteLine("------------------");
                            found = true;
                        }
                    }
                    break;


                case EnumListingTypes.Sales:
                    //get all sales 
                    foreach (Building property in listofProperties)
                    {
                        if (property.GetType() == typeof(Sale))
                        {
                            Console.WriteLine(property.ToString());
                            Console.WriteLine("------------------");
                            found = true;
                        }
                    }
                    break;

            }

            return found;

        }

        //Method for showing the different property listings by id used when modifying
        public bool GetListingsByID(string id, EnumListingTypes listingType)
        {
            bool found = false;
            switch (listingType)
            {
                case EnumListingTypes.CommercialBuilds:
                    //check the id in commercial builds
                    foreach (Building property in listofProperties)
                    {
                        if (property.ID.ToLower() == id.ToLower() && property.GetType() == typeof(CommercialBuild))
                        {
                            Console.WriteLine(property.ToString());
                            Console.WriteLine("------------------");
                            found = true;
                        }
                    }
                    break;

                case EnumListingTypes.Rentals:
                    //check the id in rentals 
                    foreach (Building property in listofProperties)
                    {
                        if (property.ID.ToLower() == id.ToLower() && property.GetType() == typeof(Rental))
                        {
                            Console.WriteLine(property.ToString());
                            Console.WriteLine("------------------");
                            found = true;
                        }
                    }
                    break;


                case EnumListingTypes.Sales:
                    //check the id in sales 
                    foreach (Building property in listofProperties)
                    {
                        if (property.ID.ToLower() == id.ToLower() && property.GetType() == typeof(Sale))
                        {
                            Console.WriteLine(property.ToString());
                            Console.WriteLine("------------------");
                            found = true;
                        }
                    }
                    break;

            }

            return found;
        }

        public void Add(Building property)
        {
            listofProperties.Add(property);
        }

        public bool Remove(string id)
        {
            bool removed = false;

            foreach(var property in listofProperties)
            {
                if(property.ID.ToLower() == id.ToLower())
                {
                    listofProperties.Remove(property);
                    removed = true;
                    break;
                }
            }

            return removed;
        }
    }
}
