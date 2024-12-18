using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.HomeWork.ForHome.CombinationUI
{
    public class CombinationText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textName;
        [SerializeField] private TMP_Text _textValue;

        public void SetTextName(string text) => _textName.text = text;

        public void SetTextValue(string text) => _textValue.text = text;
    }
}