using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class MoveManager
{
    public void MakeMove(string XY, Field field)
    {
        int[] input = Parse(XY);

        GameEngine.gameManager.gameField.field[input[0], input[1]].type = field;
        GameEngine.gameManager.gameField.lastMove = input;

        ChangeButton(input, field);

        ProcessWin();

    }

    public void ProcessWin()
    {
        WinCondition status = CheckWin(GameEngine.gameManager.playerState, GameEngine.gameManager.gameField);

        if (status == WinCondition.Win)
            Debug.Log("VICTORY!");
        else if (status == WinCondition.Draw)
            Debug.Log("Draw");
        else if (CheckWin(GameEngine.gameManager.aiState, GameEngine.gameManager.gameField) == WinCondition.Win)
            Debug.Log("Loose");
    }

    public void ChangeButton(int[] input, Field field)
    {
        int button_input = 0;

        if (input[0] == 0)
            button_input = input[1];
        else
            button_input = input[0] * GameEngine.fieldSize + input[1];

        InitManager initManager = GameObject.FindGameObjectWithTag("Field").GetComponent<InitManager>();

        initManager.buttons[button_input].GetComponent<Image>().color = new Color(1, 1, 1, 1);

        if (field == Field.X)
            initManager.buttons[button_input].GetComponent<Image>().sprite = GameEngine.gameManager.X;
        else
            initManager.buttons[button_input].GetComponent<Image>().sprite = GameEngine.gameManager.O;

        initManager.buttons[button_input].GetComponent<Button>().interactable = false;
    }
    

    public int[] Parse(string str)
    {
        return new int[2] { Convert.ToInt32(str[0]) - 49, Convert.ToInt32(str[1]) - 49 };
    }

    public WinCondition CheckWin(Field state, GameField gameField)
    {
        int n = GameEngine.fieldSize;
        int k = GameEngine.winCondition;

        for (int i = 0; i <= n - k; i++)
        {
            for (int j = 0; j < n; j++)
            {
                bool hasWon = true;
                for (int x = i; x < i + k; x++)
                {
                    if (gameField.field[x, j].type != state)
                    {
                        hasWon = false;
                        break;
                    }
                }
                if (hasWon)
                    return WinCondition.Win;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= n - k; j++)
            {
                bool hasWon = true;
                for (int y = j; y < j + k; y++)
                {
                    if (gameField.field[i, y].type != state)
                    {
                        hasWon = false;
                        break;
                    }
                }
                if (hasWon)
                    return WinCondition.Win;
            }
        }

        for (int i = 0; i <= n - k; i++)
        {
            for (int j = 0; j <= n - k; j++)
            {
                bool hasWon = true;
                for (int d = 0; d < k; d++)
                {
                    if (gameField.field[i + d, j + d].type != state)
                    {
                        hasWon = false;
                        break;
                    }
                }
                if (hasWon)
                    return WinCondition.Win;
            }
        }

        for (int i = k - 1; i < n; i++)
        {
            for (int j = 0; j <= n - k; j++)
            {
                bool hasWon = true;
                for (int d = 0; d < k; d++)
                {
                    if (gameField.field[i - d, j + d].type != state)
                    {
                        hasWon = false;
                        break;
                    }
                }
                if (hasWon)
                    return WinCondition.Win;
            }
        }

        if (IsFinished(gameField))
            return WinCondition.Draw;

        return WinCondition.Undef;
    }

    public bool IsFinished(GameField gameField)
    {
        for (int i = 0; i < GameEngine.fieldSize; i++)
        {
            for (int j = 0; j < GameEngine.fieldSize; j++)
            {
                if (gameField.field[i, j].type == Field.Undef)
                    return false;
            }
        }
        return true;
    }
}

public enum WinCondition
{
    Win, Draw, Undef
}