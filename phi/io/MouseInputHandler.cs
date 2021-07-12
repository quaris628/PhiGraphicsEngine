using phi.graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phi.io
{
   public class MouseInputHandler
   {
      private LinkedList<Action<int, int>> actions;
      private Dictionary<Rectangle, LinkedList<Action<int, int>>> regionActions;
      private Dictionary<Drawable, LinkedList<Action<int, int>>> drawableActions;

      public MouseInputHandler()
      {
         actions = new LinkedList<Action<int, int>>();
         regionActions = new Dictionary<Rectangle, LinkedList<Action<int, int>>>();
         drawableActions = new Dictionary<Drawable, LinkedList<Action<int, int>>>();
      }

      public void Subscribe(Action<int, int> action) { actions.AddFirst(action); }
      public void Unsubscribe(Action<int, int> action) { actions.Remove(action); }

      public void SubscribeOnDrawable(Action<int, int> action, Drawable drawable)
      {
         LinkedList<Action<int, int>> existingActions;
         if (!drawableActions.TryGetValue(drawable, out existingActions))
         {
            existingActions = new LinkedList<Action<int, int>>();
            drawableActions.Add(drawable, existingActions);
         }
         existingActions.AddFirst(action);
      }
      public void UnsubscribeFromDrawable(Action<int, int> action, Drawable drawable)
      {
         drawableActions[drawable].Remove(action);
      }

      public void SubscribeOnRegion(Action<int, int> action, Rectangle region)
      {
         LinkedList<Action<int, int>> existingActions;
         if (!regionActions.TryGetValue(region, out existingActions))
         {
            existingActions = new LinkedList<Action<int, int>>();
            regionActions.Add(region, existingActions);
         }
         existingActions.AddFirst(action);
      }

      public void UnsubscribeFromRegion(Action<int, int> action, Rectangle region)
      {
         regionActions[region].Remove(action);
      }

      // Subscription overloads
      private Action<int, int> Wrap(Action action)
      {
         return new Action<int, int>((a, b) => { action.Invoke(); });
      }
      public void Subscribe(Action action) { Subscribe(Wrap(action)); }
      public void Unsubscribe(Action action) { Unsubscribe(Wrap(action)); }
      public void SubscribeOnDrawable(Action action, Drawable drawable) { SubscribeOnDrawable(Wrap(action), drawable); }
      public void UnsubscribeFromDrawable(Action action, Drawable drawable) { UnsubscribeFromDrawable(Wrap(action), drawable); }
      public void SubscribeOnRegion(Action action, Rectangle region) { SubscribeOnRegion(Wrap(action), region); }
      public void UnsubscribeFromRegion(Action action, Rectangle region) { UnsubscribeFromRegion(Wrap(action), region); }

      public void Clear()
      {
         actions.Clear();
         regionActions.Clear();
         drawableActions.Clear();
      }

      public void Event(object sender, MouseEventArgs e)
      {
         foreach (Action<int, int> action in actions)
         {
            action.Invoke(e.X, e.Y);
         }

         // not very efficient; todo try to improve (by using 2d array to sort a list in 2 distinct orders at the same time?)
         foreach (Rectangle region in regionActions.Keys)
         {
            if (region.Contains(e.X, e.Y))
            {
               foreach (Action<int, int> action in regionActions[region])
               {
                  action.Invoke(e.X, e.Y);
               }
            }
         }

         foreach (KeyValuePair<Drawable, LinkedList<Action<int, int>>> kvp in drawableActions)
         {
            if (kvp.Key.GetBoundaryRectangle().Contains(e.X, e.Y))
            {
               foreach (Action<int, int> action in kvp.Value)
               {
                  action.Invoke(e.X, e.Y);
               }
            }
         }
      }
   }
}
