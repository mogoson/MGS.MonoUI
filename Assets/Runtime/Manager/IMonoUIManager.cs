/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMonoUIManager.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/03/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.MonoUI
{
    public interface IMonoUIManager
    {
        T Create<T>() where T : MonoUI;

        T CreateIfNotFind<T>() where T : MonoUI;

        T Find<T>() where T : MonoUI;

        ICollection<T> FindAll<T>() where T : MonoUI;

        void Destroy<T>(T ui) where T : MonoUI;

        void DestroyAll();
    }
}