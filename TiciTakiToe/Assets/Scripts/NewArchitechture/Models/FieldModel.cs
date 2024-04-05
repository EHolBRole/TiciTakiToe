using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Models
{
    public class FieldModel : ITicTacToeElement
    {
        public int[] lastMove;

        public CellModel[,] field;

        public FieldModel(int fieldSize)
        {
            field = new CellModel[fieldSize, fieldSize];

            for (int i = 0; i < fieldSize; i++)
            {
                for (int y = 0; y < fieldSize; y++)
                {
                    field[i, y] = new CellModel();
                }
            }
        }
    }

}
