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
    public class ScreenSpaceDepthFocusable : MonoBehaviour, IMonoUIFocusable
    {
        public int depth = 0;

        public virtual void Focus()
        {
            var index = 0;
            foreach (Transform sibling in transform.parent)
            {
                if (sibling == transform) continue;
                var siblingDepth = 0;
                var focus = sibling.GetComponent<ScreenSpaceDepthFocusable>();
                if (focus != null)
                {
                    siblingDepth = focus.depth;
                }
                if (depth >= siblingDepth)
                {
                    index = sibling.GetSiblingIndex() + 1;
                }
            }
            transform.SetSiblingIndex(index);
        }
    }
}