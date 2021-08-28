using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics.drawables;

namespace Example
{
   class ColorChangingSquare : RectangleDrawable
   {
      Random r;

      public ColorChangingSquare(int x, int y, int size) : base(x, y, size, size)
      {
         r = new Random();
         ChangeColorRandomly();
      }

      public ColorChangingSquare(int randSeed, int x, int y, int size) : base(x, y, size, size)
      {
         r = new Random(randSeed);
      }

      public void ChangeColorRandomly()
      {
         int argb = r.Next() % 0x01000000 + 0x7F000000;
         base.SetColor(Color.FromArgb(argb));
      }
   }
}
