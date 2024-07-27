using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    void Update()
    {
        scoreText.text = "Score: " + Score.PlayerScore;
    }

}
