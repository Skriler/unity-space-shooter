using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultMenu : MonoBehaviour
{
    public GameObject ScoreText;

    void Start()
    {
        ScoreText.GetComponent<Text>().text = ScoreController.Score.ToString();
    }

    public void StartGame()
    {
        ScoreController.ResetScore();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
