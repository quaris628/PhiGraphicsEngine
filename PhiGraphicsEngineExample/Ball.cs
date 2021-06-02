using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi;

namespace PhiGraphicsEngineExample
{
   class Ball : Renderable
   {
      private Sprite s;
      public Ball()
      {
         s = new Sprite(System.Drawing.Image.FromFile(WindowsForm.FILE_HOME + "res/Ball.png"), 0, 50);
      }

      public ISprite getSprite()
      {
         return s;
      }

      public bool isDisplaying()
      {
         return true;
      }
   }
}
