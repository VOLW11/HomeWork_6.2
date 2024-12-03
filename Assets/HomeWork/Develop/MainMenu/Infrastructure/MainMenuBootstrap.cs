using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using Assets.HomeWork.Develop.DI;
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
            //Делаем регистрации для сцены геймплея
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputMainMenuArgs
                    (new GameplayInputArgs(2, new ListOfNumbers())));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputMainMenuArgs
                    (new GameplayInputArgs(2, new ListOfLetters())));
            }
        }
    }
}