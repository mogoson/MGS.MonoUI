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
using MGS.Singleton;
using UnityEngine;

namespace MGS.MonoUI
{
    public sealed class MonoUIManager : MonoSingleton<MonoUIManager>, IMonoUIManager
    {
        public Transform content;

        public IMonoUILoader Loader { set; get; }
        private Dictionary<string, List<MonoUI>> cache = new();

        private void Reset()
        {
            content = transform;
        }

        private void Awake()
        {
            Loader = GetComponent<IMonoUILoader>();
        }

        public T Create<T>(bool isNew = false) where T : MonoUI
        {
            var ui = isNew ? null : Find<T>();
            if (ui != null)
            {
                return ui;
            }
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
            ui = Instantiate(asset, content);
            AddToCache(key, ui);
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

        public void Destroy<T>(T ui, bool unload = false) where T : MonoUI
        {
            var key = typeof(T).Name;
            if (cache.ContainsKey(key))
            {
                var uis = cache[key];
                uis.Remove(ui);
                if (uis.Count == 0)
                {
                    cache.Remove(key);
                }
            }
            Object.Destroy(ui.gameObject);
            if (unload && !cache.ContainsKey(key))
            {
                Loader.Unload(key);
            }
        }

        public void DestroyAll(bool unload = false)
        {
            foreach (var uis in cache.Values)
            {
                foreach (var ui in uis)
                {
                    Object.Destroy(ui.gameObject);
                }
            }
            if (unload)
            {
                foreach (var key in cache.Keys)
                {
                    Loader.Unload(key);
                }
            }
            cache.Clear();
        }

        private void AddToCache(string key, MonoUI ui)
        {
            if (!cache.ContainsKey(key))
            {
                cache.Add(key, new List<MonoUI>());
            }
            cache[key].Add(ui);
        }
    }
}