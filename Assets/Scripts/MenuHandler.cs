using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text bestScore;

    // Start is called before the first frame update
    void Start()
    {
        bestScore.text = $"Best Score : {GameManager.Instance.BestPlayerName} : {GameManager.Instance.BestScore}";
        inputField.text = GameManager.Instance.BestPlayerName;
    }

    public void StartNew()
    {
        GameManager.Instance.PlayerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
