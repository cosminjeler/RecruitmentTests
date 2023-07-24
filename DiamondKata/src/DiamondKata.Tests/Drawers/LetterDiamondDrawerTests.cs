using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiamondKata.Drawers;
using DiamondKata.Canvases;

namespace DiamondKata.Tests.Drawers
{
    [TestClass]
    public class LetterDiamondDrawerTests
    {
        [TestMethod]
        [DataRow('0')]
        [DataRow('\n')]
        [DataRow('@')]
        [DataRow('\\')]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_InvalidLetter_ArgumentException(char character)
        {
            // Arrange
            var canvas = new TextCanvas(10);

            // Act
            new LetterDiamondDrawer(canvas, character);
        }

        [TestMethod]
        [DataRow('A', 2)]
        [DataRow('a', 2)]
        [DataRow('B', 4)]
        [DataRow('M', 24)]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_InvalidCanvasSize_ArgumentException(char letter, int size)
        {
            // Arrange
            var canvas = new TextCanvas(size);

            // Act
            new LetterDiamondDrawer(canvas, letter);
        }

        [TestMethod]
        public void Draw_LetterA_DrawCalled()
{
            // Arrange
            var letter = 'A';
            var canvas = new Mock<ITextCanvas>();
            canvas
                .Setup(c => c.Size)
                .Returns(1);

            canvas
                .Setup(c => c.DrawCharacterAt(It.Is<char>(l => l == letter), It.Is<int>(x => x == 0), It.Is<int>(y => y == 0)))
                .Verifiable();

            var sut = new LetterDiamondDrawer(canvas.Object, letter);

            // Act
            sut.Draw();

            // Assert
            canvas.VerifyAll();
        }
    }
}
