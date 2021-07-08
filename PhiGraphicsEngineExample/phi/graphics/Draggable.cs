using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.control.input;
using phi.control;

namespace phi.graphics
{
   public class Draggable : Renderable
   {
      private Drawable drawable;
      private int dragOffsetX;
      private int dragOffsetY;

      public Draggable(Drawable drawable)
      {
         this.drawable = drawable;
      }

      public void Initialize()
      {
         // TODO Make this (int, int) location overload in MouseINputHandler
         //IO.MOUSE.DOWN.SubscribeOnDrawable(MouseDown, drawable);
      }

      private void MouseDown(int x, int y)
      {
         // TODO Make this (int, int) location overload in MouseINputHandler
         //IO.MOUSE.MOVE.Subscribe(MouseMove);
         IO.MOUSE.UP.Subscribe(MouseUp);
         dragOffsetX = x - drawable.GetX();
         dragOffsetY = y - drawable.GetY();
         MyMouseDown(x, y);
      }
      protected virtual void MyMouseDown(int x, int y) { }

      private void MouseUp()
      {
         // TODO Make this (int, int) location overload in MouseINputHandler
         //IO.MOUSE.MOVE.Unsubscribe(MouseMove);
         IO.MOUSE.UP.Unsubscribe(MouseUp);
         MyMouseUp();
      }
      protected virtual void MyMouseUp() { }

      private void MouseMove(int x, int y)
      {
         drawable.SetXY(x - dragOffsetX, y = dragOffsetY);
         MyMouseMove(x, y);
      }
      protected virtual void MyMouseMove(int x, int y) { }

      public Drawable GetDrawable() { return drawable; }
   }
}
