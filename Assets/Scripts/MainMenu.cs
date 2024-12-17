using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Description()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Day()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void Sunset()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void Night()
    {
        SceneManager.LoadSceneAsync(5);
    }

}
