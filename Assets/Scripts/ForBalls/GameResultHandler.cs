using System;
using UnityEngine;

public class GameResultHandler : MonoBehaviour
{
    public static Action<string> TheBallWasAssembled;

    private IVictoryConditions _victoryConditions;

    private void Awake()
    {
        Debug.Log("��� ������ ������� ������ ������� ����� 1 ��� 2: ");
        Debug.Log("1: ��� ������ �������� ��� ����;");
        Debug.Log("2: ��� ������ �������� ��� ���� ������ �����");

        TheBallWasAssembled += BallWasAssembled;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _victoryConditions == null)
        {
            SetVictoryCondition(new CollectAllBalls());
            Debug.Log("��� ������ �������� ��� ����!");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && _victoryConditions == null)
        {
            SetVictoryCondition(new CollectBallsSameColor());
            Debug.Log("��� ������ �������� ��� ���� ������ �����!");
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
            Debug.Log("�� ��������!");
            TheBallWasAssembled -= BallWasAssembled;
        }
    }
}
