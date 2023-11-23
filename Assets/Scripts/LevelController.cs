using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    int currentLevel = 0;
    int maxLevel;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        maxLevel = 10;
        DontDestroyOnLoad(gameObject);
        GetLevel();

    }
    public void GetLevel()
    {
        currentLevel = PlayerPrefs.GetInt("levelKey", 1);
        LoadLevel();
    }
    void LoadLevel()
    {
        string strLevel = "Level" + currentLevel;
        SceneManager.LoadScene(strLevel);
    }
    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel > maxLevel)
        {
            currentLevel = 1;
        }
        PlayerPrefs.SetInt("levelKey",currentLevel);
        LoadLevel() ;
    }
}
