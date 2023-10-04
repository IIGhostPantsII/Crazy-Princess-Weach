using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    Level1,
    Level2,
    Level3,
    Level4,
    Level5,
    Level6,
    Level7,
    Level8
}

public class LevelManager : MonoBehaviour
{
    [SerializeField] public Level _currentLevel;
    [SerializeField] public GameObject[] _levels;
    [SerializeField] public SoundManager _soundManager;

    void Start()
    {
        _currentLevel = (Level)(Globals.CurrentLevel);
        LoadLevel(_currentLevel);
        Globals.NoDeath();
    }

    void LoadLevel(Level level)
    {
        switch(level)
        {
            case Level.Level1:
                _levels[0].SetActive(true);
                _soundManager.PlayMusic(0);
                break;
            case Level.Level2:
                _levels[1].SetActive(true);
                _soundManager.PlayMusic(1);
                break;
            case Level.Level3:
                _levels[2].SetActive(true);
                _soundManager.PlayMusic(2);
                break;
            case Level.Level4:
                _levels[3].SetActive(true);
                _soundManager.PlayMusic(3);
                break;
            case Level.Level5:
                _levels[4].SetActive(true);
                _soundManager.PlayMusic(4);
                break;
            case Level.Level6:
                _levels[5].SetActive(true);
                _soundManager.PlayMusic(5);
                break;
            case Level.Level7:
                _levels[6].SetActive(true);
                _soundManager.PlayMusic(6);
                break;
            case Level.Level8:
                _levels[7].SetActive(true);
                _soundManager.PlayMusic(7);
                break;
            
            default:
                Debug.LogError("Error Unknown Level");
                break;
        }
    }

    public void NextLevel()
    {
        switch(_currentLevel)
        {
            case Level.Level1:
                _currentLevel = Level.Level2;
                break;
            case Level.Level2:
                _currentLevel = Level.Level3;
                break;
            case Level.Level3:
                Debug.Log("Win");
                break;
            default:
                Debug.LogError("Error Unknown Level");
                break;
        }

        LoadLevel(_currentLevel);
    }
}