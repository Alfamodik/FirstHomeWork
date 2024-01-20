using UnityEngine;

public class NonTradingTrader : Trader
{
    protected override void OpenTradeDialog()
    {
        Debug.Log("Я не буду с тобой торговать, уходи прочь!");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OpenTradeDialog();
    }
}
