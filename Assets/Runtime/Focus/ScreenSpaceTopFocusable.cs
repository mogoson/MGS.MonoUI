/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ScreenSpaceTopFocusable.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/05/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.MonoUI
{
    public class ScreenSpaceTopFocusable : MonoBehaviour, IFocusable
    {
        public virtual void Focus()
        {
            transform.SetAsLastSibling();
        }
    }
}