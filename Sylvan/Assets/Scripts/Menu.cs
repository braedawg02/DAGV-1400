using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string sceneName;
    public void StartGame()
    {
        Debug.Log("Start Game");
        StartCoroutine(LoadGameASYNC());
        
    }
    IEnumerator LoadGameASYNC()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

      while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }   

}
