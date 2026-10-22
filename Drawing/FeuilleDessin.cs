using System.Xml.Linq;

namespace Drawing
{
    public partial class FeuilleDessin : Form
    {
        private List<Node> nodes;
        List<Line> traits;
        private List<Node> selectedNodes = new List<Node>();
        private List<Point> offsets = new List<Point>();
        private bool selecting = false;
        private Rectangle selectionRect;
        private Point selectionStart;
        private Point lastEnd;
        private Node selection;
        private Point point;
        private bool traced;
        private bool moving;
        private bool drawingLines;

        private readonly Stack<GraphAction> actionStack = new(50);
        private readonly Stack<GraphAction> undoneStack = new(50);


        public FeuilleDessin()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            moveModeToolStripButton.CheckOnClick = true;
            nodes = new List<Node>();
            traits = new List<Line>();
        }

        private void FeuilleDessin_Paint(object sender, PaintEventArgs e)
        {
            foreach (Node n in nodes)
            {
                if (!n.Deleted)
                {
                    n.Draw(e.Graphics);
                }
            }
            foreach (Line t in traits)
            {
                if (!t.Deleted)
                {
                    t.Draw(e.Graphics);
                }
            }
            if (traced && selection != null)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, (float)(1 * Settings.Zoom)), Outils.GeometryToScreen(selection.Center), point);
            }
            if (selecting)
            {
                Pen p = new Pen(Color.Black, (int)(1 * Settings.Zoom));
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(p, selectionRect);
            }
        }

        private void FeuilleDessin_MouseDown(object sender, MouseEventArgs e)
        {
            selection = Selected(e.Location);
            if (selection != null)
            {
                selection.Selected = true;
            }
            if (moveModeToolStripButton.Checked)
            {
                traced = false;
                bool ctrl = (ModifierKeys & Keys.Control) == Keys.Control;

                if (selection != null)
                {
                    if (ctrl && selectedNodes.Contains(selection))
                    {
                        selectedNodes.Remove(selection);
                        selection.Selected = false;
                        Refresh();
                        return;
                    }

                    if (!selectedNodes.Contains(selection))
                    {
                        if (!ctrl)
                        {
                            ClearSelection();
                        }
                        selectedNodes.Add(selection);
                    }
                    selection.Selected = true;

                    moving = true;
                    drawingLines = false;
                    selecting = false;
                    lastEnd = e.Location;

                    offsets.Clear();
                    Point mouse = Outils.ScreenToGeometry(e.Location);
                    foreach (Node n in selectedNodes)
                    {
                        offsets.Add(new Point(n.Location.X - mouse.X, n.Location.Y - mouse.Y));
                    }
                }
                else
                {
                    ClearSelection();
                    moving = false;
                    selecting = true;
                    selectionStart = e.Location;
                    selectionRect = new Rectangle(selectionStart, Size.Empty);
                }
                Refresh();
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    traced = true;
                    if (selection == null)
                    {
                        Node noeud = new Node
                        {
                            Location = Outils.ScreenToGeometry(e.Location),
                            Size = Settings.BaseNodeSize,
                            Text = Settings.BaseNodeText,
                            Width = Settings.BaseNodeWidth,
                            Color = Settings.BaseNodeColour
                        };
                        nodes.Add(noeud);
                        undoneStack.Clear();
                        actionStack.Push(new GraphAction { Subject = noeud, Type = GraphActionType.Create });
                        Refresh();
                    }
                    else
                    {
                        drawingLines = true;
                    }
                }
                else if (selection != null)
                {
                    Refresh();
                    GenericSettings nodSet = new GenericSettings(selection);
                    nodSet.ShowDialog();
                    selection.Selected = false;
                    selection = null;
                    Refresh();
                    //code avant partie bonus (suprimer les 5 lignes au dessus aussi) 
                    //NodeSettings nodSet = new NodeSettings(selection.Color, selection.Width, selection.Text);
                    //if (nodSet.ShowDialog() == DialogResult.OK)
                    //{

                    //selection.Color = nodSet.Colour;
                    //selection.Width = nodSet.Width;
                    //selection.Text = nodSet.nodeText;
                    //selection = null;
                    //Refresh();
                    //}
                }
            }
        }

        private void FeuilleDessin_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            if (selecting)
            {
                selectionRect = new Rectangle(
                    Math.Min(selectionStart.X, e.Location.X),
                    Math.Min(selectionStart.Y, e.Location.Y),
                    Math.Abs(e.Location.X - selectionStart.X),
                    Math.Abs(e.Location.Y - selectionStart.Y)
                );

                selectedNodes.Clear();
                foreach (Node n in nodes)
                {
                    if (!n.Deleted)
                    {
                        Rectangle nodeRect = new Rectangle(
                            Outils.GeometryToScreen(n.Location),
                            Outils.GeometryToScreen(n.Size)
                        );
                        if (selectionRect.IntersectsWith(nodeRect))
                        {
                            selectedNodes.Add(n);
                            n.Selected = true;
                        }

                    }
                }
                selecting = false;
                Refresh();
            }
            if (drawingLines)
            {
                Node fin = Selected(e.Location);
                if (fin != null && !fin.Equals(selection))
                {
                    Line trait = new Line
                    {
                        Start = selection,
                        End = fin
                    };
                    traits.Add(trait);
                    actionStack.Push(new GraphAction { Subject = trait, Type = GraphActionType.Create });
                }
                else if (fin == null)
                {
                    //creer noeud si pas de noeud sur la fin du tracage de trait
                    Node noeud = new Node
                    {
                        Location = Outils.ScreenToGeometry(e.Location),
                        Size = Settings.BaseNodeSize,
                        Text = Settings.BaseNodeText,
                        Width = Settings.BaseNodeWidth,
                        Color = Settings.BaseNodeColour
                    };
                    nodes.Add(noeud);
                    undoneStack.Clear();
                    actionStack.Push(new GraphAction { Subject = noeud, Type = GraphActionType.Create });

                    Line trait = new Line
                    {
                        Start = selection,
                        End = noeud
                    };
                    traits.Add(trait);
                    actionStack.Push(new GraphAction { Subject = trait, Type = GraphActionType.Create });
                }
                drawingLines = false;
                traced = false;
                Refresh();
            }
            if (selection != null && !moveModeToolStripButton.Checked)
            {
                selection.Selected = false;
                Refresh();
            }
        }

        private void FeuilleDessin_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                Point mouse = Outils.ScreenToGeometry(e.Location);
                for (int i = 0; i < selectedNodes.Count; i++)
                {
                    selectedNodes[i].Location = new Point(
                        mouse.X + offsets[i].X,
                        mouse.Y + offsets[i].Y
                    );
                }
                Refresh();
            }
            else if (selecting)
            {
                selectionRect = new Rectangle(Math.Min(selectionStart.X, e.Location.X),
                    Math.Min(selectionStart.Y, e.Location.Y),
                    Math.Abs(e.Location.X - selectionStart.X),
                    Math.Abs(e.Location.Y - selectionStart.Y)
                );
                Refresh();
            }
            else if (traced)
            {
                point = e.Location;
                Refresh();
            }
        }

        private Node Selected(Point p)
        {
            Node res = null;
            int i = 0;
            while (res == null && i < nodes.Count)
            {
                if (nodes[i].Contains(p) && !nodes[i].Deleted)
                {
                    res = nodes[i];
                }
                i++;
            }
            return res;
        }

        private void ShrinkToolStripButton_Click(object sender, EventArgs e)
        {
            if (Settings.BaseNodeWidth > 1)
            {
                Settings.BaseNodeWidth--;
            }
        }

        private void GrowToolStripButton_Click(object sender, EventArgs e)
        {
            if (Settings.BaseNodeWidth < 10)
            {
                Settings.BaseNodeWidth++;
            }
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            nodes = new List<Node>();
            traits = new List<Line>();
            Refresh();
        }

        private void ColorToolStripButton_Click(object sender, EventArgs e)
        {
            ColorDialog col = new() { Color = Settings.BaseNodeColour };
            if (col.ShowDialog() == DialogResult.OK)
            {            {
                traced = false;
                bool ctrl = (ModifierKeys & Keys.Control) == Keys.Control;

                if (selection != null)
                {
                    // Ctrl+clic sur un nœud déjà sélectionné : on le retire
                    if (ctrl && selectedNodes.Contains(selection))
                    {
                        selectedNodes.Remove(selection);
                        selection.Selected = false;
                        Refresh();
                        return;
                    }

                    if (!selectedNodes.Contains(selection))
                    {
                        if (!ctrl)
                        {
                            ClearSelection();   // Ctrl : on ajoute à la sélection, sinon on la remplace
                        }
                        selectedNodes.Add(selection);
                    }
                    selection.Selected = true;

                    moving = true;
                    drawingLines = false;
                    selecting = false;
                    lastEnd = e.Location;

                    offsets.Clear();
                    Point mouse = Outils.ScreenToGeometry(e.Location);
                    foreach (Node n in selectedNodes)
                    {
                        offsets.Add(new Point(n.Location.X - mouse.X, n.Location.Y - mouse.Y));
                    }
                }
                else
                {
                    ClearSelection();
                    moving = false;
                    selecting = true;
                    selectionStart = e.Location;
                    selectionRect = new Rectangle(selectionStart, Size.Empty);
                }
                Refresh();
            }
                Settings.BaseNodeColour = col.Color;
            }
        }

        private void VScroll_Scroll(object sender, ScrollEventArgs e)
        {
            Settings.Origin = new(Settings.Origin.X, -e.NewValue);
            Refresh();
        }

        private void HScroll_Scroll(object sender, ScrollEventArgs e)
        {
            Settings.Origin = new(-e.NewValue, Settings.Origin.Y);
            Refresh();
        }

        private void MainWindow_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    Settings.Zoom *= 1.1;
                    if (Settings.Zoom > 15) { Settings.Zoom = 15; }
                }

                if (e.Delta < 0)
                {
                    Settings.Zoom /= 1.1;
                    if (Settings.Zoom < -15) { Settings.Zoom = -15; }
                }
                Refresh();
            }

        }

        private void UndoToolStripButton_Click(object sender, EventArgs e)
        {
            if (actionStack.Count > 0)
            {
                GraphAction action = actionStack.Pop();
                action.Undo();
                undoneStack.Push(action);
                Refresh();
            }
        }

        private void RedoToolStripButton_Click(object sender, EventArgs e)
        {
            if (undoneStack.Count > 0)
            {
                GraphAction action = undoneStack.Pop();
                action.Redo();
                actionStack.Push(action);
                Refresh();
            }
        }

        private void MoveModeToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!moveModeToolStripButton.Checked)
            {
                foreach (Node n in selectedNodes)
                {
                    n.Selected = false;
                }
                selectedNodes.Clear();
                Refresh();
            }
        }

    private void ClearSelection()
    {
        foreach (Node n in selectedNodes)
        {
            n.Selected = false;
        }
        selectedNodes.Clear();
        }
    }

}
