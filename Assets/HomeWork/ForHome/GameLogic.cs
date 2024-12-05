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
        private int _listElement = 0;
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

        public bool IsWin { get; private set; }

        private void Update()
        {
            if (IsWin)
                return;

            if (Input.anyKeyDown)
            {

                if (Input.GetKeyUp(_combination[_listElement]))
                {
                    Debug.Log("yes");

                    if (_listElement < _combination.Count - 1)
                    {
                        _listElement++;
                    }

                    else
                    {
                        Debug.Log("Поздравляем! Введена верная комбинация");
                        IsWin = true;
                    }
                }


                else
                {

                    Debug.Log("no");


                }
            }
             /* else
                  Debug.Log(_combination[_listElement]);*/

        }

        private void OutputCombination()
        {
            foreach (string combination in _combination)
                _messageCombination += combination + " ";

            Debug.Log($"Введите последовательность: {_messageCombination}");
        }
    }
}