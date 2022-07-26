using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    bool isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered && GameManager.Instance.GameActive)
        {
            isTriggered = true;


           // EventManager.Instance.Collectible(0);       //Oyun içerisinde tutar veriyi. (Collectible eventleri çalýþsýn diye çaðýrýyoruz, parayý aþaðýdaki satýrda kazanacaðýz.)
            EventManager.Instance.GainCoin(5, CinemachineManager.Instance.MainCamera.WorldToScreenPoint(transform.position));      //Doðrudan PlayerPref'e kaydeder.

            gameObject.SetActive(false);
        }
    }
}
