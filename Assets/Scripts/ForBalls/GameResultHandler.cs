using System;
using UnityEngine;

public class GameResultHandler : MonoBehaviour
{
    public static Action<string> TheBallWasAssembled;

    private IVictoryConditions _victoryConditions;

    private void Awake()
    {
        Debug.Log("Для выбора условия победы нажмите цифру 1 или 2: ");
        Debug.Log("1: Для победы соберите все шары;");
        Debug.Log("2: Для победы соберите все шары одного цвета");

        TheBallWasAssembled += BallWasAssembled;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _victoryConditions == null)
        {
            SetVictoryCondition(new CollectAllBalls());
            Debug.Log("Для победы соберите все шары!");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && _victoryConditions == null)
        {
            SetVictoryCondition(new CollectBallsSameColor());
            Debug.Log("Для победы соберите все шары одного цвета!");
        }
    }
    public void SetVictoryCondition(IVictoryConditions victoryConditions)
    {
        _victoryConditions = victoryConditions;
    }
    private void BallWasAssembled(string ballColor)
    {
        if (_victoryConditions == null)
            return;
        
        _victoryConditions.AddBallsToCollected(ballColor);

        if (_victoryConditions.IsVictory())
        {
            Debug.Log("Вы победили!");
            TheBallWasAssembled -= BallWasAssembled;
        }
    }
}
