using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace XieAssignment2.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// this will add up the calories with the provided menu choices
        /// </summary>
        /// <param name="burger">
        /// burger menu choice between 1-4
        /// </param>
        /// <param name="drink">
        /// drink menu choice between 1-4
        /// </param>
        /// <param name="side">
        /// side menu choice between 1-4
        /// </param>
        /// <param name="dessert">
        /// desert menu choice between 1-4
        /// </param>
        /// <returns>using the menu choises given by the user use the corresponding calorie count, sum them and return the total</returns>
        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public string Menu(int burger, int drink, int side, int dessert)
        {
            //declare and initialize constants and varaibles
            //this is a constant taht will be the format of the response
            const string response = "Your total calorie count is ";
            //the total calories addedup
            int totalCalories;
            //this is the menu information 
            int[] burgers = { 461, 431, 420, 0 };
            int[] drinks = { 130, 160, 118, 0 };
            int[] sides = { 100, 57, 70, 0 };
            int[] desserts = { 167, 266, 75, 0 };
            //we sum up the total calories and save it in totalCalories, we subtract 1 from the index because arrays start at index 0 bu user inputs are between 1-4
            totalCalories = burgers[burger-1] + drinks[drink-1] + sides[side-1] + desserts[dessert-1];
            return response + totalCalories;
        }
        public int Get()
        {
            return 10;
        }
    }
}
