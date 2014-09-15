using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuleKata
{
    public class Rules
    {
        public const int SPECIAL_VALUE_THREE = 111;
        public const int SPECIAL_VALUE_JULE = 421;

        public static int RollDie()
        {
            Random dieRoll = new Random();

            return dieRoll.Next(1, 6);
        }

        public static int CalculateDiceValue(int dieOneResult, int dieTwoResult, int dieThreeResult)
        {
            int[] singleDieValues = Rules.SortDice(dieOneResult, dieTwoResult, dieThreeResult);

            string joinedDiceValues = String.Join("", new List<int>(singleDieValues).ConvertAll(i => i.ToString()).ToArray());

            return Convert.ToInt32(joinedDiceValues);
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
            return SPECIAL_VALUE_THREE == diceValue;
        }

        public static bool IsJule(int diceValue)
        {
            return SPECIAL_VALUE_JULE == diceValue;
        }

        public static bool IsHards(int diceValue)
        {
            if (IsThree(diceValue))
            {
                return false;
            }

            int lastTwoDice = diceValue % 100;

            return lastTwoDice == 11;
        }

        public static bool IsSofts(int diceValue)
        {
            if (IsThree(diceValue))
            {
                return false;
            }


            return diceValue % 111 == 0;
        }

        public static bool IsStraight(int diceValue)
        {
            int dieOne = diceValue / 100;
            int dieTwo = diceValue % 100 / 10;
            int dieThree = diceValue % 100 % 10;

            return (--dieOne == dieTwo) && (--dieTwo == dieThree);
        }

        public static int GetMarkersForDiceValue(int diceValue)
        {
            int markers = 0;

            if (IsThree(diceValue)) markers = 8;
            else if (IsJule(diceValue)) markers = 7;
            else if (IsHards(diceValue)) markers = CalculateMarkersForHards(diceValue);
            else if (IsSofts(diceValue)) markers = 3;
            else if (IsStraight(diceValue)) markers = 2;
            else markers = 1;
            
            return markers;
        }

        private static int CalculateMarkersForHards(int diceValue)
        {
            return diceValue / 100;
        }
    }
}
