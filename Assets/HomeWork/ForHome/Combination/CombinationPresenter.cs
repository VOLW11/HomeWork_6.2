using Assets.HomeWork.Develop.CommonUI;
using Assets.HomeWork.Develop.DI;
using Assets.HomeWork.Develop.ForHome;
using Assets.HomeWork.Develop.Utils.Reactive;
using Assets.HomeWork.ForHome.CombinationUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.ForHome.Combination
{
    public class CombinationPresenter : IInitializable, IDisposable
    {
        private CombinationsTextListView _view;
        private GameLogic _gameLogic;

        private IReadOnlyVariable<string> _computerCombination;
        private IReadOnlyVariable<string> _userCombination;

        public CombinationPresenter(CombinationsTextListView view, 
                                    GameLogic gameLogic, 
                                    IReadOnlyVariable<string> computerCombination, 
                                    IReadOnlyVariable<string> userCombination)
        {
            _view = view;
            _gameLogic = gameLogic;

            _computerCombination = computerCombination;
            _userCombination = userCombination;
        }


        public void Initialize()
        {
            _computerCombination.Changed += SetComputerCombination;
            _userCombination.Changed += SetUserCombination;


            //CombinationText generatorView = _view.SpawnElement();
            // generatorView.SetTextName("¬ведите последовательность");
            // generatorView.SetTextValue(_gameLogic.MessageCombination);
        }

        public void Dispose()
        {
            _computerCombination.Changed -= SetComputerCombination;
            _userCombination.Changed -= SetUserCombination;
        }

        public void SetComputerCombination(string arg1, string Value)
        {
            CombinationText generatorView = _view.SpawnElement();
            generatorView.SetTextName("¬ведите комбинацию");
            generatorView.SetTextValue(Value);
        }

        public void SetUserCombination(string arg1, string Value)
        {
            CombinationText userView = _view.SpawnElement();
            userView.SetTextName("¬вод пользовател€");
            userView.SetTextValue(_userCombination.Value);
        }
    }
}