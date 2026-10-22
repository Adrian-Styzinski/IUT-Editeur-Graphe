namespace Drawing
{
    partial class FeuilleDessin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeuilleDessin));
            toolStrip1 = new ToolStrip();
            moveModeToolStripButton = new ToolStripButton();
            shrinkToolStripButton = new ToolStripButton();
            growToolStripButton = new ToolStripButton();
            deleteToolStripButton = new ToolStripButton();
            colorToolStripButton = new ToolStripButton();
            undoToolStripButton = new ToolStripButton();
            redoToolStripButton = new ToolStripButton();
            vScroll = new VScrollBar();
            hScroll = new HScrollBar();
            mainMenuStrip = new MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { moveModeToolStripButton, shrinkToolStripButton, growToolStripButton, deleteToolStripButton, colorToolStripButton, undoToolStripButton, redoToolStripButton });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 38);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // moveModeToolStripButton
            // 
            moveModeToolStripButton.Image = (Image)resources.GetObject("moveModeToolStripButton.Image");
            moveModeToolStripButton.ImageTransparentColor = Color.Magenta;
            moveModeToolStripButton.Name = "moveModeToolStripButton";
            moveModeToolStripButton.Size = new Size(75, 35);
            moveModeToolStripButton.Text = "Move Mode";
            moveModeToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            moveModeToolStripButton.CheckedChanged += MoveModeToolStripButton_CheckedChanged;
            // 
            // shrinkToolStripButton
            // 
            shrinkToolStripButton.Image = (Image)resources.GetObject("shrinkToolStripButton.Image");
            shrinkToolStripButton.ImageTransparentColor = Color.Magenta;
            shrinkToolStripButton.Name = "shrinkToolStripButton";
            shrinkToolStripButton.Size = new Size(23, 35);
            shrinkToolStripButton.Text = "-";
            shrinkToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            shrinkToolStripButton.ToolTipText = "Shrink Tool";
            shrinkToolStripButton.Click += ShrinkToolStripButton_Click;
            // 
            // growToolStripButton
            // 
            growToolStripButton.Image = (Image)resources.GetObject("growToolStripButton.Image");
            growToolStripButton.ImageTransparentColor = Color.Magenta;
            growToolStripButton.Name = "growToolStripButton";
            growToolStripButton.Size = new Size(23, 35);
            growToolStripButton.Text = "+";
            growToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            growToolStripButton.ToolTipText = "Zoom Tool";
            growToolStripButton.Click += GrowToolStripButton_Click;
            // 
            // deleteToolStripButton
            // 
            deleteToolStripButton.Image = (Image)resources.GetObject("deleteToolStripButton.Image");
            deleteToolStripButton.ImageTransparentColor = Color.Magenta;
            deleteToolStripButton.Name = "deleteToolStripButton";
            deleteToolStripButton.Size = new Size(53, 35);
            deleteToolStripButton.Text = "Erase all";
            deleteToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            deleteToolStripButton.Click += DeleteToolStripButton_Click;
            // 
            // colorToolStripButton
            // 
            colorToolStripButton.Image = (Image)resources.GetObject("colorToolStripButton.Image");
            colorToolStripButton.ImageTransparentColor = Color.Magenta;
            colorToolStripButton.Name = "colorToolStripButton";
            colorToolStripButton.Size = new Size(40, 35);
            colorToolStripButton.Text = "Color";
            colorToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            colorToolStripButton.Click += ColorToolStripButton_Click;
            // 
            // undoToolStripButton
            // 
            undoToolStripButton.Image = (Image)resources.GetObject("undoToolStripButton.Image");
            undoToolStripButton.ImageTransparentColor = Color.Magenta;
            undoToolStripButton.Name = "undoToolStripButton";
            undoToolStripButton.Size = new Size(40, 35);
            undoToolStripButton.Text = "Undo";
            undoToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            undoToolStripButton.ToolTipText = "undoToolStripButton";
            undoToolStripButton.Click += UndoToolStripButton_Click;
            // 
            // redoToolStripButton
            // 
            redoToolStripButton.Image = (Image)resources.GetObject("redoToolStripButton.Image");
            redoToolStripButton.ImageTransparentColor = Color.Magenta;
            redoToolStripButton.Name = "redoToolStripButton";
            redoToolStripButton.Size = new Size(38, 35);
            redoToolStripButton.Text = "Redo";
            redoToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            redoToolStripButton.ToolTipText = "redoToolStripButton";
            redoToolStripButton.Click += RedoToolStripButton_Click;
            // 
            // vScroll
            // 
            vScroll.Dock = DockStyle.Right;
            vScroll.LargeChange = 50;
            vScroll.Location = new Point(773, 62);
            vScroll.Maximum = 800;
            vScroll.Name = "vScroll";
            vScroll.Size = new Size(27, 388);
            vScroll.SmallChange = 4;
            vScroll.TabIndex = 1;
            vScroll.Scroll += VScroll_Scroll;
            // 
            // hScroll
            // 
            hScroll.Dock = DockStyle.Bottom;
            hScroll.LargeChange = 50;
            hScroll.Location = new Point(0, 421);
            hScroll.Maximum = 800;
            hScroll.Name = "hScroll";
            hScroll.Size = new Size(773, 29);
            hScroll.SmallChange = 4;
            hScroll.TabIndex = 2;
            hScroll.Scroll += HScroll_Scroll;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(800, 24);
            mainMenuStrip.TabIndex = 3;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(144, 22);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += UndoToolStripButton_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(144, 22);
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += RedoToolStripButton_Click;
            // 
            // FeuilleDessin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(hScroll);
            Controls.Add(vScroll);
            Controls.Add(toolStrip1);
            Controls.Add(mainMenuStrip);
            MainMenuStrip = mainMenuStrip;
            Name = "FeuilleDessin";
            Text = "Main Window";
            Paint += FeuilleDessin_Paint;
            MouseDown += FeuilleDessin_MouseDown;
            MouseMove += FeuilleDessin_MouseMove;
            MouseUp += FeuilleDessin_MouseUp;
            MouseWheel += MainWindow_MouseWheel;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton moveModeToolStripButton;
        private ToolStripButton shrinkToolStripButton;
        private ToolStripButton growToolStripButton;
        private ToolStripButton deleteToolStripButton;
        private ToolStripButton colorToolStripButton;
        private VScrollBar vScroll;
        private HScrollBar hScroll;
        private ToolStripButton undoToolStripButton;
        private ToolStripButton redoToolStripButton;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
    }
}
