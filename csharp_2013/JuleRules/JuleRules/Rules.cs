using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuleKata
{
    public class Rules
    {
        public static int RollDie()
        {
            Random dieRoll = new Random();

            return dieRoll.Next(1, 6);
        }

        public static int[] SortDice(int dieOneValue, int dieTwoValue, int dieThreeValue)
        {
            int[] workingArray = new int[] { dieOneValue, dieTwoValue, dieThreeValue };
            Array.Sort(workingArray);
            Array.Reverse(workingArray);

            return workingArray;
        }

        public static bool IsThree(int diceValue)
        {
            return 111 == diceValue;
        }

        public static int CalculateDiceValue(int p1, int p2, int p3)
        {
            int[] singleDieValues = Rules.SortDice(p1, p2, p3);

            string joinedDiceValues = String.Join("", new List<int>(singleDieValues).ConvertAll(i => i.ToString()).ToArray());

            return Convert.ToInt32(joinedDiceValues);
        }
    }
}
