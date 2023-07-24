using System;
using System.Text;
using Moq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiamondKata.Canvases;
using DiamondKata.Writers;

namespace DiamondKata.Tests.Drawers
{
    [TestClass]
    public class CanvasStringWriterTests
    {
        [TestMethod]
        public void Write_CanvasWithLetterA_ReturnsCorrectDiamond()
        {
            // Arrange
            var sb = new StringBuilder();
            var canvas = new TextCanvas(1);
            canvas.DrawCharacterAt('A', 0, 0);

            var sut = new CanvasStringWriter(sb);

            // Act
            sut.Write(canvas);

            // Assert
            sb.ToString().Should().Be("A");
        }

        [TestMethod]
        public void Write_CanvasWithLetterB_ReturnsCorrectDiamond()
        {
            // Arrange
            var sb = new StringBuilder();
            var canvas = new TextCanvas(3);
            canvas.DrawCharacterAt('A', 0, 1);
            canvas.DrawCharacterAt('B', 1, 0);
            canvas.DrawCharacterAt('B', 1, 2);
            canvas.DrawCharacterAt('A', 2, 1);

            var sut = new CanvasStringWriter(sb);

            // Act
            sut.Write(canvas);

            // Assert
            sb.ToString().Should().Be(" A \r\nB B\r\n A ");
        }

        [TestMethod]
        public void Write_CanvasWithLetterC_ReturnsCorrectDiamond()
        {
            // Arrange
            var sb = new StringBuilder();
            var canvas = new TextCanvas(5);
            canvas.DrawCharacterAt('A', 0, 2);
            canvas.DrawCharacterAt('B', 1, 1);
            canvas.DrawCharacterAt('B', 1, 3);
            canvas.DrawCharacterAt('C', 2, 0);
            canvas.DrawCharacterAt('C', 2, 4);
            canvas.DrawCharacterAt('B', 3, 1);
            canvas.DrawCharacterAt('B', 3, 3);
            canvas.DrawCharacterAt('A', 4, 2);

            var sut = new CanvasStringWriter(sb);

            // Act
            sut.Write(canvas);

            // Assert
            sb.ToString().Should().Be("  A  \r\n B B \r\nC   C\r\n B B \r\n  A  ");
        }
    }
}
