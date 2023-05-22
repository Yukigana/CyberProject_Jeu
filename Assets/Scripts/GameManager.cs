using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *  Permet de faire passer des informations de scene en scene 
 */
public class GameManager : MonoBehaviour
{
    public static Champion player1, player2;
    public static GameManager instance { private set; get; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void changeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
