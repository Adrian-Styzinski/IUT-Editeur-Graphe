using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    internal interface IDeletable
    {
        bool Deleted { get; set; }
    }
}
