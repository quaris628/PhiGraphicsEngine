using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi;
using phi.graphics;
using phi.io;

namespace PhiExample
{
   class Ball : Renderable
   {
      private const string IMAGE = Config.RES + "Ball.png";

      private Sprite s;

      public Ball()
      {
         s = new Sprite(new ImageWrapper(IMAGE), 0, 50);
      }

      public Drawable GetDrawable()
      {
         return s;
      }

   }
}
