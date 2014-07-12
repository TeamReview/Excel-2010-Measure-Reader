namespace Excel_2010_Measure_Reader
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.readButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pgSelect = new System.Windows.Forms.TabPage();
            this.directoryTree = new Excel_2010_Measure_Reader.ExcelTreeView();
            this.pgResults = new System.Windows.Forms.TabPage();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveResultsButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.pgSelect.SuspendLayout();
            this.pgResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // readButton
            // 
            this.readButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.readButton.AutoSize = true;
            this.readButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.readButton.Location = new System.Drawing.Point(13, 519);
            this.readButton.Margin = new System.Windows.Forms.Padding(4);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(120, 29);
            this.readButton.TabIndex = 2;
            this.readButton.Text = "&Read Measures";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.AutoSize = true;
            this.closeButton.Location = new System.Drawing.Point(716, 519);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(55, 29);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.pgSelect);
            this.tabControl.Controls.Add(this.pgResults);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(767, 500);
            this.tabControl.TabIndex = 4;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // pgSelect
            // 
            this.pgSelect.Controls.Add(this.directoryTree);
            this.pgSelect.Location = new System.Drawing.Point(4, 26);
            this.pgSelect.Name = "pgSelect";
            this.pgSelect.Padding = new System.Windows.Forms.Padding(3);
            this.pgSelect.Size = new System.Drawing.Size(759, 470);
            this.pgSelect.TabIndex = 0;
            this.pgSelect.Text = "Select Files";
            this.pgSelect.UseVisualStyleBackColor = true;
            // 
            // directoryTree
            // 
            this.directoryTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.directoryTree.CheckBoxes = true;
            this.directoryTree.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.directoryTree.ImageIndex = 0;
            this.directoryTree.Location = new System.Drawing.Point(0, 0);
            this.directoryTree.Margin = new System.Windows.Forms.Padding(4);
            this.directoryTree.Name = "directoryTree";
            this.directoryTree.SelectedImageIndex = 0;
            this.directoryTree.Size = new System.Drawing.Size(757, 458);
            this.directoryTree.TabIndex = 1;
            // 
            // pgResults
            // 
            this.pgResults.Controls.Add(this.txtResults);
            this.pgResults.Location = new System.Drawing.Point(4, 26);
            this.pgResults.Name = "pgResults";
            this.pgResults.Padding = new System.Windows.Forms.Padding(3);
            this.pgResults.Size = new System.Drawing.Size(759, 470);
            this.pgResults.TabIndex = 1;
            this.pgResults.Text = "Results";
            this.pgResults.UseVisualStyleBackColor = true;
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResults.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtResults.Location = new System.Drawing.Point(0, 0);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(757, 465);
            this.txtResults.TabIndex = 0;
            this.txtResults.WordWrap = false;
            // 
            // saveResultsButton
            // 
            this.saveResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveResultsButton.AutoSize = true;
            this.saveResultsButton.Enabled = false;
            this.saveResultsButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.saveResultsButton.Location = new System.Drawing.Point(305, 519);
            this.saveResultsButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveResultsButton.Name = "saveResultsButton";
            this.saveResultsButton.Size = new System.Drawing.Size(146, 29);
            this.saveResultsButton.TabIndex = 5;
            this.saveResultsButton.Text = "&Save Results to File";
            this.saveResultsButton.UseVisualStyleBackColor = true;
            this.saveResultsButton.Click += new System.EventHandler(this.saveResultsButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.saveResultsButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Excel 2010 Measure Reader";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl.ResumeLayout(false);
            this.pgSelect.ResumeLayout(false);
            this.pgResults.ResumeLayout(false);
            this.pgResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Excel_2010_Measure_Reader.ExcelTreeView directoryTree;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pgSelect;
        private System.Windows.Forms.TabPage pgResults;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveResultsButton;
    }
}

