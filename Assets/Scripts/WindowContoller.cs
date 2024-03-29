using UnityEngine;
using System.Collections;

using System;
using System.Runtime.InteropServices;

namespace Utils
{


    public class WindowContoller : MonoBehaviour
    {

        private string windowName = "windowname";
        private int x = 0;
        private int y = 0;
        private int width = 1920;
        private int height = 1080;
        private bool hideTitleBar = true;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(System.String className, System.String windowName);

        // Sets window attributes
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        // Gets window attributes
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        // assorted constants needed
        public static int GWL_STYLE = -16;
        public static int WS_CHILD = 0x40000000; //child window
        public static int WS_BORDER = 0x00800000; //window with border
        public static int WS_DLGFRAME = 0x00400000; //window with double border but no title
        public static int WS_CAPTION = WS_BORDER | WS_DLGFRAME; //window with a title bar

        void Awake()
        {
            var window = FindWindow(null, windowName);
            if (hideTitleBar)
            {
                int style = GetWindowLong(window, GWL_STYLE);
                SetWindowLong(window, GWL_STYLE, (style & ~WS_CAPTION));
            }
            SetWindowPos(window, 0, x, y, width, height, width * height == 0 ? 1 : 0);
        }
    }
}