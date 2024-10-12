using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_Text BestScoreText;

    private void Start()
    {
        GameManager.Instance.LoadNameAndBestScore();
        UpdateBestScoreText();
    }

    public void SubmitName()
    {
        GameManager.Instance.SetPlayerName(nameInputField.text);
        Debug.Log("Player Name: " + GameManager.Instance.GetPlayerName());
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void UpdateBestScoreText()
    {
        BestScoreText.text = $"Best Score: {GameManager.Instance.GetBestPlayerName()} : {GameManager.Instance.GetBestScore()}";
    }
}
