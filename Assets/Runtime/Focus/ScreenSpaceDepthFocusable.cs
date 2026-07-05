/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ScreenSpaceDepthFocusable.cs
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
    public class ScreenSpaceDepthFocusable : MonoBehaviour, IFocusable
    {
        public int depth = 0;

        public virtual void Focus()
        {
            var index = 0;
            foreach (Transform child in transform.parent)
            {
                var siblingDepth = child.GetComponent<ScreenSpaceDepthFocusable>()?.depth;
                if (siblingDepth <= depth)
                {
                    var siblingIndex = child.transform.GetSiblingIndex();
                    if (index < siblingIndex)
                    {
                        index = siblingIndex;
                    }
                }
            }
            transform.SetSiblingIndex(index);
        }
    }
}