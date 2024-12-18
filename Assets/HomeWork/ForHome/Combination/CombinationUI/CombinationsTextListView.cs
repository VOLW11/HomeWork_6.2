using Assets.HomeWork.Develop.CommonUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.ForHome.CombinationUI
{
    public class CombinationsTextListView : MonoBehaviour
    {
        [SerializeField] private CombinationText _combinationTextPrefab;
        [SerializeField] private Transform _parent;

        private List<CombinationText> _elements = new();

        public CombinationText SpawnElement()
        {
            CombinationText combinationText = Instantiate(_combinationTextPrefab, _parent);
            _elements.Add(combinationText);
            return combinationText;
        }

        public void Remove(CombinationText text)
        {
            _elements.Remove(text);
            Destroy(text.gameObject);
        }
    }
}