using System;

namespace DBSPropertyVenture
{
    class Program
    {

        static void Main(string[] args)
        {

            //Start the app
            try
            {
                var application = new Application(true);
                application.RunApp();
            }
            catch (Exception e)
            {
                Console.WriteLine("App could not be started. Please close and try to restart.");
                Console.WriteLine(e.Message);
            }

        }
    }
}

