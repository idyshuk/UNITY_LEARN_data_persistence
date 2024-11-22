using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button startButton;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            try
            {
                SceneManager.LoadScene(1);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
            return;
        }
        
        startButton.onClick.AddListener(() =>
        {
            string playerName = string.IsNullOrEmpty(inputField.text) ? "NONAME" : inputField.text;

            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.Save();

            SceneManager.LoadScene(1);
        });
    }
}