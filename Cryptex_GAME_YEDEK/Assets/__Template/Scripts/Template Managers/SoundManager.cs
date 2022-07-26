using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using Pixelplacement;

public class SoundManager : Singleton<SoundManager>
{
    [Title("Audio Sources")]
    [InfoBox("0 -> UI Audio Source, \n1-> Camera Audio Source,\nIf you want to add more, you can...")]
    [SerializeField] List<AudioSource> audioSources;
    [SerializeField] List<AudioClip> otherAudioClips;

    [Title("ClickButton Sounds")]
    [SerializeField] bool isClickButtonSoundActive;
    [SerializeField] int cbsSelectedIndex;
    [SerializeField] List<AudioClip> clickButtonSounds;

    [Title("Collectible Sounds")]
    [SerializeField] bool isCollectibleSoundActive;
    [SerializeField] int collectibleSelectedIndex;
    [SerializeField] List<AudioClip> collectibleSounds;


    [Title("Obstacle Sounds")]
    [SerializeField] bool isObstacleSoundActive;
    [SerializeField] int obstacleSelectedIndex;
    [SerializeField] List<AudioClip> obstacleSounds;


    [Title("Load Level Sounds")]
    [SerializeField] bool isLoadLevelSoundActive;
    [SerializeField] int loadLevelSelectedIndex;
    [SerializeField] List<AudioClip> loadLevelSounds;


    [Title("Tap To Play Sounds")]
    [SerializeField] bool isTapToPlaySoundActive;
    [SerializeField] int tapToPlaySelectedIndex;
    [SerializeField] List<AudioClip> tapToPlaySounds;

    [Title("Game Win Sounds")]
    [SerializeField] bool isGameWinSoundActive;
    [SerializeField] int gameWinSelectedIndex;
    [SerializeField] List<AudioClip> gameWinSounds;


    [Title("Game Lose Sounds")]
    [SerializeField] bool isGameLoseSoundActive;
    [SerializeField] int gameLoseSelectedIndex;
    [SerializeField] List<AudioClip> gameLoseSounds;



    private void OnEnable()
    {
        EventManager.Instance.OnCollectible += Collectible;
        EventManager.Instance.OnObstacle += Obstacle;
        EventManager.Instance.OnGameWin += GameWin;
        EventManager.Instance.OnGameLose += GameLose;
        EventManager.Instance.OnLoadLevel += LoadLevel;
        EventManager.Instance.OnTapToPlay += TapToPlay;
        EventManager.Instance.OnGainCoin += GainCoin;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnCollectible -= Collectible;
        EventManager.Instance.OnObstacle -= Obstacle;
        EventManager.Instance.OnGameWin -= GameWin;
        EventManager.Instance.OnGameLose -= GameLose;
        EventManager.Instance.OnLoadLevel -= LoadLevel;
        EventManager.Instance.OnTapToPlay -= TapToPlay;
        EventManager.Instance.OnGainCoin -= GainCoin;
    }


    private void Start()
    {
        if (isClickButtonSoundActive)
        {
            foreach (Button item in Resources.FindObjectsOfTypeAll<Button>())
            {
                item.onClick.AddListener(() => ButtonSound(item));
            }
        }

    }

    public void PlaySoundEffect(int audioSourceIndex, int otherAudioClipIndex)
    {
        audioSources[audioSourceIndex].PlayOneShot(otherAudioClips[otherAudioClipIndex]);
    }


    void ButtonSound(Button item)
    {
        audioSources[0].PlayOneShot(clickButtonSounds[cbsSelectedIndex], 0.1f);
    }

    void Collectible(int addedReward)
    {
        if (isCollectibleSoundActive)
        { 
            audioSources[1].PlayOneShot(collectibleSounds[collectibleSelectedIndex], 0.1f);
        }
    }

    void Obstacle()
    {
        if (isObstacleSoundActive)
        {

            audioSources[1].PlayOneShot(obstacleSounds[obstacleSelectedIndex], 1);
        }
    }

    void GameWin(int addedCoin)
    {
        if (isGameWinSoundActive)
        {
            audioSources[0].PlayOneShot(gameWinSounds[gameWinSelectedIndex], 1);
        }
    }

    void GameLose(int addedCoin)
    {
        if (isGameLoseSoundActive)
        {
            audioSources[0].PlayOneShot(gameLoseSounds[gameLoseSelectedIndex], 1);
        }
    }

    void LoadLevel()
    {
        if (isLoadLevelSoundActive)
        {
            audioSources[0].PlayOneShot(loadLevelSounds[loadLevelSelectedIndex], 1);
        }
    }

    void TapToPlay()
    {
        if (isTapToPlaySoundActive)
        {
            audioSources[0].PlayOneShot(tapToPlaySounds[tapToPlaySelectedIndex], 1);
        }
    }

    void GainCoin(int gainedCoin, Vector3 worldPos)
    {
        if (isCollectibleSoundActive)
        {
            audioSources[1].PlayOneShot(collectibleSounds[collectibleSelectedIndex], 0.051f);
        }
    }
}
