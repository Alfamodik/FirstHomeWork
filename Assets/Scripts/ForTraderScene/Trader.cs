using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Trader : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Новые товары по низким ценам! Подходите, покупайте!");
    }
    protected abstract void OpenTradeDialog();
}
