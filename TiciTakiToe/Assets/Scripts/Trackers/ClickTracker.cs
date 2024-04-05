using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ClickTracker : MonoBehaviour
{
    public void OnClick(string XY)
    {
        GameEngine.moveManager.MakeMove(XY, GameEngine.gameManager.playerState);

        GameEngine.aiManager.FindBestMove(GameEngine.gameManager.gameField, GameEngine.gameManager.aiState);

        string aiInput = "";
        aiInput += (GameEngine.aiManager.choise[0] + 1).ToString();
        aiInput += (GameEngine.aiManager.choise[1] + 1).ToString();

        GameEngine.moveManager.MakeMove(aiInput, GameEngine.gameManager.aiState);
    }
}
