using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Excel_2010_Measure_Reader
{
    public partial class ExcelTreeView : TreeView
    {
        public ExcelTreeView()
        {
            InitializeComponent();
        }

        public void ReadDrives()
        {
            var driveNodes = Environment.GetLogicalDrives()
                .OrderBy(drive => drive)
                .Select(drive => (new TreeNode {Text = drive, Tag = drive}));

            foreach (TreeNode driveNode in driveNodes)
            {
                driveNode.ImageIndex = 0;
                driveNode.SelectedImageIndex = 0;
                
                driveNode.Nodes.Add(new TreeNode {Text = @".", Tag = @"."});
                Nodes.Add(driveNode);
                driveNode.HideCheckBox();
            }

            BeforeExpand += ExcelFileTreeView_BeforeExpand;
        }

        private void ExcelFileTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode currentNode = e.Node;

            if (currentNode.Nodes.Count == 1 && currentNode.Nodes[0].Text == @".")
            {
                currentNode.Nodes.Clear();

                try
                {
                    IEnumerable<TreeNode> subDirectories = Directory.EnumerateDirectories(currentNode.Tag.ToString())
                        .OrderBy(directory => directory)
                        .Select(directory => new TreeNode {Text = Path.GetFileName(directory ?? ""), Tag = directory});

                    foreach (TreeNode subDirectory in subDirectories)
                    {
                        subDirectory.ImageIndex = 1;
                        subDirectory.SelectedImageIndex = 1;
                        subDirectory.Nodes.Add(new TreeNode {Text = @".", Tag = @"."});
                        currentNode.Nodes.Add(subDirectory);
                        //subDirectory.HideCheckBox();
                    }

                    IEnumerable<TreeNode> files = Directory.EnumerateFiles(currentNode.Tag.ToString(), "*.xls?")
                        .OrderBy(file => file)
                        .Select(file => new TreeNode {Text = Path.GetFileName(file ?? ""), Tag = file});

                    foreach (TreeNode file in files)
                    {
                        file.ImageIndex = 2;
                        file.SelectedImageIndex = 2;
                        currentNode.Nodes.Add(file);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // Do not want to drill into unauthoried directories
                }
            }
        }

        public List<string> GetFilePaths()
        {
            return ReadNodes(Nodes, new List<string>());
        }


        private List<string> ReadNodes(TreeNodeCollection nodes, List<string> fileNames)
        {
            IOrderedEnumerable<TreeNode> treeNodes = nodes.OfType<TreeNode>().OrderBy(node => node.Tag.ToString());

            foreach (TreeNode node in treeNodes)
            {
                if (node.Nodes.Count > 0)
                {
                    ReadNodes(node.Nodes, fileNames);
                }
                else if (node.Checked)
                {
                    fileNames.Add(node.Tag.ToString());
                }
            }
            return fileNames;
        }

        private void ExcelTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var imageIndex = e.Node.IsSelected ? e.Node.SelectedImageIndex : e.Node.ImageIndex;
            var nodesChecked = 0;

            if (imageIndex == 1) // && IsDirectory
            {
                e.Node.Expand();

                if (e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode node in e.Node.Nodes)
                    {
                        if (node.ImageIndex == 2) // IsFile
                        {
                            node.Checked = e.Node.Checked;
                            nodesChecked++;
                        }
                    }

                    if (nodesChecked == 0)
                    {
                        e.Node.Checked = false;
                    }
                }
            } else if (imageIndex == 2 && !e.Node.Checked)
            {
                e.Node.Parent.Checked = false;
            }
        }
    }
}