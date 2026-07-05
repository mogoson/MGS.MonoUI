/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  WorldSpaceFocusable.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/05/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using MGS.Adaptive;
using UnityEngine;

namespace MGS.MonoUI
{
    public class WorldSpaceFocusable : MonoBehaviour, IFocusable
    {
        protected ICollection<IAdaptive> adaptives;

        protected virtual void Awake()
        {
            adaptives = GetComponents<IAdaptive>();
        }

        public virtual void Focus()
        {
            foreach (var adaptive in adaptives)
            {
                adaptive.Adapt();
            }
        }
    }
}