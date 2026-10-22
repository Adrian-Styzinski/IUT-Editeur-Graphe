using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    public partial class NodeSettings : Form
    {
        public NodeSettings(Color c, int w, String t)
        {
            InitializeComponent();
            colourValueLabel.BackColor = c;
            widthValueNumericUpDown.Value = w;
            textRichTextBox.Text = t;
        }

        private void NodeSettings_Load(object sender, EventArgs e)
        {

        }

        private void ColourValueLabel_Click(object sender, EventArgs e)
        {
            ColorDialog col = new() { Color = colourValueLabel.BackColor };
            if (col.ShowDialog() == DialogResult.OK)
            {
                colourValueLabel.BackColor = col.Color;
            }
        }

        public Color Colour => colourValueLabel.BackColor;
        public new int Width => (int)widthValueNumericUpDown.Value;
        public new string nodeText => (string)textRichTextBox.Text;
    }
}
