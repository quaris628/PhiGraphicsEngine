using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.control;

namespace phi
{
   public class DefaultConfig
   {
      protected const string HOME_DIR = "../../";
      protected const string RES_DIR = HOME_DIR + "res/";

      public virtual string GetHomeDir() { return HOME_DIR; }
      public virtual string GetResourcesDir() { return RES_DIR; }

      public class Window
      {
         protected const string TITLE = "phi";
         protected const int WIDTH = 600;
         protected const int HEIGHT = 400;
         
         public virtual string GetTitle() { return TITLE; }
         public virtual int GetWidth() { return WIDTH; }
         public virtual int GetHeight() { return HEIGHT; }
         
      }

      public class Render
      {
         protected const string DEFAULT_BACKGROUND = RES_DIR + "defaultBackground.png";
         protected const int DEFAULT_LAYER = 0;
         protected const int FPS = 60;

         public virtual string GetDefaultBackground() { return DEFAULT_BACKGROUND; }
         public virtual int GetDefaultLayer() { return DEFAULT_LAYER; }
         public virtual int GetFPS() { return FPS; }
      }

      private Window window = new Window();
      private Render render = new Render();

      public virtual Window GetWindow() { return window; }
      public virtual Render GetRender() { return render; }

   }
}
