using Assets.HomeWork.Develop.CommonServices.AssetsManagment;
using Assets.HomeWork.Develop.CommonServices.LoadingScreen;
using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using Assets.HomeWork.Develop.DI;
using Assets.HomeWork.Develop.ForHome;
using Assets.HomeWork.ForHome;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.Develop.Gameplay.Infrastructure
{
    public class GameplayBootstrap : MonoBehaviour
    {
        private DIContainer _container;
        private GameplayInputArgs _gameplayInputArgs;

        public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;

            ProcessRegistrations();

            Debug.Log($"���������� ������� ��� ������ {gameplayInputArgs.LevelNumber}");

            _gameplayInputArgs = gameplayInputArgs;

            GameLogic gameLogic = _container.Resolve<GameLogic>();

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

                gameLogicPrefab.Initialize(_gameplayInputArgs.SelectCombination, c.Resolve<RandomGenerator>());                

                return Instantiate(gameLogicPrefab);
            });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));
            }
        }
    }
}