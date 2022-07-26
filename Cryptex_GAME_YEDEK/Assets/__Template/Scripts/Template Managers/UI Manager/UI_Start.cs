using UnityEngine; 

public class UI_Start : MonoBehaviour
{

    [SerializeField] GameObject panelStart;  


    private void OnEnable()
    {
        EventManager.Instance.OnTapToPlay += TapToPlay;
        EventManager.Instance.OnLoadLevel += LoadLevel;
        //EventManager.Instance.OnGameLose += GameLose;
        //EventManager.Instance.OnGameWin += GameWin;
        //EventManager.Instance.OnGainCoin += GainCoin;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnTapToPlay -= TapToPlay;
        EventManager.Instance.OnLoadLevel -= LoadLevel;
        //EventManager.Instance.OnGameLose -= GameLose;
        //EventManager.Instance.OnGameWin -= GameWin;
        //EventManager.Instance.OnGainCoin -= GainCoin;
    }

    void TapToPlay()
    {
        panelStart.SetActive(false);
    }

    void LoadLevel()
    {
        panelStart.SetActive(true); 
    }

    //void GameLose(int gainedCoin)
    //{

    //}

    //void GameWin(int gainedCoin)
    //{

    //}

    //void GainCoin(int gainedCoin, Vector3 worldPos)
    //{

    //}








    public void ClickStart()
    { 
        EventManager.Instance.TapToPlay(); 
    }
}
