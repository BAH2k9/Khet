using Khet.Wpf.ViewModels;
using System;

namespace Khet.Wpf.Models
{
    public class MoveModel
    {
        private SquareViewModel? previousSquare = null;
        private SquareViewModel? nextSquare = null;

        public MoveModel()
        {
        }

        public SquareViewModel NewSquareClicked(SquareViewModel clickedSquare)
        {

           
            // Case 1: First click, select the square if it contains an active piece
            if (previousSquare == null && clickedSquare.activePiece != null)
            {
                // Select the clicked square
                previousSquare = clickedSquare;
                previousSquare.Select(true); // Highlight the square
            }
            // Case 2: A second square is clicked, attempt to move the piece
            else if (previousSquare != null && clickedSquare != previousSquare)
            {
                nextSquare = clickedSquare;

                // Move the piece only if the next square is empty
                move();

                // Deselect both squares after the move
                previousSquare.Select(false);
                nextSquare.Select(false);

                // Reset the selection
                previousSquare = null;
                nextSquare = null;
            }
            // Case 3: Clicking the same square again to deselect it
            else if (previousSquare == clickedSquare)
            {
                previousSquare.Select(false); // Deselect
                previousSquare = null; // Reset the selection
            }

            return clickedSquare;
        }

        private void move()
        {
            // Move the piece if both squares are valid
            if (previousSquare != null && nextSquare != null && previousSquare.activePiece != null)
            {
                previousSquare.MovePiece(nextSquare); // Transfer the piece
            }
        }
    }
}
