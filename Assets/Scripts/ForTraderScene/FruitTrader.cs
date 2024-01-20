using UnityEngine;

public class FruitTrader : Trader
{

    protected override void OpenTradeDialog()
    {
        Debug.Log("� ������ ��������!");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OpenTradeDialog();
    }
}
