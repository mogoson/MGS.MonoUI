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

using System.Collections.Generic;
using UnityEngine;

namespace MGS.MonoUI
{
    public class MonoUIManager : MonoBehaviour, IMonoUIManager
    {
        public Transform content;

        public IMonoUILoader Loader { set; get; }
        protected Dictionary<string, List<MonoUI>> cache = new();

        protected virtual void Reset()
        {
            content = transform;
        }

        protected virtual void Awake()
        {
            Loader = GetComponent<IMonoUILoader>();
        }

        protected virtual void OnDestroy()
        {
            DestroyAll();
        }

        public T Create<T>() where T : MonoUI
        {
            var key = typeof(T).Name;
            if (Loader == null)
            {
                Debug.LogError($"Create {key} failed: The Loader is null.");
                return null;
            }
            var asset = Loader.Load<T>(key);
            if (asset == null)
            {
                Debug.LogError($"Create {key} failed: Can not load asset from path {key}");
                return null;
            }
            var ui = Instantiate(asset, content);
            AddToCache(key, ui);
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
            var key = typeof(T).Name;
            if (cache.ContainsKey(key))
            {
                return cache[key][0] as T;
            }
            return null;
        }

        public ICollection<T> FindAll<T>() where T : MonoUI
        {
            var key = typeof(T).Name;
            if (cache.ContainsKey(key))
            {
                return cache[key].ConvertAll(ui => ui as T);
            }
            return null;
        }

        public void Destroy<T>(T ui) where T : MonoUI
        {
            var key = typeof(T).Name;
            if (cache.ContainsKey(key))
            {
                var uis = cache[key];
                uis.Remove(ui);
                if (uis.Count == 0)
                {
                    cache.Remove(key);
                    Loader.Unload(key);
                }
            }
            Object.Destroy(ui.gameObject);
        }

        public void DestroyAll()
        {
            foreach (var uis in cache.Values)
            {
                foreach (var ui in uis)
                {
                    Object.Destroy(ui.gameObject);
                }
            }
            foreach (var key in cache.Keys)
            {
                Loader.Unload(key);
            }
            cache.Clear();
        }

        protected void AddToCache(string key, MonoUI ui)
        {
            if (!cache.ContainsKey(key))
            {
                cache.Add(key, new List<MonoUI>());
            }
            cache[key].Add(ui);
        }
    }
}