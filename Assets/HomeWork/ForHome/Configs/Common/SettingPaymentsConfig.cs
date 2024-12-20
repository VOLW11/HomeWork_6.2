using Assets.HomeWork.Develop.CommonServices.Wallet;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.ForHome.Configs.Common
{
    [CreateAssetMenu(menuName = "Configs/Common/SettingPaymentsConfig", fileName = "SettingPaymentsConfig")]

    public class SettingPaymentsConfig : ScriptableObject
    {
        [field: SerializeField] public int WinOfCurrency { get; private set; }
        [field: SerializeField] public int LossOfCurrency { get; private set; }
        [field: SerializeField] public int ResetProgress { get; private set; }

        private void OnValidate()
        {
           
        }
    }
}