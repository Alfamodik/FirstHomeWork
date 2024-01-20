using UnityEngine;

public class ArmorTrader : Trader
{
    protected override void OpenTradeDialog()
    {
        Debug.Log("Я торгую бронёй!");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OpenTradeDialog();
    }
}
