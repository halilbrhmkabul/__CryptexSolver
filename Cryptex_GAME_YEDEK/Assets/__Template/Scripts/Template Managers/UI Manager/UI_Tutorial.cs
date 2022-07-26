using UnityEngine; 
using Sirenix.OdinInspector;

public class UI_Tutorial : MonoBehaviour
{
    [Title("Panel Tutorial")]
    [SerializeField] GameObject panelTutorial;

    private void OnEnable()
    { 
        EventManager.Instance.OnLoadLevel += LoadLevel; 
    }
    private void OnDisable()
    { 
        EventManager.Instance.OnLoadLevel -= LoadLevel;
 
    }

  
    void LoadLevel()
    {
        DataManager.Instance.GetPlayerPrefs();
        if (DataManager.Instance.Level==1)
            panelTutorial.SetActive(true);
        
        else
            panelTutorial.SetActive(false);
        
    }
     
     
}
