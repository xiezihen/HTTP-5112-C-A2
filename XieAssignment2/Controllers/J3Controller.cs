using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace XieAssignment2.Controllers
{
    public class J3Controller : ApiController
    {
        /// <summary>
        /// https://cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2022/ccc/juniorEF.pdf
        /// This J3 problem from 2022 CCC converts harp tuning instructions into a more human readable format
        /// </summary>
        /// 
        /// <param name="tune_str">
        /// the string of instructions that needs to be converted
        /// ex:AFB+8
        /// ***Note that '+' is a special character in urls so %2b must be used to replace '+' symbol
        /// ***the param will instead be:
        /// ***AFB%2b8 
        /// ***AFB+88HC-444 will be
        /// ***AFB%2b88HC-444
        /// </param>
        /// 
        /// <returns>
        /// returns a list of instructions in a readable format
        /// http://localhost:53396/api/J3/HarpTuning/?tune_str=AFB%2b8 returns:
        /// ["AFB tighten 8"]
        /// http://localhost:53396/api/J3/HarpTuning/?tune_str=AFB%2b88HC-444 returns:
        /// ["AFB tighten 88","HC loosen 444"]
        /// </returns>
        [HttpGet]
        [Route("api/J3/HarpTuning/")]
        public List<string> HarpTuning(string tune_str)
        {
            //variable declarations
            //tuneInstructions stores the list of instructions that have been converted and will be returned
            List<string> tuneInstructions = new List<string>();
            //currentStr is a string that stores each converted instruction which will be added to the list when it recongizes the end of the instruction
            string currentStr = "";
            int strLength = tune_str.Length;
            //System.Diagnostics.Debug.WriteLine(tune_str);
            //this loop will iterate through each character in the tune_str instructions
            for (int i = 0; i < tune_str.Length; i++)
            {
                //System.Diagnostics.Debug.WriteLine(tune_str[i]);
                //if the current char is a letter(meaning its a note) just add it to the currentStr
                if (char.IsLetter(tune_str[i]))
                {
                    currentStr += tune_str[i];
                }
                //if the current char is a + or - sign replace it with tighten or loosen and add it to the currentStr
                else if (tune_str[i] == '+')
                {
                    currentStr += " tighten ";
                }
                else if (tune_str[i] == '-')
                {
                    currentStr += " loosen ";
                }
                //if it is a number we know that it means its either the end of the current instruction or there are more numbers that proceed it
                else
                {
                    //so we check if the index is currently on the last character in tune_str the last char being(strLength-1) because index starts at 0
                    //tune_str[strLength] would be index out of range
                    //if its not the last character in the string we check the index+1 to see if the next character is a number
                    //so if its the last character in tune_str or the next character is not a number add the currentStr to the tuneInstructions list
                    if (i == (strLength - 1) || !Char.IsDigit(tune_str[i + 1]))
                    {
                        tuneInstructions.Add(currentStr + tune_str[i]);
                        currentStr = "";
                    }
                    //if we've reached this else statement it means the next character is a number so we just add the current 
                    //character to the currentStr and we will continue with translating the current instruction
                    else
                    {
                        currentStr += tune_str[i];
                    }
                }

            }
            return tuneInstructions;
            
            
        }
        
    }
}
