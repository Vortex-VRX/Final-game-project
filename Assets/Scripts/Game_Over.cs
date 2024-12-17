using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI best_score_text;

    Transform Player;

    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        
        score_text.text = Player.transform.position.z.ToString("00.0") + "m";
        best_score_text.text = PlayerPrefs.GetFloat("high_score", 0).ToString("00.0") + "m";
    }

    public void Restart_Button()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
