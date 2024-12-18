using Assets.HomeWork.Develop.Utils.Reactive;
using Assets.HomeWork.ForHome;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.Develop.ForHome
{
    public class GameLogic : MonoBehaviour
    {
        public event Action Win; 
        public event Action Loss; 

        private List<string> _combination = new();
        private int _listElement = 0;
        private string _messageCombination;
        private RandomGenerator _generator;
        private ISelectCombination _selectCombination;

        public ReactiveVariable<string> computerCombination = new();
        public ReactiveVariable<string> userCombination = new();

       // private IReadOnlyVariable<string> _outCombination = new ReactiveVariable<string>();

        public void Initialize(ISelectCombination selectCombination, RandomGenerator generator)
        {
            _selectCombination = selectCombination;
            _generator = generator;
            _combination = _generator.CreateCombination(_selectCombination);
            
            OutputCombination();

        }

        public bool IsWin { get; private set; }
        public bool IsLoss { get; private set; }

       // public string MessageCombination { get; private set; } 

        private void Update()
        {
            if (IsWin)
                return;

            if (IsLoss)
                return;
            
            if (Input.inputString != _combination[_listElement] && Input.anyKeyDown)
            {
                userCombination.Value = Input.inputString;

                Debug.Log("Проигрыш! Введен неверный символ");
                Loss?.Invoke();//
                IsLoss = true;
            }

            if (Input.GetKeyDown(_combination[_listElement]))
            {
                userCombination.Value = Input.inputString;

                if (_listElement < _combination.Count - 1)
                {
                    _listElement++;
                }

                else
                {
                    Debug.Log("Поздравляем! Введена верная комбинация");
                    Win?.Invoke();//
                    IsWin = true;
                }
            }
        }

        private void OutputCombination()
        {
            foreach (string combination in _combination)
                _messageCombination += combination + " ";

            computerCombination.Value = _messageCombination;

            //MessageCombination = _messageCombination;//
            Debug.Log($"Введите последовательность: {_messageCombination}");
        }
    }
}