using Assets.HomeWork.ForHome;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.Develop.ForHome
{
    public class GameLogic : MonoBehaviour
    {
        private List<string> _combination = new();
        // private bool isWork = true;
        private int _combinationCount = 0;
        private string _messageCombination;
        private RandomGenerator _generator;
        private ISelectCombination _selectCombination;

        public void Initialize(ISelectCombination selectCombination, RandomGenerator generator)
        {
            _selectCombination = selectCombination;
            _generator = generator;

            _combination = _generator.CreateCombination(_selectCombination);

            OutputCombination();
        }

        private void Update()
        {
            if (Input.anyKeyDown)
            {
               if (Input.GetKeyDown(_combination[_combinationCount]))
                {
                    Debug.Log("yes");

                    _combinationCount++;
                }

               /* else
                {
                    //  isWork = false;

                    Debug.Log("no");
                    Debug.Log(_combination[_combinationCount]);
                }*/
            }
        }

        private void OutputCombination()
        {
            foreach (string combination in _combination)
                _messageCombination += combination + " ";

            Debug.Log($"¬ведите последовательность: {_messageCombination}");
        }
    }
}