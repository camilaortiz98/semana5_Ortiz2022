using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textSilver;
    public TextMeshProUGUI textBronze;
    int score;
    int silverScore;
    int bronzeScore;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = ":" + score.ToString();
    }
    
    public void ChangeSilverScore(int coinSValue)
    {
        silverScore += coinSValue;
        textSilver.text = ":" + silverScore.ToString();
    }

    public void ChangeBronzeScore (int coinBValue)
    {
        bronzeScore += coinBValue;
        textBronze.text = ":" + bronzeScore.ToString();
    }

}
