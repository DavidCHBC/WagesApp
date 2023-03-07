//imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagesApp
{
    internal class Program
    {
        //global variables

        static string topEarner = "";
        static int topHours = -69;


        //Methods/functions


        static string CheckFlag()
        {

            while (true)
            {

                Console.WriteLine("Press enter to add another employee, or type 'XXX' to quit.");

                string userInput = Console.ReadLine();

                //convert user input to uppercase

                userInput = userInput.ToUpper();

                if (userInput.Equals("XXX") || userInput.Equals("") )
                {

                    return userInput;

                }

                Console.WriteLine("Error: Invalid Input.");

            }
        }

        static string CheckName()
        {


            while (true)
            {

                Console.WriteLine("Enter the employee's name:");

                string name = Console.ReadLine();



                if (!name.Equals(""))
                {

                    name = name[0].ToString().ToUpper() + name.Substring(1);

                    return name;

                }

                Console.WriteLine("Error: you must enter a name for the employee.");

            }



        }




        static void OneEmployee()
        {

            List<string> weekDays = new List<string>() {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday"};

            //Enter and store employee name

            
            string EmployeeName = CheckName();

            //Display employee name

            Console.WriteLine(EmployeeName);

            //----Loop 5 times----

            Random ranGen = new Random();

            int sumHoursWorked = 0;

            for (int dayIndex = 0; dayIndex < 5; dayIndex++)
            {

                //Randomly generate hours worked each day

                int hoursWorked = ranGen.Next(2, 7);

                //Assign the day to a variable

                string day = weekDays[dayIndex];

                //store total number of hours worked

                sumHoursWorked += hoursWorked;

                //Display the name of the day and the number of hours generated for each worker

                Console.WriteLine($"Hours worked on {day}: {hoursWorked}");

            }

            //----End of loop----

            

            //call calculate wages

            CalculateWages(sumHoursWorked, EmployeeName);

        }

        static void CalculateWages(int totalHoursWorked,string EmployeeName)
        {

            //display the total weekly hours stored

            Console.WriteLine($"Total hours worked: {totalHoursWorked}H");

            //+5h if total >30

            if (totalHoursWorked >= 30)
            {

                totalHoursWorked += 5;

                Console.WriteLine($"5 bonus hours added, total hours worked: {totalHoursWorked}H");


            }


            if (totalHoursWorked > topHours)
            {

                topHours = totalHoursWorked;
                topEarner = EmployeeName;
            }


            //calculate wage at a rate of $22/hr

            int wages = totalHoursWorked * 22;

            float tax = 0.07f;

            //TAXES

            if (wages > 450)
            {

                tax = 0.08f;

            }

            //calculate final pay

            float finalPay = wages - (float)Math.Round(wages * tax, 2);

            //display results

            Console.WriteLine($"Weekly pay: {wages}\nTax rate: {tax}\nTax: {Math.Round(wages * tax, 2)}\nFinal pay: {finalPay}\n\n");
        }

        //when run/main process

        static void Main(string[] args)
        {

            string flagMain = "";
            while (!flagMain.Equals("XXX"))
            {
                
                //loop OneEmployee() until user types stop command "XXX"
                OneEmployee();

                flagMain = CheckFlag();

            }

            //Determine the person who has the highest hours (incl bonus hours).
            Console.WriteLine($"{topEarner} is the top earner with {topHours}H worked.");

        }

    }
}
