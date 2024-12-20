using Assets.HomeWork.Develop.CommonServices.AssetsManagment;
using Assets.HomeWork.Develop.CommonServices.DataManagment;
using Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.CommonUI.Wallet;
using Assets.HomeWork.Develop.DI;
using Assets.HomeWork.Develop.MainMenu.UI;
using Assets.HomeWork.ForHome;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.Develop.MainMenu.Infrastructure
{
    public class MainMenuBootstrap : MonoBehaviour
    {
        private DIContainer _container;

        public IEnumerator Run(DIContainer container, MainMenuInputArgs mainMenuInputArgs)
        {
            _container = container;

            ProcessRegistrations();

            yield return new WaitForSeconds(1f);
        }

        private void ProcessRegistrations()
        {
            //Äåëàåì ðåãèñòðàöèè äëÿ ñöåíû ãåéìïëåÿ
            _container.RegisterAsSingle(c => new WalletPresenterFactory(c));
            _container.RegisterAsSingle(c => new CounterPresenterFactory(c));

            _container.RegisterAsSingle(c =>
            {
                MainMenuUIRoot mainMenuUIRootPrefab = c.Resolve<ResourñesAssetLoader>().LoadResource<MainMenuUIRoot>("MainMenu/UI/MainMenuUIRoot");
                return Instantiate(mainMenuUIRootPrefab);
            }).NonLazy();

            _container
           .RegisterAsSingle(c => c.Resolve<WalletPresenterFactory>()
           .CreateWalletPresenter(c.Resolve<MainMenuUIRoot>().WalletView))
           .NonLazy();

            _container
           .RegisterAsSingle(c => c.Resolve<CounterPresenterFactory>()
           .CreateCounterPresenter(c.Resolve<MainMenuUIRoot>().WinAndLossView))
           .NonLazy();

            _container.Initialize();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputMainMenuArgs
                    (new GameplayInputArgs(new ListOfNumbers())));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputMainMenuArgs
                    (new GameplayInputArgs(new ListOfLetters())));
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _container.Resolve<PlayerDataProvider>().Save();
            }
        }
    }
}