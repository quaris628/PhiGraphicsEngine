using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi
{
   /**
    * Interface that can be implemented by any class that wants to be passed
    *    events to from the Windows Form and take control of the screen output
    * 
    * Input events that get passed are KeyDown and FrameTick
    * Output Sprites and TextOverlay must be .add-ed to the Renderer
    * 
    * @author Nathan Swartz
    */
   public interface IScene
   {
      /**
       * Get the unchanging background image for this scene, upon which the
       * Renderer will draw all sprites of this scene
       */
      Image GetBackgroundImage();

      /**
       * Run each time this scene is switched to, immediately prior to this
       * scene being displayed
       */
      void Initialize();

      /**
       * Run on each keypress
       * (That is, is run exactly once for each time a key is pressed down)
       * @Param key that was pressed
       * @Return Interactable scene to switch to next
       *         'return this' to retain focus on this scene
       *         'return null' to exit application
       */
      IScene OnKeyDownEvent(System.Windows.Forms.KeyEventArgs keyevent);

      /**
       * Run on each MouseEvent
       * (That is, is run exactly once for each time a Mousebutton is pressed down)
       * @Param Mousevent that was created
       * @Return Interactable scene to switch to next
       *         'return this' to retain focus on this scene
       *         'return null' to exit application
       */
       IScene OnMouseEvent(System.Windows.Forms.MouseEventArgs e);

      /**
       * Run on each frame
       * (That is, is run before each Renderer.render() call)
       * @Return Interactable scene to switch to next
       *         'return this' to retain focus on this scene
       *         'return null' to exit application
       */
      IScene OnFrameTickEvent();

   }
}
