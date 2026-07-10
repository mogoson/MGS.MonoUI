/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoUIResourcesLoader.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/09/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.MonoUI
{
    public class MonoUIResourcesLoader : MonoUILoader
    {
        public string directory = "UIPrefabs";

        public override T Load<T>()
        {
            var path = GetAssetPath<T>();
            return Resources.Load<T>(path);
        }

        public override void Unload(Type type)
        {
            /*
            Resources.UnloadAsset only be used on individual asset
            and can not be used on GameObject's / Components / AssetBundles or GameManagers,
            so this method do nothing.
            You should call the Resources.UnloadUnusedAssets method at the appropriate time,
            example after unload a scene or when game is idle.
            */

            /*
            var assets = Resources.FindObjectsOfTypeAll(type);
            foreach (var asset in assets)
            {
                if (asset.GetType() != type || asset.GetInstanceID() < 0)
                {
                    continue;
                }
                Resources.UnloadAsset(asset);
            }
            */
        }

        protected string GetAssetPath<T>()
        {
            return $"{directory}/{typeof(T).Name}";
        }
    }
}