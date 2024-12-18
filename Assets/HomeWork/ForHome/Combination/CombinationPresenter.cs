using Assets.HomeWork.Develop.CommonUI;
using Assets.HomeWork.Develop.DI;
using Assets.HomeWork.Develop.ForHome;
using Assets.HomeWork.Develop.Utils.Reactive;
using Assets.HomeWork.ForHome.CombinationUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Assets.HomeWork.ForHome.Combination
{
    public class CombinationPresenter : IInitializable, IDisposable
    {
        private CombinationsTextListView _view;
        private GameLogic _gameLogic;

        private CombinationText _userView;
        private CombinationText _generatorView;

        private string _messageComputer = "¬ведите комбинацию";
        private string _messageUser = "¬вод пользовател€";

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

            _generatorView = _view.SpawnElement();
            _generatorView.SetTextName(_messageComputer);

            _userView = _view.SpawnElement();
            _userView.SetTextName(_messageUser);
        }

        public void Dispose()
        {
            _computerCombination.Changed -= SetComputerCombination;
            _userCombination.Changed -= SetUserCombination;

            _view.Remove(_userView);
            _view.Remove(_generatorView);
        }

        public void SetComputerCombination(string arg1, string Value)
        {
            if (_generatorView != null)
                _generatorView.SetTextValue(Value);
        }

        public void SetUserCombination(string arg1, string Value)
        {
            if (_userView != null)
                _userView.SetTextValue(Value);
        }
    }
}