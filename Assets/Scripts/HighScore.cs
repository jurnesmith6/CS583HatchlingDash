using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    static  private TextMeshProUGUI _UI_TEXT;

    static private int _SCORE = 0;

    private TextMeshProUGUI  txtCom;

    void Awake()
    {
        _UI_TEXT = GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("HighLevel"))
        {
            SCORE = PlayerPrefs.GetInt("HighLevel");
            
        }
        PlayerPrefs.SetInt("HighLevel", SCORE);
    }
    

    static public int SCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighLevel", value);
            if (_UI_TEXT !=  null)
                
            {
                _UI_TEXT.text = "High Score: L" + value.ToString("#,0");
                
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreTry)
    {
        if (scoreTry <= SCORE) return;

        SCORE = scoreTry;
    }
    

}