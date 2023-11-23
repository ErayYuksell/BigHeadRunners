using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject StartMenuPanel;
    [SerializeField] GameObject SuccessPanel;
    GameObject playerObject;
    PlayerController playerScript;
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
    }

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerObject.GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void StartButtonTapped()
    {
        StartMenuPanel.SetActive(false);
        playerScript.GameStart();
    }
    public void NextlevelButtonTapped()
    {
        SuccessPanel.SetActive(false);
        LevelController.Instance.NextLevel();
    }
    public void ShowSuccessMenu()
    {
        SuccessPanel.SetActive(true);
    }
}
