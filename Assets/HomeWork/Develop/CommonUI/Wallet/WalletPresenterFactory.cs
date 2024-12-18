﻿using Assets.HomeWork.Develop.CommonServices.ConfigsManagment;
using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.DI;

namespace Assets.HomeWork.Develop.CommonUI.Wallet
{
    public class WalletPresenterFactory
    {
        private WalletService _walletService;
        private ConfigsProviderService _configsProviderService;

        public WalletPresenterFactory(DIContainer container)
        {
            _walletService = container.Resolve<WalletService>();   
            _configsProviderService = container.Resolve<ConfigsProviderService>();
        }

        public WalletPresenter CreateWalletPresenter(IconsWithTextListView view)
            => new WalletPresenter(_walletService, view, this);

        public CurrencyPresenter CreateCurrencyPresenter(IconWithText view, CurrencyTypes currencyType)
            => new CurrencyPresenter(_walletService.GetCurrency(currencyType), currencyType, view, _configsProviderService.CurrencyIconsConfig);
    }
}