using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Trader : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("����� ������ �� ������ �����! ���������, ���������!");
    }
    protected abstract void OpenTradeDialog();
}
