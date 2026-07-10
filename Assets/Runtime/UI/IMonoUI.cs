/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMonoUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/04/2026
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.MonoUI
{
    public interface IMonoUI
    {
        void Show();

        void Focus();

        void Close();
    }

    public interface IMonoUI<T> : IMonoUI
    {
        void Refresh(T data);
    }
}