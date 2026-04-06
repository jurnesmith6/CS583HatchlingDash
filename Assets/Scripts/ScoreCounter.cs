using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    

    private TextMeshProUGUI uiText;

    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        
    }
    
    

    public void updateScore(int score)
    {
        uiText.text = "Level: " + score.ToString("#,0");
    }
}