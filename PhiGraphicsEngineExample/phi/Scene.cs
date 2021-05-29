using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi
{
   /**
    * Abstract Scene class for different scene subclasses to extend from.
    * Provides default methods for all InteractableScene methods
    * @author Nathan Swartz
    */
   public abstract class Scene : IScene
   {
      public virtual Image GetBackgroundImage() { return null; }
      public virtual void Initialize() { }
      public virtual IScene OnKeyDownEvent(System.Windows.Forms.KeyEventArgs keyevent) { return this; }
      public virtual IScene OnMouseEvent(System.Windows.Forms.MouseEventArgs e) { return this; }
      public virtual IScene OnFrameTickEvent() { return this; }
   }
}
