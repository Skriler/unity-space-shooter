using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject HealthText;
    public GameObject ScoreText;

    void Start()
    { }

    void Update()
    {
        HealthText.GetComponent<Text>().text = "Health: " + Player.GetComponent<PlayerHealthController>().HP.ToString();
        ScoreText.GetComponent<Text>().text = "Score: " + ScoreController.Score.ToString();
    }
}
