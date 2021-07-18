using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.graphics.drawables
{
   public abstract class PenDrawable : Drawable
   {
      private static readonly Color DEFAULT_COLOR = Color.Black;

      private Pen pen;

      public PenDrawable(int posX, int posY, int width, int height)
         : base(posX, posY, width, height)
      {
         pen = new Pen(DEFAULT_COLOR);
      }

      public virtual void SetPen(Pen pen) { this.pen = pen; FlagChange(); }
      protected virtual Pen GetPen() { return pen; }
   }
}
