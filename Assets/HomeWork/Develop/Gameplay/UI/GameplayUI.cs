using Assets.HomeWork.Develop.CommonUI;
using Assets.HomeWork.ForHome.CombinationUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.Develop.Gameplay.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [field: SerializeField] public CombinationsTextListView Combination { get; private set; }

        [field: SerializeField] public Transform HUDLayer { get; private set; }
        [field: SerializeField] public Transform PopupsLayer { get; private set; }

    }
}