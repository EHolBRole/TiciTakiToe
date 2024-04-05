using Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEditor;
using System;

public class AIManager
{
    private const int MAX_DEPTH = 4; 

    public int[] choise = new int[2];
    
    public void FindBestMove(GameField gameField, Field aiPlayer) 
    {
        int bestScore = int.MinValue;
        int alpha = int.MinValue;
        int beta = int.MaxValue;

        for (int i = 0; i < GameEngine.fieldSize; i++) 
        {
            for (int j = 0; j < GameEngine.fieldSize; j++)
            {
                if (gameField.field[i, j].type == Field.Undef)
                {
                    gameField.field[i, j].type = aiPlayer;
                    int score = Minimax(gameField, 0, false, aiPlayer, alpha, beta);
                    gameField.field[i, j].type = Field.Undef;

                    if (score > bestScore)
                    {
                        bestScore = score;
                        choise = new int[2] { i, j };
                    }
                    alpha = Math.Max(alpha, score);
                }
            }
        }
    }

    public int Minimax(GameField gameField, int depth, bool isMaximizingPlayer, Field aiPlayer, int alpha, int beta)
    {
        if (GameEngine.moveManager.CheckWin(aiPlayer, gameField) == WinCondition.Win)
        {
            return 10 - depth;
        }
        else if (GameEngine.moveManager.CheckWin(GameEngine.gameManager.playerState, gameField) == WinCondition.Win)
        {
            return depth - 10;
        }
        else if (GameEngine.moveManager.CheckWin(Field.X, gameField) == WinCondition.Draw || depth == MAX_DEPTH)
        {
            return 0;
        }

        if(isMaximizingPlayer)
        {
            int bestScore = int.MinValue;

            for (int i = 0; i < GameEngine.fieldSize; i++)
            {
                for (int j = 0; j < GameEngine.fieldSize; j++)
                {
                    if (gameField.field[i, j].type == Field.Undef)
                    {
                        gameField.field[i, j].type = aiPlayer;
                        int score = Minimax(gameField, depth + 1, false, aiPlayer, alpha, beta);
                        gameField.field[i, j].type = Field.Undef;
                        bestScore = Math.Max(bestScore, score);
                        alpha = Math.Max(alpha, score);
                        if (beta <= alpha)
                            break;
                    }

                }
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;

            for (int i = 0; i < GameEngine.fieldSize; i++)
            {
                for (int j = 0; j < GameEngine.fieldSize; j++)
                {
                    if (gameField.field[i, j].type == Field.Undef)
                    {
                        gameField.field[i, j].type = (aiPlayer == Field.X) ? Field.O : Field.X;
                        int score = Minimax(gameField, depth + 1, true, aiPlayer, alpha, beta);
                        gameField.field[i, j].type = Field.Undef;
                        bestScore = Math.Min(bestScore, score);
                        beta = Math.Min(beta, score);
                        if (beta <= alpha)
                            break;
                    }

                }
            }
            return bestScore;
        }

    }
}
