

using Khet3.Enums;

namespace KhetV3.Interfaces
{
    public interface IRotatable : IPiece
    {
        public Orientations orientation { get; set; }
    }
}