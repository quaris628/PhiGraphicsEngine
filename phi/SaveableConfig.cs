using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi
{
   // untested
   public class SaveableConfig : Config
   {
      private const string DEFAULT_SAVE_FILE = HOME_DIR + "phi-config.txt";

      // make only immutable fields const, otherwise static
      
      // I'm not positive which fields should be mutable during runtime and from file load.
      // The current state is my best guess. -Nathan

      public const string HOME_DIR = DefaultConfig.HOME_DIR;
      public const string RES_DIR = DefaultConfig.RES_DIR;
      
      public class Window
      {
         public static string TITLE = "Phi Engine Application";
         private static int _maxWidth = 600;
         public static int MAX_WIDTH
         {
            get => _maxWidth;
            set
            {
               if (value <= 0) { throw new ArgumentException("Negative window width"); }
               _maxWidth = value;
            }
         }
         private static int _maxHeight = 600;
         public static int MAX_HEIGHT
         {
            get => _maxHeight;
            set
            {
               if (value <= 0) { throw new ArgumentException("Negative window height"); }
               _maxHeight = value;
            }
         }
         private static int _initialWidth = 600;
         public static int INITIAL_WIDTH
         {
            get => _initialWidth;
            set
            {
               if (value <= 0) { throw new ArgumentException("Negative window width"); }
               _initialWidth = value;
            }
         }
         private static int _initialHeight = 600;
         public static int INITIAL_HEIGHT
         {
            get => _initialHeight;
            set
            {
               if (value <= 0) { throw new ArgumentException("Negative window height"); }
               _initialHeight = value;
            }
         }
         private static bool _fullscreen = false;
         public static bool IS_FULL_SCREEN
         {
            get => _fullscreen;
            set => _fullscreen = value;
         }
      }

      public class Render
      {
         public static readonly Color DEFAULT_BACKGROUND = Color.White;
         private static int _default_layer = 0;
         public static int DEFAULT_LAYER
         {
            get => _default_layer;
            set
            {
               if (value <= 0) { throw new ArgumentException("Negative layer"); }
               _default_layer = value;
            }
         }
         private static int _fps = 60;
         public static int FPS
         {
            get => _fps;
            set
            {
               if (value <= 0) { throw new ArgumentException("Negative fps"); }
               if (value > 1000) { throw new ArgumentException("fps too large"); }
               _fps = value;
            }
         }
         private static int _tickrate = 60;
         public static int TICK_RATE
         {
            get => _tickrate;
            set
            {
               if (value <= 0) { throw new ArgumentException("TickRate too small"); }
               if (value > 1000) { throw new ArgumentException("TickRate too large"); }
               _tickrate = value;
            }
         }
      }

      // Save
      public void Save() { Save(DEFAULT_SAVE_FILE); }
      public void Save(string path)
      {
         // just throw any exceptions from this
         StreamWriter f = new StreamWriter(path, false, Encoding.UTF8);
         try
         {
            // write values to file
            f.WriteLine(" ----- Phi Config Save File ----- ");
            f.WriteLine("\nWindow");
            f.WriteLine("title:" + Window.TITLE);
            f.WriteLine("width:" + Window.MAX_WIDTH);
            f.WriteLine("height:" + Window.MAX_HEIGHT);
            f.WriteLine("fullscreen:" + Window.IS_FULL_SCREEN);
            f.WriteLine("\nRenderer");
            f.WriteLine("default-layer:" + Render.DEFAULT_LAYER);
            f.WriteLine("fps:" + Render.FPS);
            f.WriteLine("tick-rate:" + Render.TICK_RATE);
         }
         catch (Exception e)
         {
            Console.WriteLine("Exception: " + e.Message);
         }
         finally
         {
            f.Close();
         }
      }

      // Load
      public void Load() { Load(DEFAULT_SAVE_FILE); }
      public void Load(string path)
      {
         // just throw any exceptions from this
         StreamReader f = new StreamReader(path, Encoding.UTF8, true);
         try
         {
            // read strings from file
            f.ReadLine(); //  ----- Phi Config File ----- 
            f.ReadLine(); // 
            f.ReadLine(); // Window
            string titleLine = f.ReadLine(); // title:TITLE
            string widthLine = f.ReadLine(); // width:WIDTH
            string heightLine = f.ReadLine(); // height:HEIGHT
            string fullscreenLine = f.ReadLine(); // fullscreen:FULL_SCREEN
            f.ReadLine(); // Renderer
            string layerLine = f.ReadLine(); // default-layer:DEFAULT_LAYER
            string fpsLine = f.ReadLine(); // fps:FPS
            string tickrateLine = f.ReadLine(); // tick-rate:TICK_RATE

            // parse strings to values
            Window.TITLE = SubstringAfter(titleLine, ':');
            Window.MAX_WIDTH = int.Parse(SubstringAfter(widthLine, ':'));
            Window.MAX_HEIGHT = int.Parse(SubstringAfter(heightLine, ':'));
            Window.IS_FULL_SCREEN = bool.Parse(SubstringAfter(fullscreenLine, ';'));
            Render.DEFAULT_LAYER = int.Parse(SubstringAfter(layerLine, ':'));
            Render.FPS = int.Parse(SubstringAfter(fpsLine, ':'));
            Render.TICK_RATE = int.Parse(SubstringAfter(tickrateLine, ':'));
         }
         catch (Exception e)
         {
            Console.WriteLine("Exception reading file: " + e.Message);
         }
         finally
         {
            f.Close();
         }
      }

      private string SubstringAfter(string str, char delimiter)
      {
         return str.Substring(str.IndexOf(delimiter) + 1);
      }


      public virtual void RestoreDefaults()
      {
         //Restores all Default values from the DefaultConfig
         Window.TITLE = DefaultConfig.Window.TITLE;
         Window.MAX_WIDTH = DefaultConfig.Window.MAX_WIDTH;
         Window.MAX_HEIGHT = DefaultConfig.Window.MAX_HEIGHT;
         Window.IS_FULL_SCREEN = DefaultConfig.Window.IS_FULL_SCREEN;
         Render.DEFAULT_LAYER = DefaultConfig.Render.DEFAULT_LAYER;
         Render.FPS = DefaultConfig.Render.FPS;
         Render.TICK_RATE = DefaultConfig.Render.TICK_RATE;
      }

      public virtual void RestoreDefaultResolution()
      {
         //Restores just the resolution to default
         Window.MAX_WIDTH = DefaultConfig.Window.MAX_WIDTH;
         Window.MAX_HEIGHT = DefaultConfig.Window.MAX_HEIGHT;
      }

      // Implement Config interface
      public virtual string GetHomeDir() { return HOME_DIR; }
      public virtual string GetResourcesDir() { return RES_DIR; }
      public virtual string GetWindowTitle() { return Window.TITLE; }
      public virtual string GetWindowIcon() { return ""; } // TODO
      public virtual int GetMaxWindowWidth() { return Window.MAX_WIDTH; }
      public virtual int GetMaxWindowHeight() { return Window.MAX_HEIGHT; }

      public virtual int GetInitialWindowWidth() { return Window.INITIAL_WIDTH; }
      public virtual int GetInitialWindowHeight() { return Window.INITIAL_HEIGHT; }
      public virtual bool IsFullScreen() { return Window.IS_FULL_SCREEN; }
      public virtual Color GetRenderDefaultBackground() { return Render.DEFAULT_BACKGROUND; }
      public virtual int GetRenderDefaultLayer() { return Render.DEFAULT_LAYER; }
      public virtual int GetRenderFPS() { return Render.FPS; }
      public virtual int GetTickRate() { return Render.TICK_RATE; }

   }
}
