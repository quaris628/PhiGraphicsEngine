using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;


namespace phi.phisics
{
   public class PhisicsPlane
   {

      private HashSet<PhisicsObject> hardObjs; //Hard Objects collide with all colidables
      private HashSet<PhisicsObject> softObjs; //Soft Objects only collide with Hard Objects
      private HashSet<PhisicsObject> nonObjs; //Non-Objects have no collison with anything

      /**
       * Constructs a rectangularly bounded phisics plane
       */
      public PhisicsPlane(int originX, int originY, int width, int height)
      {

      }

      public bool AddHardCollidable(PhisicsObject o)
      {
         return hardObjs.Add(o);
      }

      public bool RemoveHardCollidable(PhisicsObject o)
      {
         return hardObjs.Remove(o);
      }

      public void updateObjects(int tickSpeed)
      {
         foreach(PhisicsObject o in hardObjs)
         {
            o.update(tickSpeed);
         }
      }

   }
}
