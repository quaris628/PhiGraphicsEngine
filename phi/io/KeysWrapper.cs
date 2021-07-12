using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phi.io
{
   public class KeysWrapper
   {
      private Keys key;
      
      public KeysWrapper(Keys key)
      {
         this.key = key;
      }

      public System.Windows.Forms.Keys GetWindowsKeys() { return (System.Windows.Forms.Keys)(int)key; }

      public static System.Windows.Forms.Keys GetWindowsKeys(Keys key) { return (System.Windows.Forms.Keys)(int)key; }
      public static Keys GetWrapperKeys(System.Windows.Forms.Keys key) { return (Keys)(int)key; }

   }
}
