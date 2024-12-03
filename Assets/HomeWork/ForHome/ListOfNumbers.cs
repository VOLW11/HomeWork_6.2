using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.ForHome
{
    public class ListOfNumbers : ISelectCombination
    {
        private List<string> _numbers = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public List<string> Type => _numbers;
    }
}