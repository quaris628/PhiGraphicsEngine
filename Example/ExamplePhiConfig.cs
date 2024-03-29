﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi;

namespace Example
{
   // pass this object to the PhiMain method to set it to be used as the phi config settings
   public class ExamplePhiConfig : DefaultConfig
   {
      public new class Window : DefaultConfig.Window
      {
         public new const int WIDTH = 1200;
         public new const int HEIGHT = 700;
      }
      public new class Render : DefaultConfig.Render
      {
         public new const int FPS = 30;
      }

      public override int GetInitialWindowWidth() { return Window.WIDTH; }
      public override int GetInitialWindowHeight() { return Window.HEIGHT; }
      public override int GetRenderFPS() { return Render.FPS; }
   }
}
