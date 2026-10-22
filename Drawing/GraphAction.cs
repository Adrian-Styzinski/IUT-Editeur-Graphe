using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    public enum GraphActionType { Create, Delete, Move, Change }
    internal class GraphAction
    {
        public GraphActionType Type { get; set; }

        public IDeletable? Subject { get; set; }

        public void Undo()
        {
            if (Subject == null) return;
            switch (Type)
            {
                case GraphActionType.Create:
                    Subject.Deleted = true;
                    break;
                case GraphActionType.Delete:
                    Subject.Deleted = false;
                    break;
            }
        }

        public void Redo()
        {
            if (Subject == null) return;
            switch (Type)
            {
                case GraphActionType.Create:
                    Subject.Deleted = false;
                    break;
                case GraphActionType.Delete:
                    Subject.Deleted = true;
                    break;
            }
        }
    }
}
