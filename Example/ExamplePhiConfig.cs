using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi;

namespace Example
{
   public class ExamplePhiConfig : DefaultConfig
   {
      public new class Window : DefaultConfig.Window
      {
         public new const int WIDTH = 400;
      }

      public override int GetWindowWidth() { return Window.WIDTH; }
   }
}
