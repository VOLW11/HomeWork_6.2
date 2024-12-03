using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.ForHome
{
    public class ListOfLetters : ISelectCombination
    {
        private List<string> _letters = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };

        public List<string> Type => _letters;
    }
}