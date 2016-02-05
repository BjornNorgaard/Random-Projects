using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceChance
{
    public class CombinationOfDice
    {
        List<SingleDie> _myListOfDice = new List<SingleDie>();

        public CombinationOfDice(int numberOfDice)
        {
            for (int i = 0; i < numberOfDice; i++)
            {
                AddDie();
            }
        }

        private void AddDie()
        {
            _myListOfDice.Add(new SingleDie(1));
        }

        public void Increment()
        {
            IncrementDieOnIndex(_myListOfDice.Count - 1);
        }

        private void IncrementDieOnIndex(int indexNumberOfDice)
        {
            if (indexNumberOfDice < 0) return;

            if (_myListOfDice[indexNumberOfDice].EyeValue < 6)
            {
                _myListOfDice[indexNumberOfDice].EyeValue++;
                return;
            }

            _myListOfDice[indexNumberOfDice]++;

            IncrementDieOnIndex(indexNumberOfDice - 1);
        }

        public void Print()
        {
            Console.Write("Dice values: ");

            foreach (SingleDie die in _myListOfDice)
            {
                Console.Write(die.EyeValue + ", ");
            }
            Console.WriteLine("");
        }

        public int Find()
        {
            return _myListOfDice.Count(die => die.EyeValue == 1);
        }
    }
}