using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace Scripts
{

    public class GameField
    {

        public int[] lastMove;

        public Cell[,] field;

        public GameField()
        {
            field = new Cell[GameEngine.fieldSize, GameEngine.fieldSize];

            for (int i = 0; i < GameEngine.fieldSize; i++)
            {
                for (int y = 0; y < GameEngine.fieldSize; y++)
                {
                    field[i, y] = new Cell();
                }
            }
        }
    }

    public enum Field
    {
        X, O, Undef
    }

}


