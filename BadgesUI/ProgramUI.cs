using BadgesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesUI
{
    class ProgramUI
    {
        BadgesRepo accessLog = new BadgesRepo();
        List<string> possibleDoors = new List<string>() { "A1", "A2", "A3", "A4", "A5", "A6" };

        public void Run()
        {
            SeedBadges();
            MainMenu();
        }
        public void MainMenu()
        {
            Console.Clear();

            Console.WriteLine("What would you like to do (1-4): \n" +
                "[1] Create a new badge\n" +
                "[2] Update access on a current badge\n" +
                "[3] Delete all access on a current badge\n" +
                "[4] Show all current badges\n" +
                "");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddBadge();
                    break;
                case "2":
                    UpdateBadgeAccess();
                    break;
                case "3":
                    DeleteAllBadgeAccessMenu();
                    break;
                case "4":
                    DisplayAllBadges();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Did not recognize value, input 1-4 when prompted.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }
        public void AddBadge()
        {
            Console.Clear();

            Badge newBadge = new Badge();
            List<string> access = new List<string>();

            Console.Write("Enter a badge number: ");
            string possibleID = Console.ReadLine();
            // Checking to make sure that user input is a valid ID option (an integer)   // Declaring an initializing 'int newBadgeID' if 'possibleID' is valid
            if (Int32.TryParse(possibleID, out int newBadgeID))
            {
                newBadge.BadgeID = Convert.ToInt32(possibleID);
                // Checks to make sure Badge ID isn't already being used
                if (accessLog.DoesListContainBadgeID(newBadge)==true)
                {
                    Console.WriteLine("\n" +
                        "Badge ID already being used, choose another Badge ID.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    AddBadge();
                }
                else
                {
                    newBadge.BadgeID = newBadgeID;
                }
            }
            else
            {
                Console.WriteLine("\n" +
                    "Enter a proper Badge ID.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                AddBadge();
            }
            Console.Write($"What door does it have access to: ");
            string doorAccess = Console.ReadLine().ToUpper();
            //
            // user is able to input in multiple of the same door access
            //
            if (possibleDoors.Contains(doorAccess))
            {
                access.Add(doorAccess);
            }
            else
            {
                Console.WriteLine("Assignment of unrecognized door access, could not complete request.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                MainMenu();
            }
            Console.Write("Any other doors (y/n)?: ");
            string userInput = Console.ReadLine();
            if (userInput == "y" || userInput == "Y")
            {
                while (userInput == "y" || userInput == "Y")
                {
                    Console.Write("Enter door access: ");
                    doorAccess = Console.ReadLine().ToUpper();
                    if (possibleDoors.Contains(doorAccess))
                    {
                        access.Add(doorAccess);
                    }
                    else
                    {
                        Console.WriteLine("Assignment of unrecognized door access, could not complete request.");
                    }
                    Console.Write("Any other doors (y/n)?: ");
                    userInput = Console.ReadLine();
                }
                newBadge.Access = access;
                accessLog.AddBadgeToCollection(newBadge);
                Console.WriteLine("\n" +
                    "New badge created.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                MainMenu();
            }
            else if (userInput == "n" || userInput == "N")
            {
                newBadge.Access = access;
                accessLog.AddBadgeToCollection(newBadge);
                Console.WriteLine("\n" +
                    "New badge created.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                MainMenu();
            }
            else
            {
                Console.WriteLine("Did not recognze value, input 'y' or 'n' when prompted, unable to complete request.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                AddBadge();
            }
        }
        public void UpdateBadgeAccess()
        {
            Console.Clear();

            Badge badge = new Badge();
            Console.Write("Enter the Badge ID: ");
            // Verifying user input
            string possibleID = Console.ReadLine();
            if (Int32.TryParse(possibleID, out int userInput))
            {
                badge.BadgeID = Convert.ToInt32(possibleID);
            }
            else
            {
                Console.WriteLine("\n" +
                    "Invalid Badge ID, please try again.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                UpdateBadgeAccess();
            }
            // Verifying the badge exists
            if (accessLog.DoesListContainBadgeID(badge) == true)
            {
                Console.Clear();
                // Displays chosen badge ID
                Console.WriteLine($"Badge ID: {accessLog.DisplayBadgeID(userInput)}");
                // Displays chosen badge door access separated by ','
                Console.WriteLine($"Current door access: {accessLog.DisplayBadgeAccess(userInput)}");
                Console.WriteLine("");
                Console.WriteLine("What would you like to do: \n" +
                    "[1] Add a door access\n" +
                    "[2] Remove a door access\n" +
                    "[3] Cancel\n" +
                    "");
                string updateOption = Console.ReadLine();
                Console.Clear();
                switch (updateOption)
                {
                    // AddBadgeAccess()
                    case "1":
                        Console.WriteLine($"Current door access: {accessLog.DisplayBadgeAccess(userInput)}");
                        Console.Write("\n" +
                            "What door access would you like to add?: ");
                        // Setting all proper inputs to correct format
                        string addAccess = Console.ReadLine().ToUpper();
                        if (possibleDoors.Contains(addAccess))
                        {
                            if (accessLog.CheckAssignedBadgeAccess(userInput, addAccess) == true)
                            {
                                Console.WriteLine("\n" +
                                    "Current badge has already been given access to chosen door. \n" +
                                    "Press any key to continue...");
                                Console.ReadKey();
                                MainMenu();
                            }
                            else
                            {
                                Console.Write($"\n" +
                                    $"You want to add\n" +
                                    $"\n" +
                                    $"Door access: {addAccess} \n" +
                                    $"To Badge ID: {accessLog.DisplayBadgeID(userInput)}\n" +
                                    $"\n" +
                                    $"Correct (y/n)?: ");
                                string confirmUpdate = Console.ReadLine();
                                if (confirmUpdate == "y" || confirmUpdate == "Y")
                                {
                                    accessLog.AddBadgeAccess(userInput, addAccess);
                                    Console.WriteLine("\n" +
                                        "Door access added.");
                                }
                                else
                                {
                                    Console.WriteLine("\n" +
                                        "Update cancelled.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n" +
                                "Assignment of unrecognized door, could not complete request.\n" +
                                "Press any key to continue...");
                            Console.ReadKey();
                            MainMenu();
                        }
                        break;
                    // RemoveBadgeAccess()
                    case "2":
                        Console.WriteLine($"Current door access: {accessLog.DisplayBadgeAccess(userInput)}");
                        Console.Write("\n" +
                            "What door access would you like to remove?: ");
                        string removeAccess = Console.ReadLine().ToUpper();
                        // Verifying proper input
                        if (possibleDoors.Contains(removeAccess))
                        {
                            // Verifying badge being updated has been assigned access to door for removal
                            if (accessLog.CheckAssignedBadgeAccess(userInput, removeAccess) == true)
                            {
                                Console.Write($"\n" +
                                    $"You want to remove\n" +
                                    $"\n" +
                                    $"Door access: {removeAccess} \n" +
                                    $"From Badge ID: {accessLog.DisplayBadgeID(userInput)}\n" +
                                    $"\n" +
                                    $"Correct (y/n)?");
                                string confirmRemoval = Console.ReadLine();
                                if (confirmRemoval == "y" || confirmRemoval == "Y")
                                {
                                    accessLog.RemoveBadgeAccess(userInput, removeAccess);
                                    Console.WriteLine("\n" +
                                        "Door access removed");
                                }
                                else
                                {
                                    Console.WriteLine("\n" +
                                        "Removal cancelled.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"\n" +
                                    $"Selected badge currently does not have access to door {removeAccess}.\n" +
                                    $"Press any key to continue...");
                                Console.ReadKey();
                                MainMenu();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n" +
                                "Please enter proper door access.\n" +
                                "Press any key to continue...");
                            Console.ReadKey();
                            MainMenu();
                        }
                        break;
                    default:
                        MainMenu();
                        break;
                }
                // ReturnToMainMenu()
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                MainMenu();
                //
            }
            else
            {
                Console.WriteLine("\n" +
                    "Selected Badge ID does not exist.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                MainMenu();
            }

        }
        /*
        public void AddBadgeAccess()
        {
            Console.WriteLine($"Current door access: {String.Join(",", accessLog[userInput].Access)}");
            Console.Write("\n" +
                "What door access would you like to add?: ");
            // Setting all proper inputs to correct format
            string addAccess = Console.ReadLine().ToUpper();
            if (possibleDoors.Contains(addAccess))
            {
                if (accessLog[userInput].Access.Contains(addAccess))
                {
                    Console.WriteLine("\n" +
                        "Current badge has already been given access to chosen door. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    MainMenu();
                }
                else
                {
                    Console.Write($"\n" +
                        $"You want to add\n" +
                        $"\n" +
                        $"Door access: {addAccess} \n" +
                        $"To Badge ID: {accessLog[userInput].BadgeID}\n" +
                        $"\n" +
                        $"Correct (y/n)?: ");
                    string confirmUpdate = Console.ReadLine();
                    if (confirmUpdate == "y" || confirmUpdate == "Y")
                    {
                        accessLog[userInput].Access.Add(addAccess);
                        Console.WriteLine("\n" +
                            "Door access added.");
                    }
                    else
                    {
                        Console.WriteLine("\n" +
                            "Update cancelled.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\n" +
                    "Assignment of unrecognized door, could not complete request.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                MainMenu();
            }
        }
        */
        
        public void DeleteAllBadgeAccessMenu()
        {
            Console.Clear();

            Badge badge = new Badge();
            Console.Write("Enter the Badge ID: ");
            string possibleID = Console.ReadLine();
            if(Int32.TryParse(possibleID, out int userInput))
            {
                badge.BadgeID = userInput;
            }
            else
            {
                Console.WriteLine("\n" +
                   "Invalid Badge ID, please try again.\n" +
                   "Press any key to continue...");
                Console.ReadKey();
                DeleteAllBadgeAccessMenu();
            }
            if (accessLog.DoesListContainBadgeID(badge))
            {
                Console.Clear();
                Console.WriteLine($"Badge ID: {accessLog.DisplayBadgeID(userInput)}\n" +
                    $"Door access: {accessLog.DisplayBadgeAccess(userInput)}");
                Console.Write("\n" +
                    "Delete all door access (y/n)?: ");
                string confirmDelete = Console.ReadLine();
                if (confirmDelete == "y" || confirmDelete == "Y")
                {
                    accessLog.DeleteAllBadgeAccess(userInput);
                    Console.WriteLine("\n" +
                        "All door access removed.");
                }
                else
                {
                    Console.WriteLine("\n" +
                        "Door access removal cancelled.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                MainMenu();
            }
            else
            {
                Console.WriteLine("\n" +
                    "Selected Badge ID does not exist.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                MainMenu();
            }
        }
        public void DisplayAllBadges()
        {
            
            Console.Clear();

            Dictionary<int, Badge> badges = new Dictionary<int, Badge>();
            badges = accessLog.GetAllBadges();
            foreach (KeyValuePair<int, Badge> badge in badges)
            {
                Console.WriteLine($"Badge ID: {badge.Value.BadgeID}\n" +
                  $"Door access: {String.Join(",", badge.Value.Access)}\n" +
                  $"");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            MainMenu();
        }
        // repo??
        public void SeedBadges()
        //
        {
            Badge badgeOne = new Badge();
            badgeOne.BadgeID = 1;
            // Creates a list with already added items
            List<string> badgeOneAccess = new List<string>() { "A1", "A2", "A3", "A4" };
            badgeOne.Access = badgeOneAccess;
            accessLog.AddBadgeToCollection(badgeOne);

            Badge badgeTwo = new Badge();
            badgeTwo.BadgeID = 2;
            List<string> badgeTwoAccess = new List<string>() { "A1", "A2" };
            badgeTwo.Access = badgeTwoAccess;
            accessLog.AddBadgeToCollection(badgeTwo);

            Badge badgeThree = new Badge();
            badgeThree.BadgeID = 3;
            List<string> badgeThreeAccess = new List<string>() { "A1", "A2", "A3", "A5" };
            badgeThree.Access = badgeThreeAccess;
            accessLog.AddBadgeToCollection(badgeThree);
        }
    }

}
