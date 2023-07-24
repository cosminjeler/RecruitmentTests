using System.Text;
using DiamondKata.Canvases;
using DiamondKata.Drawers;
using DiamondKata.Writers;

namespace DiamondKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || !char.TryParse(args[0], out var letter) || !char.IsLetter(letter))
            {
                Console.WriteLine("Please provide a valid letter");
                Console.ReadKey();
                return;
            }

            int canvasSize = 2 * (letter - 'A' + 1) - 1;
            var canvas = new TextCanvas(canvasSize);

            var diamondDrawer = new LetterDiamondDrawer(canvas, letter);
            diamondDrawer.Draw();

            var stringBuilder = new StringBuilder();
            var writer = new CanvasStringWriter(stringBuilder);
            writer.Write(canvas);

            Console.WriteLine(stringBuilder.ToString());

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
