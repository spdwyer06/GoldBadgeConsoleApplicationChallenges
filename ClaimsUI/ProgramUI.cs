using ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClaimsRepository.Claim;

namespace ClaimsUI
{
    class ProgramUI
    {
        ClaimsRepo claims = new ClaimsRepo();

        public void Run()
        {
            SeedQueue();
            MainMenu();
        }
        public void MainMenu()
        {
            Console.Clear();

            Console.WriteLine($"Choose a menu item: \n" +
                $"[1] See all claims\n" +
                $"[2] Take care of next claim\n" +
                $"[3] Enter a new claim");
            string agentInput = Console.ReadLine();
            switch(agentInput)
            {
                case "1":
                    SeeAllClaims();
                    break;
                case "2":
                    NextClaim();
                    break;
                case "3":
                    NewClaim();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($"Please enter a valid action.\n" +
                        $"Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu();

                    break;
            }
        }
        public void SeeAllClaims()
        {
            Console.Clear();
            List<Claim> claimsList = new List<Claim>();
            claimsList = claims.GetAllClaims();
            foreach (Claim claim in claimsList)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Ammount: ${claim.ClaimAmount}\n" +
                    $"Date Of Incident: {claim.DateOfIncindent}\n" +
                    $"Date Of Claim: {claim.DateOfClaim}\n" +
                    $"Is Valid: {claim.IsValid}\n" +
                    $"");
            }
            
            //claims.DisplayAllClaims();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            MainMenu();
            
        }
        public void NextClaim()
        {
            Console.Clear();

            claims.ViewNextClaim();
            Console.Write("Do you want to handle this claim now (y/n)?:");
            string agentInput = Console.ReadLine();
            if(agentInput=="y" || agentInput=="Y")
            {
                claims.Dequeue();
                MainMenu();
            }
            else if (agentInput=="n" || agentInput == "N")
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Did not recognize answer, enter 'y' or 'n' when prompted.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
                NextClaim();
            }
        }
        public void NewClaim()
        {
            Console.Clear();

            Claim newClaim = new Claim(); 

            Console.Write("Enter the Claim ID: ");
            // breaks if you don't input a number
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            Console.Write("Choose a Claim Type: \n" +
                "[1] Car\n" +
                "[2] Home\n" +
                "[3] Theft");
            string claimType = Console.ReadLine();
            switch (claimType)
            {
                case "1":
                    newClaim.ClaimType = TypeOfClaim.Car;
                    break;
                case "2":
                    newClaim.ClaimType = TypeOfClaim.Home;
                    break;
                case "3":
                    newClaim.ClaimType = TypeOfClaim.Theft;
                    break;
                default:
                    Console.WriteLine("Not a valid Claim Type\n" +
                        "Press any key to redirect...");
                    Console.ReadKey();

                    break;
            }
            Console.Write("Enter a Claim Description: ");
            newClaim.Description = Console.ReadLine();
            Console.Write("Enter the amount of damage: ");
            newClaim.ClaimAmount = int.Parse(Console.ReadLine());
            Console.Write("Enter the date of the accident: ");
            newClaim.DateOfIncindent = DateTime.Parse(Console.ReadLine());
            Console.Write($"Date of claim: {DateTime.Now.ToString("MM/dd/yyy")}\n");
            newClaim.DateOfClaim = DateTime.Now;
            claims.Enqueue(newClaim);
            Console.ReadLine();
            MainMenu();
        }
        public void SeedQueue()
        {
            Claim maria = new Claim();
            maria.ClaimID = 1;
            maria.ClaimType = TypeOfClaim.Home;
            maria.Description = "Husband said ''I got this''";
            maria.ClaimAmount = 4570.00m;
            maria.DateOfIncindent = new DateTime(2020, 01, 03);
            maria.DateOfClaim = new DateTime(2020, 01, 09);
            claims.Enqueue(maria);

            Claim sean = new Claim();
            sean.ClaimID = 2;
            sean.ClaimType = TypeOfClaim.Theft;
            sean.Description = "Stolen slice of pizza";
            sean.ClaimAmount = 2.25m;
            sean.DateOfIncindent = new DateTime(2008, 03, 13);
            sean.DateOfClaim = new DateTime(2020, 02, 15);
            claims.Enqueue(sean);

            Claim james = new Claim();//1, TypeOfClaim.Car, "Fender bender on 465", 465.00, DateTime(2020,02,01), 2020/02/01);
            james.ClaimID = 3;
            james.ClaimType = TypeOfClaim.Car;
            james.Description = "Fender bender on 465";
            james.ClaimAmount = 465.00m;
            james.DateOfIncindent = new DateTime(2020, 02, 01);
            james.DateOfClaim = new DateTime(2020, 02, 10);
            claims.Enqueue(james);

        }
    }
}
