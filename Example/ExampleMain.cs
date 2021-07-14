using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi;

namespace Example
{
   static class ExampleMain
   {
	  // to hide console for a project (this has already been done for this project):
      // project -> properties -> Output type, set to Windows Application instead of Console Application
	   
      // Entry point
      public static void Main()
      {
         PhiMain.Main(new Scene1(null), new ExamplePhiConfig());
      }
   }
}
