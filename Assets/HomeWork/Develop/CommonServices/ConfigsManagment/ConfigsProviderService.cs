using Assets.HomeWork.Develop.CommonServices.AssetsManagment;
using Assets.HomeWork.Develop.Configs.Common.Wallet;
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

       // public LevelListConfig LevelsListConfig { get; private set; }   

        public void LoadAll()
        {
            //подгружать конфиги из ресурсов
            LoadStartWalletConfig();
            LoadCurrencyIconsConfig();
          //  LoadLevelsListConfig();
        }

        private void LoadStartWalletConfig()
            => StartWalletConfig = _resourcesAssetLoader.LoadResource<StartWalletConfig>("Configs/Common/Wallet/StartWalletConfig");

        private void LoadCurrencyIconsConfig()
            => CurrencyIconsConfig = _resourcesAssetLoader.LoadResource<CurrencyIconsConfig>("Configs/Common/Wallet/CurrencyIconsConfig");

     /*   private void LoadLevelsListConfig()
            => LevelsListConfig = _resourcesAssetLoader.LoadResource<LevelListConfig>("Configs/Gameplay/Levels/LevelListConfig");*/
    }
}
