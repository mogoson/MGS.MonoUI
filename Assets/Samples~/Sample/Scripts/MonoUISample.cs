/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoUISample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/04/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using UnityEngine;

namespace MGS.MonoUI.Sample
{
    public class MonoUISample : MonoBehaviour
    {
        public MonoUIManager uiManager;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1.0f);
            uiManager.Create<SimpleDepth200UI>();

            yield return new WaitForSeconds(1.0f);
            uiManager.Create<SimpleDepth100UI>();

            yield return new WaitForSeconds(1.0f);
            uiManager.Create<SimpleDepth0UI>();
        }
    }
}