using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    public partial class GenericSettings : Form
    {
        private object subject;
        public GenericSettings(object obj)
        {
            this.Text = "Settings";
            subject = obj;
            PropertyInfo[] properties = subject.GetType().GetProperties();
            int x = 10, y = 10;

            foreach (PropertyInfo p in properties)
            {
                if (p.SetMethod != null)
                {
                    Control ctrl;

                    switch (p.PropertyType.Name)
                    {
                        case "Int32":
                            ctrl = new NumericUpDown();
                            ctrl.Width = 50;
                            (ctrl as NumericUpDown).Maximum = 20;
                            (ctrl as NumericUpDown).Minimum = 1;
                            ctrl.Text = p.GetValue(subject).ToString();
                            break;
                        case "String":
                            ctrl = new TextBox();
                            ctrl.Text = p.GetValue(subject).ToString();
                            break;
                        case "Color":
                            ctrl = new Label();
                            ctrl.MinimumSize = new Size(30, 15);
                            ctrl.Text = string.Empty;
                            ctrl.BackColor = (Color)p.GetValue(subject);
                            ctrl.Click += Colour_Click;
                            break;
                        case "FontFamily":
                            ComboBox cb = new ComboBox();
                            cb.MinimumSize = new Size(120, 15);
                            //utilisation de comboBox car sinon trops de dialogs...
                            foreach (FontFamily ff in FontFamily.Families)
                            { 
                                cb.Items.Add(ff.Name);
                            }
                            cb.SelectedItem = ((FontFamily)p.GetValue(subject)).Name;
                            ctrl = cb;
                            break;
                        default:
                            continue;
                    }

                    // Label
                    Label lb = new Label();
                    lb.Text = p.Name;
                    lb.Location = new Point(x, y);
                    Controls.Add(lb);

                    ctrl.Location = new Point(x + lb.Width + 5, y);
                    ctrl.Tag = p;
                    Controls.Add(ctrl);

                    y += 30;
                
            }
        }

            Button okButton = new Button();
            okButton.Text = "OK";
            Controls.Add(okButton);
            okButton.Location = new Point(x, y);
            okButton.Click += Ok_Button_Click;
            x += okButton.Width + 20;

            Button nokButton = new Button();
            nokButton.Text = "Annuler";
            Controls.Add(nokButton);
            nokButton.Location = new Point(x, y);
            nokButton.Click += Nok_Button_Click;
            x += okButton.Width + 20;
        }
        

        private void Colour_Click(object? sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                ColorDialog cd = new ColorDialog() { Color = lbl.BackColor };
                if (cd.ShowDialog() == DialogResult.OK)
                    lbl.BackColor = cd.Color;
            }
        }

        private void Ok_Button_Click(object? sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
            if (c.Tag != null && c.Tag is PropertyInfo p)
                {
                    switch (p.PropertyType.Name)
                    {
                        case "String":
                            p.SetValue(subject, c.Text);
                            break;
                        case "Int32":
                            int val;
                            if (int.TryParse(c.Text, out val))
                                p.SetValue(subject, val);
                            break;
                        case "Color":
                            p.SetValue(subject, c.BackColor);
                            break;
                        case "FontFamily":
                            p.SetValue(subject, new FontFamily((string)((ComboBox)c).SelectedItem));
                            break;
                    }
                }
            }
            Close();
        }

        private void Nok_Button_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}