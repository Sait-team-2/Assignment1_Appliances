using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;
using System.Security.Cryptography.X509Certificates;
using static ModernAppliances.Entities.Abstract.Appliance;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "

            // Create long variable to hold item number

            // Get user input as string and assign to variable.
            // Convert user input from string to long and store as item number variable.
            if (!long.TryParse(Console.ReadLine(), out long itemNumber))
            {
                Console.WriteLine("Invalid item number.");
                return;
            }

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)

            // Loop through Appliances
                // Test appliance item number equals entered item number
                    // Assign appliance in list to foundAppliance variable

                    // Break out of loop (since we found what need to)

            // Test appliance was not found (foundAppliance is null)
                // Write "No appliances found with that item number."

            // Otherwise (appliance was found)
                // Test found appliance is available
                    // Checkout found appliance

                    // Write "Appliance has been checked out."
                // Otherwise (appliance isn't available)
                    // Write "The appliance is not available to be checked out."
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        /// 
        public override void Find()
        {
            // Write "Enter brand to search for:"
Console.WriteLine("Enter brand to search for: ");
            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.

            // Create list to hold found Appliance objects
string enteredBrand = Console.ReadLine() ?? string.Empty;
            // Iterate through loaded appliances
                // Test current appliance brand matches what user entered
                    // Add current appliance in list to found list
var found = new List<Appliance>();
            foreach (var appliance in Appliances)
            {
                if (appliance.Brand.Equals(enteredBrand,StringComparison.OrdinalIgnoreCase))
                {
                    found.Add(appliance);
                }
            }

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"

            // Write "Enter number of doors: "

            // Create variable to hold entered number of doors

            // Get user input as string and assign to variable

            // Convert user input from string to int and store as number of doors variable.

            // Create list to hold found Appliance objects

            // Iterate/loop through Appliances
                // Test that current appliance is a refrigerator
                    // Down cast Appliance to Refrigerator
                    // Refrigerator refrigerator = (Refrigerator) appliance;

                    // Test user entered 0 or refrigerator doors equals what user entered.
                        // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"

            // Write "Enter grade:"

            // Get user input as string and assign to variable

            // Create grade variable to hold grade to find (Any, Residential, or Commercial)

            // Test input is "0"
                // Assign "Any" to grade
            // Test input is "1"
                // Assign "Residential" to grade
            // Test input is "2"
                // Assign "Commercial" to grade
            // Otherwise (input is something else)
                // Write "Invalid option."

                // Return to calling (previous) method
                // return;

            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"

            // Write "Enter voltage:"

            // Get user input as string
            // Create variable to hold voltage

            // Test input is "0"
                // Assign 0 to voltage
            // Test input is "1"
                // Assign 18 to voltage
            // Test input is "2"
                // Assign 24 to voltage
            // Otherwise
                // Write "Invalid option."
                // Return to calling (previous) method
                // return;

            // Create found variable to hold list of found appliances.

            // Loop through Appliances
                // Check if current appliance is vacuum
                    // Down cast current Appliance to Vacuum object
                    // Vacuum vacuum = (Vacuum)appliance;

                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                        // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
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
            Console.WriteLine("Eneter room type: ");
            // Get user input as string and assign to variable
            string roomType = Console.ReadLine() ?? string.Empty;
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
                _=> '\0'
            };
            // Otherwise (input is something else)
            // Write "Invalid option."
            if (roomTypeChar == '\0')
            {
                Console.WriteLine("invalid option (◣_◢)");
                // Return to calling method
                // return;
                return;
            }
            // Create variable that holds list of 'found' appliances

            var found = Appliances.OfType<Microwave>().Where(m => roomTypeChar == 'A' || m.RoomType == roomTypeChar).ToList();

            // Loop through Appliances
            // Test current appliance is Microwave
            List<Appliance> appliances = found.Cast<Appliance>().ToList();
            // Down cast Appliance to Microwave

            DisplayAppliancesFromList(appliances, 0);

            // Test room type equals 'A' or microwave room type
            // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
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
            string ratingInput = Console.ReadLine() ?? string.Empty;
            // Create variable that holds sound rating
            string soundRating = ratingInput switch
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
            
            if (string.IsNullOrEmpty(soundRating))
            {
                Console.WriteLine("Invalid option.");
                // Return to calling method
                return;
            }

            // Create variable that holds list of found appliances

            var found = Appliances.OfType<Dishwasher>().Where(d => soundRating == "Any").ToList();


            // Loop through Appliances
            // Test if current appliance is dishwasher
            // Down cast current Appliance to Dishwasher

            // Test sound rating is "Any" or equals soundrating for current dishwasher
            // Add current appliance in list to found list

            //Display found appliances (up to max. number inputted)
            

        }
        public void DispayAppliancesFromList(IEnumerable<Appliance> appliances, int max)
        {
            var list = appliances.ToList();
            if (list.Count > 0)
                {
                Console.WriteLine("Appliances found:");
                for (int i = 0; i < list.Count && (max == 0 || i < max); i++)
                {
                    Console.WriteLine(list[i]);
                }
            }
            else
                {
                Console.WriteLine("No appliances found.");
                }
            Console.WriteLine();
            }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Appliance Types"

            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"

            Console.WriteLine("Appliance Types");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");

            // Write "Enter type of appliance:"
            Console.Write("Enter type of appliance: ");
            int applianceType;
            if (!int.TryParse(Console.ReadLine(), out applianceType) || applianceType < 0 || applianceType > 4)
            {
                Console.WriteLine("Invalid type.");
                return;
            }
            // Get user input as string and assign to appliance type variable

            // Write "Enter number of appliances: "

            // Get user input as string and assign to variable

            // Convert user input from string to int

            // Create variable to hold list of found appliances
            Console.Write("Enter number of appliances: ");
            int num;
            if (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid number.");
                return;
            }


            // Display found appliances
            List<Appliance> found = Appliances.Where(appliance => applianceType == 0 ||
            // Loop through appliances
       // Test inputted appliance type is "0"
       // Add current appliance in list to found list
       // Test inputted appliance type is "1"
       // Test current appliance type is Refrigerator
       // Add current appliance in list to found list
       // Test inputted appliance type is "2"
       // Test current appliance type is Vacuum
       // Add current appliance in list to found list
       // Test inputted appliance type is "3"
       // Test current appliance type is Microwave
       // Add current appliance in list to found list
       // Test inputted appliance type is "4"
       // Test current appliance type is Dishwasher
       // Add current appliance in list to found list

       (applianceType == 1 && appliance is Refrigerator) ||
           (applianceType == 2 && appliance is Vacuum) ||
           (applianceType == 3 && appliance is Microwave) ||
           (applianceType == 4 && appliance is Dishwasher)).ToList();
            // Randomize list of found appliances
            // found.Sort(new RandomComparer());
            Random rnd = new Random();
            found = found.OrderBy(x => rnd.Next()).ToList();
            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
            DisplayAppliancesFromList(found, num);
        }
    }
}
