using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.DI;
using Assets.HomeWork.Develop.ForHome;
using Assets.HomeWork.ForHome.Configs.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.ForHome
{
    public class PaymentService : IDisposable
    {
        private WalletService _walletService;
        private GameLogic _gameLogic;
        private SettingPaymentsConfig _settingPaymentsConfig;

        public PaymentService(WalletService walletService, SettingPaymentsConfig settingPaymentsConfig)
        {
            _walletService = walletService;
            _settingPaymentsConfig = settingPaymentsConfig;
        }

        public void Initialize(GameLogic gameLogic)
        {
            _gameLogic = gameLogic;
            _gameLogic.Win += WinOfCurrency;
            _gameLogic.Loss += LossOfCurrency;
        }


        public void Dispose()
        {
            _gameLogic.Win -= WinOfCurrency;
            _gameLogic.Loss -= LossOfCurrency;
        }

        private void WinOfCurrency()
        {
            _walletService.Add(CurrencyTypes.Gold, _settingPaymentsConfig.WinOfCurrency);
        }

        private void LossOfCurrency()
        {
            _walletService.Spend(CurrencyTypes.Gold, _settingPaymentsConfig.LossOfCurrency);
        }
    }
}
