using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using System.Web.Razor.Text;

namespace WebAppDevelopmentAssignment2.Controllers
{
    public class J1Controller : ApiController
    {
        [Route("api/J1/menu/{burger}/{drink}/{side}/{dessert}")]
        [HttpGet]
        public string Menu(int burger, int drink, int side, int dessert)
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
            int burgerCal = burgerChoice[burger];  //<----

            //user selects which drink they want
            int drinkCal = drinkChoice[drink];

            //User selects which side they want
            int sideCal = sideChoice[side];

            //User selects which dessert they want
            int dessertCal = dessertChoice[dessert];


            //How do we find the total calories? Add up calories of each selection 
            int totalCal = burgerCal + drinkCal + sideCal + dessertCal;


            //Return a message stating the total calorie count
            return "Your total calorie count is " + totalCal;
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

        // 2017 J3 Problem https://cemc.math.uwaterloo.ca/contests/computing/2017/stage%201/juniorEF.pdf
        [Route("api/J3/ExactlyElectrical/{x1}/{y1}/{x2}/{y2}/{e}")]
        [HttpGet]
        public string ExactlyElectrical(int x1, int y1, int x2, int y2, int e)
        {
            int street1 = x1;
            int avenue1 = y1;
            int street2 = x2;
            int avenue2 = y2;
            int charge = e;

            int streetTravel = street1 - street2;
            int avenueTravel = (avenue1 - avenue2);
            int eCharge = (charge - streetTravel - avenueTravel);

            string yes = "Y";
            string no = "N";
            

            if (eCharge > 0) {
                return yes;
            } else
            {
                return no;
            } /* this should answer part 1 of the question. However theres another dimension to this problem
                    I understand now that I have to calculate how many different moves the veh can make.
                    EX: give these 4 numbers, how many different combinations can you make ???
                    (10, 4) and (11, 4) you can combo with (10,4), (10,5) (10,4) (11, 4) (11, 4) (11, 3) (11, 5) etc
                    something like that. This was a fun attempt*/
        }
    }
    
}

