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
        IEnumerator Start()
        {
            var ui = MonoUIManager.Instance.Create<SimpleUI>();

            yield return new WaitForSeconds(1.5f);
            ui.text.text = "Hello Developer";

            yield return new WaitForSeconds(1.5f);
            var ui1 = MonoUIManager.Instance.Create<SimpleUI>(true);
            var rect = ui1.transform as RectTransform;
            var anchoredPosition = rect.anchoredPosition;
            anchoredPosition.x = rect.rect.width + 20;
            rect.anchoredPosition = anchoredPosition;

            yield return new WaitForSeconds(1.5f);
            MonoUIManager.Instance.DestroyAll();
        }
    }
}