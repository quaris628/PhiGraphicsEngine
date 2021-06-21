using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using phi;
using phi.graphics;

namespace PhiTests
{
   [TestClass]
   public class UnitTestSprite
   {
      private const string ARBITRARY_IMAGE_FILE = "../../res/arbitrary-image-for-testing.png";

      [TestMethod]
      public void ConstructorImage_ImageEqualsGivenImage()
      {
         // Arrange
         Image image = Image.FromFile(ARBITRARY_IMAGE_FILE);

         // Act
         Sprite sprite = new Sprite(image, 0, 0);
         Image result = sprite.GetImage();

         // Assert
         Assert.AreEqual(image, result);
      }

      [TestMethod]
      public void ConstructorImage_NullImageThrowsArgumentNullException()
      {
         // Arrange
         Image image = null;

         // Act
         bool exceptionThrown;
         try
         {
            Sprite sprite = new Sprite(image, 0, 0);
            exceptionThrown = false;
         }
         catch (ArgumentNullException)
         {
            exceptionThrown = true;
         }
         
         // Assert
         Assert.IsTrue(exceptionThrown);
      }


      [TestMethod]
      public void ConstructorImageXY_ImageEqualsGivenImage()
      {
         // Arrange
         Image image = Image.FromFile(ARBITRARY_IMAGE_FILE);
         int x = 0;
         int y = 0;

         // Act
         Sprite sprite = new Sprite(image, x, y);
         Image result = sprite.GetImage();

         // Assert
         Assert.AreEqual(image, result);
      }

      [TestMethod]
      public void ConstructorImageXY_NullImageThrowsArgumentNullException()
      {
         // Arrange
         Image image = null;
         int x = 0;
         int y = 0;

         // Act
         bool exceptionThrown;
         try
         {
            Sprite sprite = new Sprite(image, x, y);
            exceptionThrown = false;
         }
         catch (ArgumentNullException)
         {
            exceptionThrown = true;
         }

         // Assert
         Assert.IsTrue(exceptionThrown);
      }


      // TODO: Hash code?

      // TODO: Equals

   }
}
