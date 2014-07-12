using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// The source for this block of code to selectively hide treeview checkboxes is:
// http://stackoverflow.com/questions/4826556/treeview-remove-checkbox-by-some-nodes
// Programmer identified only by user name, Cody Gray
// Modified into extension method on the same web page by programmer only 
// identified by user name of user1404096.

namespace Excel_2010_Measure_Reader
{
    public static class DirectoryTreeViewExtensions
    {
        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd,
            int Msg,
            IntPtr wParam,
            ref TVITEM lParam);

        /// <summary>
        ///     Hides the checkbox for the specified node on a TreeView control.
        /// </summary>
        public static void HideCheckBox(this TreeNode node)
        {
            var tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            SendMessage(node.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }

        public static bool HasChildren(this TreeNode node)
        {
            return node.Nodes.Count > 0;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)] public readonly string lpszText;
            public readonly int cchTextMax;
            public readonly int iImage;
            public readonly int iSelectedImage;
            public readonly int cChildren;
            public readonly IntPtr lParam;
        }
    }
}