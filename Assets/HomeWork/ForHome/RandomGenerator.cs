using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.HomeWork.ForHome
{
    public class RandomGenerator
    {
        private List<string> _randomCombination = new ();

        public List<string> CreateCombination(ISelectCombination selectCombination)
        {
            _randomCombination.Clear();

            for (int i = 0; i < selectCombination.Type.Count; i++)
            {
                _randomCombination.Add
                    (selectCombination.Type
                    [Random.Range(0, selectCombination.Type.Count)]);
            }

            return _randomCombination;
        }
    }
}