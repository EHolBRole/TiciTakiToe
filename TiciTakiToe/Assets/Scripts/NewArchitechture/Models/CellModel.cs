using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Models
{
    public class CellModel : ITicTacToeElement
    {
        public PlayerType type;

        public int neighbours;

        public CellModel()
        {
            type = PlayerType.Undef;
            neighbours = 0;
        }
    }

    public enum PlayerType
    {
        X, O, Undef
    }
}
