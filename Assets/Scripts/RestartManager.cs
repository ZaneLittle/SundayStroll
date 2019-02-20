using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public Button restartButton;

    private void resetGame()
    {
        Debug.Log("Resetting scene.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        restartButton.interactable = false;
        restartButton.onClick.AddListener(() => resetGame());
    }
}
