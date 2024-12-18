using Assets.HomeWork.Develop.CommonServices.ConfigsManagment;
using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.CommonUI.Wallet;
using Assets.HomeWork.Develop.CommonUI;
using Assets.HomeWork.Develop.DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.ForHome
{
    public class CounterPresenterFactory
    {
        private WinLossCounterService _counterService;

        public CounterPresenterFactory(DIContainer container)
        {
            _counterService = container.Resolve<WinLossCounterService>();
        }

        public CounterPresenter CreateCounterPresenter(IconsWithTextListView view)
            => new CounterPresenter(_counterService, view);
    }
}