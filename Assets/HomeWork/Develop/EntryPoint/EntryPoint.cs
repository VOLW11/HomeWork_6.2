using UnityEditor;
using UnityEngine;
using Assets.HomeWork.Develop.DI;
using Assets.HomeWork.Develop.CommonServices.CoroutinePerfomer;
using Assets.HomeWork.Develop.CommonServices.AssetsManagment;
using Assets.HomeWork.Develop.CommonServices.LoadingScreen;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using System;
using Assets.HomeWork.ForHome;
using System.ComponentModel;
using Assets.HomeWork.Develop.CommonServices.DataManagment;
using Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders;
using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.CommonServices.ConfigsManagment;
using Assets.HomeWork.Develop.ForHome;
using Assets.HomeWork.Develop.Gameplay.Infrastructure;

namespace Assets.HomeWork.Develop.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Bootstrap _gameBootstrap;

        private void Awake()
        {
            SetupAppSettings();

            DIContainer projectContainer = new DIContainer();

            //регистрация сервисов на целый проект
            //Аналог global context из популярных DI фреймворков
            //Самый родительский контейнер для всех будущих

            RegisterResourcesAssetLoader(projectContainer);
            RegisterCoroutinePerformer(projectContainer);

            RegisterLoadingCurtain(projectContainer);
            RegisterSceneLoader(projectContainer);
            RegisterSceneSwitcher(projectContainer);
           
            RegisterSaveLoadService(projectContainer);
            RegisterPlayerDataProvider(projectContainer); 
            
            RegisterWalletService(projectContainer);   
            
            RegisterConfigsProviderService(projectContainer); 
            

            RegisterWinLossCounterService(projectContainer);

            RegisterRandomGenerator(projectContainer);

            projectContainer.Initialize();

            //все регистрации прошли
            projectContainer.Resolve<ICoroutinePerformer>().StartPerform(_gameBootstrap.Run(projectContainer));
        }


        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 144;
        }

        private void RegisterConfigsProviderService(DIContainer container)
            => container.RegisterAsSingle(c => new ConfigsProviderService(c.Resolve<ResourсesAssetLoader>()));

        private void RegisterWalletService(DIContainer container)
            => container.RegisterAsSingle(c => new WalletService(c.Resolve<PlayerDataProvider>())).NonLazy();  

        private void RegisterPlayerDataProvider(DIContainer container)
            => container.RegisterAsSingle<PlayerDataProvider>(c => new PlayerDataProvider(c.Resolve<ISaveLoadService>(), c.Resolve<ConfigsProviderService>()));

        private void RegisterSaveLoadService(DIContainer container)
            => container.RegisterAsSingle<ISaveLoadService>(c => new SaveLoadService(new JsonSerializer(), new LocalDataRepository()));

        //
        private void RegisterWinLossCounterService(DIContainer container)
         => container.RegisterAsSingle(c => new WinLossCounterService(c.Resolve<PlayerDataProvider>())).NonLazy(); 


        private void RegisterRandomGenerator(DIContainer container)
        {
            container.RegisterAsSingle(c => new RandomGenerator());
        }

        private void RegisterSceneSwitcher(DIContainer container)
            => container.RegisterAsSingle(c
                => new SceneSwitcher(
                    c.Resolve<ICoroutinePerformer>(),
                    c.Resolve<ILoadingCurtain>(),
                    c.Resolve<ISceneLoader>(),
                    c));

        private void RegisterResourcesAssetLoader(DIContainer container)
            => container.RegisterAsSingle(c => new ResourсesAssetLoader());

        private void RegisterCoroutinePerformer(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinePerformer>(c =>
            {
                ResourсesAssetLoader resourcesAssetLoader = c.Resolve<ResourсesAssetLoader>();

                CoroutinePerformer coroutinePerformerPrefab = resourcesAssetLoader
                .LoadResource<CoroutinePerformer>(InfrastructureAssetPaths.CoroutinePerformerPath);

                return Instantiate(coroutinePerformerPrefab);
            });
        }

        private void RegisterLoadingCurtain(DIContainer container)
        {
            container.RegisterAsSingle<ILoadingCurtain>(c =>
            {
                ResourсesAssetLoader resourcesAssetLoader = c.Resolve<ResourсesAssetLoader>();

                StandardLoadingCurtain standardLoadingCurtainPrefab = resourcesAssetLoader
                .LoadResource<StandardLoadingCurtain>(InfrastructureAssetPaths.LoadingCurtainPath);

                return Instantiate(standardLoadingCurtainPrefab);
            });
        }

        private void RegisterSceneLoader(DIContainer container)
            => container.RegisterAsSingle<ISceneLoader>(c => new DefaultSceneLoader());
    }
}
