using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.control.input;
using phi.graphics;

namespace phi.control
{
   public class IO
   {
      public static readonly FrameTimerInputHandler FRAME_TIMER = new FrameTimerInputHandler();
      public static readonly KeyInputHandler KEYS = new KeyInputHandler();
      public static readonly MouseInputHandler MOUSE = new MouseInputHandler();
      public static readonly Renderer RENDERER = new Renderer(null);

      private IO() { }

      public static void Clear()
      {
         FRAME_TIMER.Clear();
         KEYS.Clear();
         // todo
         //MOUSE.Clear();
         RENDERER.Clear();
      }

      public static void Exit() { WindowsForm.Exit(); }
   }
}
