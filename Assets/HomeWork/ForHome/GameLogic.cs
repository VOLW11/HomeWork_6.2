using Assets.HomeWork.ForHome;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.Develop.ForHome
{
    public class GameLogic : MonoBehaviour
    {
        private List<string> _combination = new();
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
        public bool IsLoss { get; private set; }

        private void Update()
        {
            if (IsWin)
                return;

            if (IsLoss)
                return;

            if (Input.inputString != _combination[_listElement] && Input.anyKeyDown)
            {
                Debug.Log("Проигрыш! Введен неверный символ");
                IsLoss = true;
            }

            if (Input.GetKeyDown(_combination[_listElement]))
            {

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
        }

        private void OutputCombination()
        {
            foreach (string combination in _combination)
                _messageCombination += combination + " ";

            Debug.Log($"Введите последовательность: {_messageCombination}");
        }
    }
}