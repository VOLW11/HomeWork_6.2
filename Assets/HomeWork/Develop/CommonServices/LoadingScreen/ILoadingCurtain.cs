using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.Develop.CommonServices.LoadingScreen
{
    public interface ILoadingCurtain
    {
        bool IsShown { get; }
        void Show();
        void Hide();
    }
}