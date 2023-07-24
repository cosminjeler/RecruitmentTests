namespace DiamondKata.Canvases
{
    public interface ITextCanvas
    {
        int Size { get; }

        void DrawCharacterAt(char character, int x, int y);
        char GetCharacterAt(int x, int y);
    }
}