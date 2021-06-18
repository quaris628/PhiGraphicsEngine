using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhiGraphicsEngineExample.phi.PhiPhysics
{
   interface PhysicsObject
   {
      float getMass();
      Vector getVelocity();

      void update();
   }
}
