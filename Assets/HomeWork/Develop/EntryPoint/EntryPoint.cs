using UnityEditor;
using UnityEngine;
using Assets.HomeWork.Develop.DI;
using Assets.HomeWork.Develop.CommonServices.CoroutinePerfomer;
using Assets.HomeWork.Develop.CommonServices.AssetsManagment;
using Assets.HomeWork.Develop.CommonServices.LoadingScreen;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using System;
using Assets.HomeWork.ForHome;

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
           
            
            RegisterRandomGenerator(projectContainer);

            //все регистрации прошли
            projectContainer.Resolve<ICoroutinePerformer>().StartPerform(_gameBootstrap.Run(projectContainer));
        }

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 144;
        }

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
