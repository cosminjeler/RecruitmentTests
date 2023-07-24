using System.Text;
using DiamondKata.Canvases;

namespace DiamondKata.Writers
{
    public class CanvasStringWriter : ICanvasWriter
    {
        private readonly StringBuilder _stringBuilder;

        public CanvasStringWriter(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder ?? throw new ArgumentNullException(nameof(stringBuilder));
        }

        public void Write(ITextCanvas canvas)
        {
            for (int i = 0; i < canvas.Size; i++)
            {
                for (int j = 0; j < canvas.Size; j++)
                {
                    var character = canvas.GetCharacterAt(i, j);
                    _stringBuilder.Append(character != default ? character : ' ');
                }

                if (i != canvas.Size - 1)
                    _stringBuilder.AppendLine();
            }
        }
    }
}
