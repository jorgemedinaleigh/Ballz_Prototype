using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Wave 1";
    }

    public void IncreaseScore(int wave)
    {
        scoreText.text = ("Wave " + wave.ToString());

        Debug.Log("Wave " + wave);
    }
}
