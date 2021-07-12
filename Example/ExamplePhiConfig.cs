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
      public new const string HOME_DIR = DefaultConfig.HOME_DIR;
      public new const string RES_DIR = DefaultConfig.RES_DIR;

      public override string GetHomeDir() { return HOME_DIR; }
      public override string GetResourcesDir() { return RES_DIR; }

      public new class Window : DefaultConfig.Window
      {
         public new const string TITLE = DefaultConfig.Window.TITLE;
         public new const int WIDTH = 400;
         public new const int HEIGHT = DefaultConfig.Window.HEIGHT;

         public override string GetTitle() { return TITLE; }
         public override int GetWidth() { return WIDTH; }
         public override int GetHeight() { return HEIGHT; }
      }

      public new class Render : DefaultConfig.Render
      {
         public new const string DEFAULT_BACKGROUND = DefaultConfig.Render.DEFAULT_BACKGROUND;
         public new const int DEFAULT_LAYER = DefaultConfig.Render.DEFAULT_LAYER;
         public new const int FPS = DefaultConfig.Render.FPS;

         public override string GetDefaultBackground() { return DEFAULT_BACKGROUND; }
         public override int GetDefaultLayer() { return DEFAULT_LAYER; }
         public override int GetFPS() { return FPS; }
      }

      public Window window = new Window();
      public Render render = new Render();

      public override DefaultConfig.Window GetWindow() { return window; }
      
      public override DefaultConfig.Render GetRender() { return render; }
   }
}
