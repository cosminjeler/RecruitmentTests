using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiamondKata.Canvases;

namespace DiamondKata.Tests.Canvases
{
    [TestClass]
    public class TextCanvasTests
    {
        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-100)]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_InvalidCanvasSize_ArgumentException(int size)
        {
            // Act
            new TextCanvas(size);
        }

        [TestMethod]
        [DataRow(0, -1)]
        [DataRow(-1, 2)]
        [DataRow(1, -2)]
        [DataRow(10, 2)]
        [DataRow(1, 10)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetCharacterAt_InvalidPosition_ArgumentOutOfRangeException(int posX, int posY)
        {
            // Arrange
            var sut = new TextCanvas(10);

            // Act
            sut.GetCharacterAt(posX, posY);
        }

        [TestMethod]
        [DataRow(0, -1)]
        [DataRow(-1, 2)]
        [DataRow(1, -2)]
        [DataRow(10, 2)]
        [DataRow(1, 10)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DrawCharacterAt_InvalidPosition_ArgumentOutOfRangeException(int posX, int posY)
        {
            // Arrange
            var sut = new TextCanvas(10);

            // Act
            sut.DrawCharacterAt('a', posX, posY);
        }
    }
}
