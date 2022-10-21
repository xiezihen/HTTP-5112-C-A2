using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace XieAssignment2.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// this will find the number of possible ways 2 dice can add up to 10
        /// the way ive seen others do this is by using 2 nested for loops and counting all the times the sum add up to 10
        /// i wanted to do this without nested loops the time complexity is better with O(9) instead of O(m*n)
        /// we dont need to check everything, the maximum number of ways is 9 (1,9) (2,8) (3,7) (4,6) (5,5) (6,4) (7,3) (8,2) (9,1)
        /// all the possibilities contain some subset of these pairs of sums
        /// if you remove the comment for writeline you can see the pairs during each loop iteration
        /// </summary>
        /// <param name="m"> m is die 1</param>
        /// <param name="n">n is die 2</param>
        /// <returns>
        /// reutrns the number of possible ways dice 1 and dice 2 can add up to 10</returns>
        [HttpGet]
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string DiceGame(int m, int n)
        {
            //declaration of variables and constants
            //constant sum will be the target sum number we want
            const int sum = 10;
            //constant highest is just sum-1 because we cant have 10,0 9,1 is one of the bounds
            const int highest = 9;
            //initialize number of ways the sum can add to 10
            int numWays = 0;
            // minimum and maximum will provide the bounds of our loop
            int minimum = Math.Min(m, n);
            int maximum;
            //low and high will be the number on the dice, we want to start with high and low numbers that are at the bounds
            // so if the highest die is 7 we want to start at 3,7
            int high = Math.Max(m, n);
            int low;
            
            //if the highest value of both of the die do not add up to 10 we know theres no ways to add up to 10
            if (m+n < sum)
            {
                return "There are 0 total ways to get the sum 10.";
            }   
            //if the highest value is greater than 9 change it back to 9 because thats the highest 
            //possible value that will add up to 10 and we set that as our max
            if (high > highest)
            {
                high = highest;
            }
            //set maximum as the highest die
            maximum = high;
            //low will be the number that will sum up to 10 given highest die number
            low = sum - high;
            //keep looping while low is les than maximum and low is less than minimum
            while (low <= maximum && low <= minimum)
            {
                //System.Diagnostics.Debug.WriteLine(low + " " + high);
                //add 1 to low and subtract 1 to high as well as increment the number of ways. so low and high will be the numbers that sum up to 10
                low += 1;
                high -= 1;
                numWays += 1;
            }
            return "There are " + numWays + " total ways to get the sum 10.";
        }
    }
}
