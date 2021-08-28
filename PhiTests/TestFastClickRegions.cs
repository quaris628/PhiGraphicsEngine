using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using phi.other;

namespace PhiTests
{
   [TestClass]
   public class TestFastClickRegions
   {
      [TestMethod]
      public void Add_x2y2w4h4_x4y4GetClickItemsContainsTrue()
      {
         // Arrange
         FastClickRegions<Action> fcr = new FastClickRegions<Action>();
         Action a = new Action(() => { });
         Rectangle r = new Rectangle(2, 2, 4, 4);

         // Act
         fcr.Add(a, r);

         // Assert
         Assert.IsNotNull(fcr.GetClickItems(4, 4));
         Assert.IsTrue(fcr.GetClickItems(4, 4).Contains(a));
      }

      [TestMethod]
      public void Add_x2y2w4h4_x8y8GetClickItemsContainsFalse()
      {
         // Arrange
         FastClickRegions<Action> fcr = new FastClickRegions<Action>();
         Action a = new Action(() => { });
         Rectangle r = new Rectangle(2, 2, 4, 4);

         // Act
         fcr.Add(a, r);

         // Assert
         Assert.IsTrue(fcr.GetClickItems(8, 8) == null
            || !fcr.GetClickItems(8, 8).Contains(a));
      }

      // Note: must make FindIndexes public manually
      // (If there's a better way to access it I don't know of it)
      [TestMethod]
      public void FindIndexes_x2y2w4h4_x4y4FindIndexesx1y1()
      {
         // Arrange
         FastClickRegions<Action> fcr = new FastClickRegions<Action>();
         Action a = new Action(() => { });
         Rectangle r = new Rectangle(2, 2, 4, 4);
         fcr.Add(a, r);

         // Act
         int[] res = fcr.FindIndexes(4, 4);

         // Assert
         Assert.AreEqual(1, res[0]);
         Assert.AreEqual(1, res[1]);
      }
   }
}
