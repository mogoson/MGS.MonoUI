/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoUIManager.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/03/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace MGS.MonoUI
{
    public class MonoUIManager : MonoBehaviour, IMonoUIManager
    {
        public Transform container;
        public MonoUILoader loader;
        protected Dictionary<Type, List<MonoUI>> cache = new();

        protected virtual void Reset()
        {
            container = transform;
        }

        protected virtual void OnDestroy()
        {
            DestroyAll();
        }

        public T Create<T>() where T : MonoUI
        {
            if (loader == null)
            {
                Debug.LogError("Create UI failed: The Loader is null.");
                return null;
            }
            var asset = loader.Load<T>();
            if (asset == null)
            {
                Debug.LogError($"Create UI failed: Can not load asset for {typeof(T).Name}");
                return null;
            }
            var ui = Instantiate(asset, container);
            AddToCache(ui);
            return ui;
        }

        public T CreateIfNotFind<T>() where T : MonoUI
        {
            var ui = Find<T>();
            if (ui == null)
            {
                ui = Create<T>();
            }
            return ui;
        }

        public T Find<T>() where T : MonoUI
        {
            var key = typeof(T);
            if (cache.ContainsKey(key))
            {
                return cache[key][0] as T;
            }
            return null;
        }

        public ICollection<T> FindAll<T>() where T : MonoUI
        {
            var key = typeof(T);
            if (cache.ContainsKey(key))
            {
                return cache[key].ConvertAll(ui => ui as T);
            }
            return null;
        }

        public void Destroy<T>(T ui) where T : MonoUI
        {
            var key = typeof(T);
            if (cache.ContainsKey(key))
            {
                var uis = cache[key];
                uis.Remove(ui);
                if (uis.Count == 0)
                {
                    cache.Remove(key);
                    loader.Unload(key);
                }
            }
            UnityEngine.Object.Destroy(ui.gameObject);
        }

        public void DestroyAll()
        {
            foreach (var kv in cache)
            {
                foreach (var ui in kv.Value)
                {
                    UnityEngine.Object.Destroy(ui.gameObject);
                }
                loader.Unload(kv.Key);
            }
            cache.Clear();
        }

        protected void AddToCache(MonoUI ui)
        {
            var key = ui.GetType();
            if (!cache.ContainsKey(key))
            {
                cache.Add(key, new List<MonoUI>());
            }
            cache[key].Add(ui);
        }
    }
}