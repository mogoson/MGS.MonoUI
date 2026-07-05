/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoUILoader.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/04/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.AssetLoader;
using UnityEngine;

namespace MGS.MonoUI
{
    /// <summary>
    /// UI loader base on UnityEngine.Resources
    /// </summary>
    public class MonoUILoader : MonoBehaviour, IMonoUILoader
    {
        public string directory = "UIPrefabs";
        protected IAssetLoader loader = new AssetLoader.AssetLoader();

        public T Load<T>(string name) where T : Object
        {
            var path = GetPath(name);
            return loader.Load<T>(path);
        }

        public void Unload(string name)
        {
            var path = GetPath(name);
            loader.Unload(path);
        }

        public void Unload(Object asset)
        {
            loader.Unload(asset);
        }

        public void UnloadAll()
        {
            loader.UnloadAll();
        }

        protected string GetPath(string name)
        {
            return $"{directory}/{name}";
        }
    }
}