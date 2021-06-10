using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.graphics
{
   /**
    * Scene, to be passed control events to from the Windows Form
    *    and to set objects being displayed in the renderer
    * Input events that get passed are KeyDown and FrameTick
    * Output Drawables must be .add-ed to the Renderer
    * @author Nathan Swartz
    */
   public abstract class Scene
   {
      protected Renderer renderer;
      protected Scene prevScene;
      protected Scene(Scene prevScene) { this.prevScene = prevScene; }

      /**
       * Get the unchanging background image for this scene, upon which the
       * Renderer will draw all drawables of this scene
       * @Return background Image of this scene
       */
      public virtual Image GetBackgroundImage() { return Image.FromFile(Renderer.DEFAULT_BACKGROUND); }

      /**
       * Run each time this scene is switched to, immediately prior to this
       *    scene being displayed
       * @Param renderer to add drawables to
       */
      public virtual void Initialize(Renderer renderer) { this.renderer = renderer; }

      /**
       * Run on each keypress down
       * @Param key that was pressed
       * @Return Interactable scene to switch to next
       *         'return this' to retain focus on this scene
       *         'return null' to exit application
       */
      public virtual Scene OnKeyDownEvent(System.Windows.Forms.KeyEventArgs keyevent) { return this; }

      /**
       * Run on each MouseEvent
       * @Param MouseEventArgs that happened
       * @Return scene to switch to next
       *         'return this' to retain focus on this scene
       *         'return null' to exit application
       */
      public virtual Scene OnMouseEvent(System.Windows.Forms.MouseEventArgs e) { return this; }
      
      /**
       * Run on each frame
       * (Note, a Renderer.render() call is also run each frame)
       * @Return scene to switch to next
       *         'return this' to retain focus on this scene
       *         'return null' to exit application
       */
      public virtual Scene OnFrameTickEvent() { return this; }

      /**
       * Run each time this scene is switched away from,
       *    immediately prior to the new scene being switched to is displayed
       */
      public virtual void Close() { }
   }
}
