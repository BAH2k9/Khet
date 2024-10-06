

using Khet3.Enums;
using KhetV3.MVVM.Models;
using System.Windows.Input;

namespace KhetV3.Interfaces
{
    public interface IRotatable : IPiece
    {
        public Orientations orientation { get; set; }

        public void Rotate(Key key)
        {
            orientation = DirectionMappings.Rotate[(orientation, key)];
        }
    }
}