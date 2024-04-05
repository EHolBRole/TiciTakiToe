using Scripts.Models;
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

        public GameField(int fieldSize)
        {
            field = new Cell[fieldSize, fieldSize];

            for (int i = 0; i < fieldSize; i++)
            {
                for (int y = 0; y < fieldSize; y++)
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


