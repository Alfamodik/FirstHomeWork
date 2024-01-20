using UnityEngine;

public class Ball : MonoBehaviour
{
    public string Color;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameResultHandler.TheBallWasAssembled?.Invoke(Color);
            Destroy(gameObject);
        }
    }
}
