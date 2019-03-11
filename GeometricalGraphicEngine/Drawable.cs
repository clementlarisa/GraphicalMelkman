using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeometricalGraphicEngine
{
    [Serializable]
    abstract class Drawable
    {
        public Color Color { get; set; }
        public abstract void Draw(Graphics graphics);
    }
}
