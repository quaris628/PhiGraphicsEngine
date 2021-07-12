using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.control;

namespace phi
{
   public class PhiConfig : DefaultConfig
   {
      public const string FILE_HOME = "../../";
      public const string RES = FILE_HOME + "res/";

      public struct WINDOW
      {
         public const string TITLE = "phi";
         public const int HEIGHT = 400;
         public const int WIDTH = 600;

      }

      public struct RENDER
      {
         public const string DEFAULT_BACKGROUND = RES + "defaultBackground.png";
         public const int DEFAULT_LAYER = 0;
         public const int FPS = 80;

      }

      // later? make settings loadable from a file
   }
}
