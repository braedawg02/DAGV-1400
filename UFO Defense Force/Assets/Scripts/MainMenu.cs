using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static bool isGameActive = false;
    public static GameObject Restart = null;
    public static GameObject Player = null;
    public static GameObject spawnManager = null;
    [SerializeField] public static GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        menu = GameObject.Find("Menu");
        Restart = GameObject.Find("Restart");
        spawnManager = GameObject.Find("SpawnManager");
        ScoreManager.score = 0;
        menu.SetActive(true);
        Restart.SetActive(false);
    }
    public static void StartGame()
    {

        isGameActive = true;
        menu.SetActive(false);
        Restart.SetActive(false);
    }
    public static void RestartGame()
    {
        isGameActive = true;
        Restart.SetActive(false);
        ScoreManager.score = 0;
        Player.transform.position = new Vector3(0, 0.5f, 0);
        Player.SetActive(true);
        Time.timeScale = 1;
    }
    public static void EndGame()
    {
        isGameActive = false;
        Time.timeScale = 0;
        Restart.SetActive(true);
    }
    public static void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
}
