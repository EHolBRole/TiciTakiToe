using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{

    public GameObject[] buttons;

    public int fieldSize;

    public int winCondition;

    void Start()
    {
        GameEngine.fieldSize = fieldSize;
        GameEngine.winCondition = winCondition;
        GameEngine.Init();
    }
}
