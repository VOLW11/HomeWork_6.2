using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.HomeWork.Develop.CommonServices.AssetsManagment
{
    public class ResourņesAssetLoader
    {
        public T LoadResource<T>(string resourcePath) where T : Object
         => Resources.Load<T>(resourcePath);
    }
}