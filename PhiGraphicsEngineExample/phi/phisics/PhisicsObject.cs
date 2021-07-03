using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;

namespace phi.phisics
{
   public abstract class PhisicsObject : Drawable
   {
      private PhisicsPlane plane;

      protected PhisicsObject(PhisicsPlane plane, double mass, Shape shape, Vector position, Vector velocity)
         : base(plane.GetX(), plane.GetY(), shape.GetWidth(), shape.GetHeight())
      {

      }

      
      public abstract double getMass();
      public abstract Vector getVelocity();
      public abstract Vector getPosition();
      public abstract Shape getShape();

      //this was originally used for testing purposes, it adds the velocity to it's position, basically used for the tick event.
      public abstract void update(); // ?  not set position, set velocity, ... ? - Nathan 
       
   }
}
