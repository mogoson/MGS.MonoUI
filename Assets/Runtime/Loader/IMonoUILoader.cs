/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMonoUILoader.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/04/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.MonoUI
{
    public interface IMonoUILoader
    {
        T Load<T>() where T : MonoUI;

        void Unload(Type type);
    }
}