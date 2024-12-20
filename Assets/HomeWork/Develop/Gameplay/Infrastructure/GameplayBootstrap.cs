using Assets.HomeWork.Develop.CommonServices.AssetsManagment;
using Assets.HomeWork.Develop.CommonServices.ConfigsManagment;
using Assets.HomeWork.Develop.CommonServices.LoadingScreen;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.DI;
using Assets.HomeWork.Develop.ForHome;
using Assets.HomeWork.Develop.Gameplay.UI;
using Assets.HomeWork.Develop.MainMenu.UI;
using Assets.HomeWork.ForHome;
using Assets.HomeWork.ForHome.Combination;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.Develop.Gameplay.Infrastructure
{
    public class GameplayBootstrap : MonoBehaviour
    {
        private DIContainer _container;
        private GameplayInputArgs _gameplayInputArgs;
        private GameLogic _gameLogic;

        public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;

            ProcessRegistrations();

            Debug.Log($"���������� ������� ��� ������ {gameplayInputArgs.LevelNumber}");

            _gameplayInputArgs = gameplayInputArgs;

            _gameLogic = _container.Resolve<GameLogic>();

            _gameLogic.Initialize(_gameplayInputArgs.SelectCombination, _container.Resolve<RandomGenerator>());

            _container.Resolve<WinLossCounterService>().Initialize(_gameLogic);
            _container.Resolve<PaymentService>().Initialize(_gameLogic);

            yield return new WaitForSeconds(1f);
        }

        private void ProcessRegistrations()
        {
            //������ ����������� ��� ����� ��������
            _container.RegisterAsSingle(c =>
            {
                Resour�esAssetLoader resourcesAssetLoader = c.Resolve<Resour�esAssetLoader>();

                GameLogic gameLogicPrefab = resourcesAssetLoader
                .LoadResource<GameLogic>(InfrastructureAssetPaths.GameLogicPath);               

                return Instantiate(gameLogicPrefab);
            });

            _container.RegisterAsSingle(c =>
            {
                GameplayUI gameplayUIPrefab = c.Resolve<Resour�esAssetLoader>().LoadResource<GameplayUI>("Gameplay/UI/GameplayUI");
                return Instantiate(gameplayUIPrefab);
            }).NonLazy();

            _container.RegisterAsSingle(c => new CombinationPresenterFactory(c));

            _container
          .RegisterAsSingle(c => c.Resolve<CombinationPresenterFactory>()
          .CreateCombinationPresenter(c.Resolve<GameplayUI>().Combination))
          .NonLazy();

            _container
          .RegisterAsSingle(c => new PaymentService(c.Resolve<WalletService>(), 
                                                    c.Resolve<ConfigsProviderService>().SettingPaymentsConfig));

            _container.Initialize();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _gameLogic.IsWin)
            {
                _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));
            }

            if (Input.GetKeyDown(KeyCode.Space) && _gameLogic.IsLoss)
            {
                _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new GameplayInputArgs(2, _gameplayInputArgs.SelectCombination)));
            }
        }
    }
}