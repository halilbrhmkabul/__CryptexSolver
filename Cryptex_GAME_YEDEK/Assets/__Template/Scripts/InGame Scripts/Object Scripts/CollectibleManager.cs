using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    bool isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered && GameManager.Instance.GameActive)
        {
            isTriggered = true;


           // EventManager.Instance.Collectible(0);       //Oyun i�erisinde tutar veriyi. (Collectible eventleri �al��s�n diye �a��r�yoruz, paray� a�a��daki sat�rda kazanaca��z.)
            EventManager.Instance.GainCoin(5, CinemachineManager.Instance.MainCamera.WorldToScreenPoint(transform.position));      //Do�rudan PlayerPref'e kaydeder.

            gameObject.SetActive(false);
        }
    }
}
