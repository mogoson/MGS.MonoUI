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

using System;
using UnityEngine;

namespace MGS.MonoUI
{
    public abstract class MonoUILoader : MonoBehaviour, IMonoUILoader
    {
        public abstract T Load<T>() where T : MonoUI;

        public abstract void Unload(Type type);
    }
}