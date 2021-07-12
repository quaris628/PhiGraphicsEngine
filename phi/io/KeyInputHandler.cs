using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phi.io
{
   public class KeyInputHandler
   {
      private Dictionary<int, LinkedList<Action>> actions;
      private Dictionary<int, LinkedList<Action<Keys>>> keyActions;
      private Dictionary<int, LinkedList<Action<KeyEventArgs>>> eventActions;

      public KeyInputHandler()
      {
         actions = new Dictionary<int, LinkedList<Action>>();
         keyActions = new Dictionary<int, LinkedList<Action<Keys>>>();
         eventActions = new Dictionary<int, LinkedList<Action<KeyEventArgs>>>();
      }

      // Subscribe overloads
      public void Subscribe(Action action, Keys key) { Subscribe(action, new KeyEventArgs(KeysWrapper.GetWindowsKeys(key))); }
      public void Subscribe(Action<Keys> action, Keys key) { Subscribe(action, new KeyEventArgs(key)); }
      public void Subscribe(Action<KeyEventArgs> action, Keys key) { Subscribe(action, new KeyEventArgs(key)); }
      public void Subscribe(Action action, KeyEventArgs keyEvent)
      {
         int hashKey = Hash(keyEvent);
         if (!actions.ContainsKey(hashKey)) { actions[hashKey] = new LinkedList<Action>(); }
         actions[hashKey].AddFirst(action);
      }
      public void Subscribe(Action<Keys> action, KeyEventArgs keyEvent)
      {
         int hashKey = Hash(keyEvent);
         if (!keyActions.ContainsKey(hashKey)) { keyActions[hashKey] = new LinkedList<Action<Keys>>(); }
         keyActions[hashKey].AddFirst(action);
      }
      public void Subscribe(Action<KeyEventArgs> action, KeyEventArgs keyEvent)
      {
         int hashKey = Hash(keyEvent);
         if (!eventActions.ContainsKey(hashKey)) { eventActions[hashKey] = new LinkedList<Action<KeyEventArgs>>(); }
         eventActions[hashKey].AddFirst(action);
      }

      // Unsubscribe overloads
      public void Unsubscribe(Action action, Keys key) { Unsubscribe(action, new KeyEventArgs(key)); }
      public void Unsubscribe(Action<Keys> action, Keys key) { Unsubscribe(action, new KeyEventArgs(key)); }
      public void Unsubscribe(Action<KeyEventArgs> action, Keys key) { Unsubscribe(action, new KeyEventArgs(key)); }
      public void Unsubscribe(Action action, KeyEventArgs keyEvent) { actions[Hash(keyEvent)].Remove(action); }
      public void Unsubscribe(Action<Keys> action, KeyEventArgs keyEvent) { keyActions[Hash(keyEvent)].Remove(action); }
      public void Unsubscribe(Action<KeyEventArgs> action, KeyEventArgs keyEvent) { eventActions[Hash(keyEvent)].Remove(action); }

      public void Clear()
      {
         actions.Clear();
         keyActions.Clear();
      }

      public void KeyInputEvent(object sender, KeyEventArgs e)
      {
         int hash = Hash(e);
         if (actions.ContainsKey(hash))
         {
            IEnumerator<Action> todos = actions[hash].GetEnumerator();
            while(todos.MoveNext())
            {
               Action action = todos.Current;
               if (action != null)
               {
                  action.Invoke();
               }
            }
         }
         if (keyActions.ContainsKey(Hash(e)))
         {
            foreach (Action<Keys> action in keyActions[Hash(e)])
            {
               action.Invoke(e.KeyCode);
            }
         }
         if (eventActions.ContainsKey(Hash(e)))
         {
            foreach (Action<KeyEventArgs> action in eventActions[Hash(e)])
            {
               action.Invoke(e);
            }
         }
      }

      private static int Hash(KeyEventArgs e)
      {
         /*
         e.Alt; // bool
         e.Control; // bool
         e.Handled; // bool, not applicable ?
         e.KeyCode; // Keys, dependent on KeyValue
         e.KeyData; // Keys, dependent on KeyValue/KeyCode, Ctrl, Shift, Alt
         e.KeyValue; // int
         e.Modifiers; // Keys, dependent on Ctrl, Shift, Alt
         e.Shift; // bool
         e.SuppressKeyPress; // bool, not applicable?
         */
         return e.KeyData.GetHashCode();
      }
   }


}
