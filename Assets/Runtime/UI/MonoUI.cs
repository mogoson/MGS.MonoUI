/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/04/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.MonoUI
{
    public class MonoUI : MonoBehaviour, IMonoUI
    {
        public virtual bool IsShow { get { return gameObject.activeSelf; } }
        protected IFocusable focusable;

        protected virtual void Awake()
        {
            focusable = GetComponent<IFocusable>();
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Focus()
        {
            focusable?.Focus();
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }

    public abstract class MonoUI<T> : MonoUI, IMonoUI<T>
    {
        protected T data;

        public void Refresh(T data)
        {
            this.data = data;
            OnRefresh(data);
        }

        protected abstract void OnRefresh(T data);
    }
}