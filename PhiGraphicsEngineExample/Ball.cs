using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi;
using phi.graphics;
using phi.other;

namespace PhiGraphicsEngineExample
{
   class Ball : Renderable
   {
      private const string IMAGE = Config.FILE_HOME + "res/Ball.png";

      private Sprite s;

      public Ball()
      {
         s = new Sprite(System.Drawing.Image.FromFile(IMAGE), 0, 50);
      }

      public Drawable GetDrawable()
      {
         return s;
      }

   }
}
