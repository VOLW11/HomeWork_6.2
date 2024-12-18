using Assets.HomeWork.Develop.CommonUI;
using Assets.HomeWork.Develop.DI;
using Assets.HomeWork.Develop.ForHome;
using Assets.HomeWork.ForHome.CombinationUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.ForHome.Combination
{
    public class CombinationPresenterFactory
    {
        private GameLogic _gameLogic;

        public CombinationPresenterFactory(DIContainer container)
        {
          _gameLogic = container.Resolve<GameLogic>();
        }

        public CombinationPresenter CreateCombinationPresenter(CombinationsTextListView view)
            => new CombinationPresenter(view, _gameLogic, _gameLogic.computerCombination, _gameLogic.userCombination);
    }
}