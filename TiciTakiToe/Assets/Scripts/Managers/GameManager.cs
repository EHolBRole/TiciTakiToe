using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager
{

    public GameField gameField;

    public Field playerState;
    public Field aiState;


    public Sprite X;
    public Sprite O;

    public GameManager()
    {
        gameField = new GameField();

        playerState = Field.X;
        aiState = Field.O;

        X = Resources.Load<Sprite>("XO/X");
        O = Resources.Load<Sprite>("XO/O");
    }
}
