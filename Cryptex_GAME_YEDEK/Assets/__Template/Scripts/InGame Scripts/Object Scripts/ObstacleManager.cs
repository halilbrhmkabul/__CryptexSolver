using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    bool isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered && GameManager.Instance.GameActive)
        {
            isTriggered = true;
            EventManager.Instance.Obstacle();

            gameObject.SetActive(false);
        }
    }
}
