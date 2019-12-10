using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    public Text UIPlayerScore;
    public Text UIPlayerMultiplier;
    public static float playerScore;
    public static float playerMultiplier;
    public static int playerKillCount;
    void Start()
    {
        print("Started Score Keeping");
        playerScore = 0;
        playerMultiplier = 1;
        playerKillCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UIPlayerScore.text = "Score = " + playerScore;
        UIPlayerMultiplier.text = "Multiplier = " + playerMultiplier + "x";

        if (playerKillCount >= 1)
        {
            MultiplierBoost();
        }
    }

    private void MultiplierBoost()
    {
        playerKillCount = 0;
        playerMultiplier += 0.1f;
    }
}
