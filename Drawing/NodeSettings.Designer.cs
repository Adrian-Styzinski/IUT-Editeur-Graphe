namespace Drawing
{
    partial class NodeSettings
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
            widthValueNumericUpDown = new NumericUpDown();
            colourValueLabel = new Label();
            button1 = new Button();
            button2 = new Button();
            widthTitleLabel = new Label();
            colorTitleLabel = new Label();
            textRichTextBox = new RichTextBox();
            textTitleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)widthValueNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // widthValueNumericUpDown
            // 
            widthValueNumericUpDown.Location = new Point(64, 33);
            widthValueNumericUpDown.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            widthValueNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            widthValueNumericUpDown.Name = "widthValueNumericUpDown";
            widthValueNumericUpDown.Size = new Size(80, 23);
            widthValueNumericUpDown.TabIndex = 0;
            widthValueNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // colourValueLabel
            // 
            colourValueLabel.AutoSize = true;
            colourValueLabel.BackColor = Color.Red;
            colourValueLabel.Location = new Point(64, 85);
            colourValueLabel.MinimumSize = new Size(30, 15);
            colourValueLabel.Name = "colourValueLabel";
            colourValueLabel.Size = new Size(30, 15);
            colourValueLabel.TabIndex = 1;
            colourValueLabel.Click += ColourValueLabel_Click;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(307, 61);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(307, 104);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // widthTitleLabel
            // 
            widthTitleLabel.AutoSize = true;
            widthTitleLabel.Location = new Point(12, 35);
            widthTitleLabel.Name = "widthTitleLabel";
            widthTitleLabel.Size = new Size(39, 15);
            widthTitleLabel.TabIndex = 4;
            widthTitleLabel.Text = "Width";
            // 
            // colorTitleLabel
            // 
            colorTitleLabel.AutoSize = true;
            colorTitleLabel.Location = new Point(12, 85);
            colorTitleLabel.Name = "colorTitleLabel";
            colorTitleLabel.Size = new Size(36, 15);
            colorTitleLabel.TabIndex = 5;
            colorTitleLabel.Text = "Color";
            // 
            // textRichTextBox
            // 
            textRichTextBox.Location = new Point(64, 130);
            textRichTextBox.Name = "textRichTextBox";
            textRichTextBox.Size = new Size(93, 24);
            textRichTextBox.TabIndex = 6;
            textRichTextBox.Text = "";
            // 
            // textTitleLabel
            // 
            textTitleLabel.AutoSize = true;
            textTitleLabel.Location = new Point(12, 133);
            textTitleLabel.Name = "textTitleLabel";
            textTitleLabel.Size = new Size(28, 15);
            textTitleLabel.TabIndex = 7;
            textTitleLabel.Text = "Text";
            // 
            // NodeSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 180);
            Controls.Add(textTitleLabel);
            Controls.Add(textRichTextBox);
            Controls.Add(colorTitleLabel);
            Controls.Add(widthTitleLabel);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(colourValueLabel);
            Controls.Add(widthValueNumericUpDown);
            Name = "NodeSettings";
            Text = "NodeSettings";
            Load += NodeSettings_Load;
            ((System.ComponentModel.ISupportInitialize)widthValueNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown widthValueNumericUpDown;
        private Label colourValueLabel;
        private Button button1;
        private Button button2;
        private Label widthTitleLabel;
        private Label colorTitleLabel;
        private RichTextBox textRichTextBox;
        private Label textTitleLabel;
    }
}