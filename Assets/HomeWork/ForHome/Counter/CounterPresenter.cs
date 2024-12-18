using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.CommonUI;
using Assets.HomeWork.Develop.CommonUI.Wallet;
using Assets.HomeWork.Develop.DI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.ForHome
{
    public class CounterPresenter : IInitializable, IDisposable
    {
        private WinLossCounterService _counterService;
        private IconsWithTextListView _view;

        private IconWithText _winView;
        private IconWithText _lossView;

        public CounterPresenter(WinLossCounterService counterService, IconsWithTextListView view)
        {
            _view = view;
            _counterService = counterService;
        }

        public void Initialize()
        {
            _winView = _view.SpawnElement();
            _winView.SetText("Win " + _counterService.NumberOfWin.ToString());

            _lossView = _view.SpawnElement();
            _lossView.SetText("Loss " + _counterService.NumberOfLoss.ToString());
        }

        public void Dispose()
        {
            _view.Remove(_winView);
            _view.Remove(_lossView);
        }
    }
}