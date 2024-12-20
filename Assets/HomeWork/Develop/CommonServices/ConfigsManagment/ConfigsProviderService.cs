using Assets.HomeWork.Develop.CommonServices.AssetsManagment;
using Assets.HomeWork.Develop.Configs.Common.Wallet;
using Assets.HomeWork.ForHome.Configs.Common;
//using Assets.HomeWork.Develop.Configs.Gameplay;

namespace Assets.HomeWork.Develop.CommonServices.ConfigsManagment
{
    public class ConfigsProviderService
    {
        private ResourсesAssetLoader _resourcesAssetLoader;

        public ConfigsProviderService(ResourсesAssetLoader resourcesAssetLoader)
        {
            _resourcesAssetLoader = resourcesAssetLoader;
        }

        public StartWalletConfig StartWalletConfig { get; private set; }

        public CurrencyIconsConfig CurrencyIconsConfig { get; private set; }

        public SettingPaymentsConfig SettingPaymentsConfig { get; private set; }

       // public LevelListConfig LevelsListConfig { get; private set; }   

        public void LoadAll()
        {
            //подгружать конфиги из ресурсов
            LoadStartWalletConfig();
            LoadCurrencyIconsConfig();
            LoadSettingPaymentsConfig();
          //  LoadLevelsListConfig();
        }

        private void LoadStartWalletConfig()
            => StartWalletConfig = _resourcesAssetLoader.LoadResource<StartWalletConfig>("Configs/Common/Wallet/StartWalletConfig");

        private void LoadCurrencyIconsConfig()
            => CurrencyIconsConfig = _resourcesAssetLoader.LoadResource<CurrencyIconsConfig>("Configs/Common/Wallet/CurrencyIconsConfig");

        private void LoadSettingPaymentsConfig()
           => SettingPaymentsConfig = _resourcesAssetLoader.LoadResource<SettingPaymentsConfig>("ForHome/Configs/Common/SettingPaymentsConfig");

        /*   private void LoadLevelsListConfig()
               => LevelsListConfig = _resourcesAssetLoader.LoadResource<LevelListConfig>("Configs/Gameplay/Levels/LevelListConfig");*/
    }
}
