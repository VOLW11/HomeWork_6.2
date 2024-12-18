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

        public CounterPresenter(WinLossCounterService counterService, IconsWithTextListView view)
        {
            _view = view;
            _counterService = counterService;

        }

        public void Initialize()
        {    
                IconWithText winView = _view.SpawnElement();
                winView.SetText("Win " + _counterService.NumberOfWin.ToString());

                IconWithText lossView = _view.SpawnElement();
                lossView.SetText("Loss " + _counterService.NumberOfLoss.ToString());  
        }

        public void Dispose()
        {
            //_view.Remove();
            
        }

    }
}