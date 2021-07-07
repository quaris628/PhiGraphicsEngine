using phi.graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phi.control.input
{
   public class MouseInputHandler
   {
      private LinkedList<Action> actions;
      private Dictionary<Rectangle, LinkedList<Action>> regionActions;
      private Dictionary<Drawable, LinkedList<Action>> drawableActions;

      public MouseInputHandler()
      {
         actions = new LinkedList<Action>();
         regionActions = new Dictionary<Rectangle, LinkedList<Action>>();
         drawableActions = new Dictionary<Drawable, LinkedList<Action>>();
      }

      public void Subscribe(Action action)
      {
         actions.AddFirst(action);
      }

      public void SubscribeOnDrawable(Action action, Drawable drawable)
      {
         LinkedList<Action> existingActions;
         if (!drawableActions.TryGetValue(drawable, out existingActions))
         {
            existingActions = new LinkedList<Action>();
            drawableActions.Add(drawable, existingActions);
         }
         existingActions.AddFirst(action);
      }

      public void SubscribeOnRegion(Action action, Rectangle region)
      {
         LinkedList<Action> existingActions;
         if (!regionActions.TryGetValue(region, out existingActions))
         {
            existingActions = new LinkedList<Action>();
            regionActions.Add(region, existingActions);
         }
         existingActions.AddFirst(action);
      }

      public void Clear()
      {
         actions.Clear();
         regionActions.Clear();
         drawableActions.Clear();
      }

      public void Event(object sender, MouseEventArgs e)
      {
         foreach (Action action in actions)
         {
            action.Invoke();
         }

         // not very efficient; todo try to improve (by using 2d array to sort a list in 2 distinct orders at the same time?)
         foreach (Rectangle region in regionActions.Keys)
         {
            if (region.Contains(e.X, e.Y))
            {
               foreach (Action action in regionActions[region])
               {
                  action.Invoke();
               }
            }
         }

         foreach (KeyValuePair<Drawable, LinkedList<Action>> kvp in drawableActions)
         {
            if (kvp.Key.GetBoundaryRectangle().Contains(e.X, e.Y))
            {
               foreach (Action action in kvp.Value)
               {
                  action.Invoke();
               }
            }
         }
      }
   }
}
