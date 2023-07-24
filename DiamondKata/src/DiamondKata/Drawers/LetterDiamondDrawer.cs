using DiamondKata.Canvases;

namespace DiamondKata.Drawers
{
    public class LetterDiamondDrawer : ITextDrawer
    {
        private readonly ITextCanvas _canvas;
        private readonly char _letter;

        public LetterDiamondDrawer(ITextCanvas canvas, char letter)
        {
            if (!char.IsLetter(letter))
                throw new ArgumentException($"Invalid letter '{letter}'", nameof(letter));

            letter = char.ToUpper(letter);

            int requiredSize = 2 * (letter - 'A' + 1) - 1;
            if (canvas.Size != requiredSize)
                throw new ArgumentException($"Canvas size {canvas.Size} need to match the required diamond size {requiredSize}", nameof(canvas));

            _canvas = canvas;
            _letter = letter;
        }

        public void Draw()
        {
            var center = Convert.ToInt32(Math.Floor(_canvas.Size / 2d));
            
            for (int i = 0; i <= center; i++)
            {
                _canvas.DrawCharacterAt((char)('A' + i), i, center - i);
                _canvas.DrawCharacterAt((char)('A' + i), i, center + i);
            }

            for (int i = 1; i <= center; i++)
            {
                _canvas.DrawCharacterAt((char)(_letter - i), center + i, i);
                _canvas.DrawCharacterAt((char)(_letter - i), center + i, 2 * center - i);
            }
        }
    }
}
