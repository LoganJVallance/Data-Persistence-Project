using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    [Header("Player Name")]
    [SerializeField] private string m_playerName = "";
    public TMP_InputField m_inputField;

    [Header("High Score")]
    public TextMeshProUGUI highScoreText;
    
    void Start()
    {
        m_inputField = GameObject.Find("PlayerNameInputField").GetComponent<TMP_InputField>();
        Debug.Log("You made it past line1");
        GameManager.Instance.LoadHighScore();
        highScoreText.text = "Best Score : " + GameManager.Instance.m_playername + " : " + GameManager.Instance.m_highScore;
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity Player
#endif
    } 

    public void InputPlayerName() // Save Player Name
    {
        m_playerName = m_inputField.text;
        Debug.Log(m_playerName);

        GameManager.Instance.m_cPlayerName = m_playerName;
    }
}
