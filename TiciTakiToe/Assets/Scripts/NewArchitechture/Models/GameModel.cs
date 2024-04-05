using Scripts;
using Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Models
{
    public class GameModel : ITicTacToeElement
    {

        public int fieldSize;
        public int winCondition;

        public FieldModel field;

        public GameModel()
        {
            field = new FieldModel(fieldSize);
        }
    }
}
