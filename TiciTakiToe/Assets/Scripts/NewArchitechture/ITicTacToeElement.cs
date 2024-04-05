using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts
{
    public interface ITicTacToeElement
    {
        public TicTacToeApp app { get { return GameObject.FindObjectOfType<TicTacToeApp>(); } }
    }
}