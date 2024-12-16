using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Count : MonoBehaviour
{
    
    
    [SerializeField] TextMeshProUGUI total_Score;
    [SerializeField] TextMeshProUGUI Distance;
    [SerializeField] public Transform Player;

    void Start()
    {
        // Reset the saved score to 0 when the game starts
        PlayerPrefs.SetInt("total_coins", 0);
        PlayerPrefs.Save();

        // Update the TextMeshPro text to reflect the reset score
        total_Score.text = PlayerPrefs.GetInt("total_coins", 0).ToString("00");
    }

    void Update()
    {
        // Continuously display the score from PlayerPrefs
        total_Score.text = PlayerPrefs.GetInt("total_coins", 0).ToString("00");
        Distance.text = Player.transform.position.z.ToString("00.0") + "m";

        if(Player.transform.position.z >= PlayerPrefs.GetFloat("high_score",0f))
        {
            PlayerPrefs.SetFloat("high_score", Player.transform.position.z);
        }
    }
}
 
