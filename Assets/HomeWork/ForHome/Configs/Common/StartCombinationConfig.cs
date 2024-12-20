using Assets.HomeWork.Develop.CommonServices.Wallet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.HomeWork.ForHome.Configs.Common
{
    [CreateAssetMenu(menuName = "Configs/Common/StartCombinationConfig", fileName = "StartCombinationConfig")]

    public class StartCombinationConfig : ScriptableObject
    {
        [SerializeField] private List<CombinationConfig> _values;

        private void OnValidate()
        {
            //можно проверить точно ли все элементы енама представлены в конфиге
            //нет ли дупликатов и тд
        }

        public List<char> GetStartValueFor(CombinationTypes combinationType) => _values.First(config => config.Type == combinationType).Value;

        [Serializable]
        private class CombinationConfig
        {
            [field: SerializeField] public CombinationTypes Type { get; private set; }
            [field: SerializeField] public List<char> Value { get; private set; }
        }
    }
}