namespace DiamondKata.Canvases
{
    public class TextCanvas : ITextCanvas
    {
        private readonly char[,] _canvas;

        public TextCanvas(int size)
        {
            if (size <= 0)
                throw new ArgumentException($"Canvas size has to be a number greater than 0", nameof(size));

            Size = size;

            _canvas = new char[size, size];
        }

        public int Size { get; }

        public char GetCharacterAt(int posX, int posY)
        {
            if (posX < 0 || posX >= Size)
                throw new ArgumentOutOfRangeException(nameof(posX));
            if (posY < 0 || posY >= Size)
                throw new ArgumentOutOfRangeException(nameof(posY));

            return _canvas[posX, posY];
        }

        public void DrawCharacterAt(char character, int posX, int posY)
        {
            if (posX < 0 || posX >= Size)
                throw new ArgumentOutOfRangeException(nameof(posX));
            if (posY < 0 || posY >= Size)
                throw new ArgumentOutOfRangeException(nameof(posY));

            _canvas[posX, posY] = character;
        }
    }
}
