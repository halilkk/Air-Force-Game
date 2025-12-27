using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoretext;
    int score = 0;
    public void UpdateScore(int value)
    {
        score += value;
        scoretext.text = score.ToString();
    }
}
