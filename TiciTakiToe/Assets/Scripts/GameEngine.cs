using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts;

public static class GameEngine
{
    public static GameManager gameManager;

    public static MoveManager moveManager;

    public static AIManager aiManager;

    public static int fieldSize;
    public static int winCondition;
    public static void Init()
    {
        gameManager = new GameManager();
        moveManager = new MoveManager();   
        aiManager = new AIManager();
    }
}
