using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAppDevelopmentAssignment2.Controllers
{
    public class J1Controller : ApiController
    {
        [Route("api/J1/menu/{burger}/{drink}/{side}/{dessert}")]
        [HttpGet]
        public IEnumerable<string> Menu(int burger, int drink, int side, int dessert)
        {
            //Burger Menu Variables
            int cheeseBurgerCal = 461;
            int chickenBurgerCal = 431;
            int veggieBurgerCal = 420;
            int noBurgerCal = 0;
            int[] burgerChoice = { 0, cheeseBurgerCal, chickenBurgerCal, veggieBurgerCal, noBurgerCal }; 
            //User inputted id will select from array of choices^^

            //Drink Menu Variables
            int softDrinkCal = 130;
            int orangeJuiceCal = 160;
            int milkCal = 118;
            int noDrink = 0;
            int[] drinkChoice = { 0, softDrinkCal, orangeJuiceCal, milkCal, noDrink };
            //User inputted id will select from array of choices^^

            // Sides Menu Variables
            int friesCal = 100;
            int bakedPotCal = 57;
            int chefSaladCal = 70;
            int noSide = 0;
            int[] sideChoice = { 0, friesCal, bakedPotCal, chefSaladCal, noSide };
            //User inputted id will select from array of choices^^

            //Dessert Menu Variables
            int applePieCal = 167;
            int sundaeCal = 266;
            int fruitCupCal = 75;
            int noDessert = 0;
            int[] dessertChoice = { 0, applePieCal, sundaeCal, fruitCupCal, noDessert };
            //User inputted id will select from array of choices^^

            //PROGRAMMING LOGIC
            //user selects which burger they want
            int burgerCal = burgerChoice[burger];

            //user selects which drink they want
            int drinkCal = drinkChoice[drink];

            //User selects which side they want
            int sideCal = sideChoice[side];

            //User selects which dessert they want
            int dessertCal = dessertChoice[dessert];


            //How do we find the total calories? Add up calories of each selection 
            int totalCal = burgerCal + drinkCal + sideCal + dessertCal;

           
            //Return a message stating the total calorie count
            return new string[] { "Your total calorie count is " + totalCal };
        }

        [Route("api/J2/DiceGame/{m}/{n}")]
        [HttpGet]
        public string DiceGame(int m, int n)
        {
            //Variables declared
            int totalSum = 0; //<-- We need to find this 
            int diceM = 1; // Theres no "0" on dice
            int diceN = 1;

            // Essentially, we will find the totalSum after looping through both dice

            // User sets range (int m) for diceM sides. User sets range (int n) for diceN sides
            for (diceM = 1; diceM <= m; diceM++) //Enter the diceM loop which will start with side 1 and go til (user set range with int m). 
            {
                for (diceN = 1; diceN <= n; diceN++) //diceM side runs through diceN loop and adds each diceN side (from 1-n)
                {                               

                    if (diceM + diceN == 10) // If diceM side adds with diceN set and ='s 10 - we mark it down. Then re enter diceM loop.
                    {
                        totalSum = totalSum + 1; //This counts how many sums of 10 we get for every set of numbers.
                    }
                }
            }

            //Message depending on totalSum result
            if (totalSum == 1)
            {
                return "There is " + totalSum + " way to get sum 10";
            }
            else if (totalSum == 5)
            {
                return "There are " + totalSum + " total ways to get sum 10";
            }
            else
            {
                return "There are " + totalSum + " ways to get sum 10";
            }

        }
    }
}

