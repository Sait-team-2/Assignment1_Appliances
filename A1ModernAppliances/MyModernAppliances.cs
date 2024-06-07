using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: Marian Estrada, Jose Ricardo Bastidas</remarks>
    /// <remarks>Date: June 6, 2024</remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.WriteLine("Enter the item number of an appliance: ");

            // Create long variable to hold item number
            long applianceNumber;

            // Get user input as string and assign to variable.
            string strApplianceNumber = Console.ReadLine();

            // Convert user input from string to long and store as item number variable.
            applianceNumber = long.Parse(strApplianceNumber);

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            Appliance foundAppliance = null;

            // Loop through Appliances
            foreach (var appliance in Appliances)
            {
                // Test appliance item number equals entered item number
                if (appliance.ItemNumber == applianceNumber)
                {
                    // Assign appliance in list to foundAppliance variable
                    foundAppliance = appliance;

                    // Break out of loop (since we found what we need to)
                    break;
                }
            }

            // Test appliance was not found (foundAppliance is null)
            if (foundAppliance == null)
            {
                // Write "No appliances found with that item number."
                Console.WriteLine("No appliances found with that item number.\n");
            }
            else
            {
                // Otherwise (appliance was found)
                // Test found appliance is available
                if (foundAppliance.IsAvailable)
                {
                    // Checkout found appliance
                    foundAppliance.Checkout();

                    // Write "Appliance has been checked out."
                    Console.WriteLine($"Appliance \"{foundAppliance.ItemNumber}\" has been checked out.\n");
                }
                else
                {
                    // Otherwise (appliance isn't available)
                    // Write "The appliance is not available to be checked out."
                    Console.WriteLine("The appliance is not available to be checked out.\n");
                }
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine("Enter brand to search for: ");

            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.
            string enteredBrand = Console.ReadLine();

            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate through loaded appliances
            foreach (var appliance in Appliances)
            {
                // Test current appliance brand matches what user entered
                if (appliance.Brand == enteredBrand)
                {
                    // Add current appliance in list to found list
                    found.Add(appliance);
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Enter number of doors: "
            Console.WriteLine("Enter number of doors: 0 (Any), 2 (double door), 3 (three doors) or 4 (four doors): ");

            // Create variable to hold entered number of doors
            int numberOfDoors;

            // Get user input as string and assign to variable
            string strNumberOfDoors = Console.ReadLine();

            // Convert user input from string to int and store as number of doors variable.
            numberOfDoors = int.Parse(strNumberOfDoors);

            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate/loop through Appliances
            foreach (var appliance in Appliances)
            {
                // Test that current appliance is a refrigerator
                if (appliance is Refrigerator refrigerator)
                {
                    // Test user entered 0 or refrigerator doors equals what user entered.
                    if (numberOfDoors == 0 || refrigerator.Doors == numberOfDoors)
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);

        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Enter voltage:"
            Console.Write("Enter battery voltage value. 18 V (low) or 24 V (high): ");

            // Get user input as string
            string input = Console.ReadLine();
            // Create variable to hold voltage
            int voltage;

            // Test input
            switch (input)
            {
                case "0":
                    // Assign 0 to voltage
                    voltage = 0;
                    break;
                case "18":
                    // Assign 18 to voltage
                    voltage = 18;
                    break;
                case "24":
                    // Assign 24 to voltage
                    voltage = 24;
                    break;
                default:
                    // Write "Invalid option."
                    Console.WriteLine("Invalid option.");
                    // Return to calling (previous) method
                    return;
            }

            // Create found variable to hold list of found appliances.
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            foreach (var appliance in Appliances)
            {
                // Check if current appliance is vacuum
                if (appliance is Vacuum vacuum)
                {
                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                    if (voltage == 0 || vacuum.BatteryVoltage == voltage)
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);

        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"
            Console.WriteLine("Possible options:");
            Console.WriteLine("0-Any");
            Console.WriteLine("1-kitchen");
            Console.WriteLine("2-work site");

            // Write "Enter room type:"
            Console.WriteLine("Enter room type: ");
            // Get user input as string and assign to variable
            string roomType = Console.ReadLine();
            // Create character variable that holds room type
            char roomTypeChar = roomType switch
            {
                // Test input is "0"
                // Assign 'A' to room type variable
                "0" => 'A',
                // Test input is "1"
                // Assign 'K' to room type variable
                "1" => 'K',
                // Test input is "2"
                // Assign 'W' to room type variable
                "2" => 'W',
                _ => '\0'
            };
            // Otherwise (input is something else)
            // Write "Invalid option."
            if (roomTypeChar == '\0')
            {
                Console.WriteLine("Invalid option.");
                // Return to calling method
                return;
            }
            // Create variable that holds list of 'found' appliances
            List<Appliance> found = new List<Appliance>();
            // Loop through Appliances
            foreach (var appliance in Appliances)
            {
                // Test current appliance is Microwave
                if (appliance is Microwave microwave)
                {
                    // Test room type equals 'A' or microwave room type
                    if (roomTypeChar == 'A' || (roomTypeChar == 'K'))
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options: ");
            // Write "0 - Any"
            Console.WriteLine("0-Any");
            // Write "1 - Quietest"
            Console.WriteLine("1-Quietest");
            // Write "2 - Quieter"
            Console.WriteLine("2-Quieter");
            // Write "3 - Quiet"
            Console.WriteLine("3-Quiet");
            // Write "4 - Moderate"
            Console.WriteLine("4-Moderate");

            // Write "Enter sound rating:"
            Console.WriteLine("Enter sound rating");
            // Get user input as string and assign to variable
            string input = Console.ReadLine();
            // Create variable that holds sound rating
            string soundRating = input switch
            {
                // Test input is "0"
                "0" => "Any",
                // Assign "Any" to sound rating variable
                // Test input is "1"
                "1" => "Qt",
                // Assign "Qt" to sound rating variable
                // Test input is "2"
                "2" => "Qr",
                // Assign "Qr" to sound rating variable
                // Test input is "3"
                "3" => "Qu",
                // Assign "Qu" to sound rating variable
                // Test input is "4"
                "4" => "M",
                // Assign "M" to sound rating variable
                _ => ""
            };
            
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method
            if (string.IsNullOrEmpty(soundRating))
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            // Create variable that holds list of found appliances
            var found = Appliances.OfType<Dishwasher>().Where(d => soundRating == "Any" || d.Feature.Contains(soundRating)).ToList();
            // Loop through Appliances
            // Test if current appliance is dishwasher
            // Down cast current Appliance to Dishwasher

            // Test sound rating is "Any" or equals soundrating for current dishwasher
            // Add current appliance in list to found list

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Enter number of appliances: "
            Console.WriteLine("\nEnter number of appliances: ");

            // Get user input as string and assign to variable
            string strNum = Console.ReadLine();

            // Convert user input from string to int
            int num = int.Parse(strNum);

            // Create variable to hold list of found appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through appliances
            foreach (var appliance in Appliances)
            {
                // Add current appliance in list to found list
                found.Add(appliance);
            }

            // Randomize list of found appliances
            found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, num);

        }
    }
}
