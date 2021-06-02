using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi
{
   /**
    * Renderable interface implemented on objects that need to have a sprite rendered
    * @author Benjamin Lippincott (and Nathan Swartz)
    */
   public interface Renderable
   {
      /**
       * Get the sprite (image, x, and y) to display
       */
      ISprite getSprite();

      /**
       * Whether to display the sprite in the render or not
       */
      bool isDisplaying();
   }
}
