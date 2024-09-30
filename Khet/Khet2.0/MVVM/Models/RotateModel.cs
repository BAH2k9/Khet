using Khet2._0.CustomTypes;
using Khet2._0.Events;
using Khet2._0.MVVM.ViewModel;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khet2._0.MVVM.Models
{
    public class RotateModel : IHandle<PieceRotateEvent>
    {
        public RotateModel(EventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }


        public void Handle(PieceRotateEvent e)
        {
            if (e.square.ActivePiece is DjedViewModel || e.square.ActivePiece is PyramidViewModel)
            {
                e.square.ActivePiece.orientation = Mappings.Rotate[(e.square.ActivePiece.orientation, e.key)];
                e.square.ActivePiece.RenderPiece();
            }




        }
    }
}
