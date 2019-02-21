using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    private bool transitioning;

    public Button restartButton;

    private IEnumerator resetScene()
    {
        transitioning = true; // Lock corountine from multiple instances
        Debug.Log("Resetting scene.");

        AsyncOperation resetAsync = SceneManager
            .LoadSceneAsync(
                SceneManager.GetActiveScene().name
            );

        yield return resetAsync;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && !transitioning)
        {
            StartCoroutine(resetScene());
        }
    }

    private void Start()
    {
        transitioning = false;
        restartButton.interactable = false;
        restartButton.onClick.AddListener(() =>
        {
            StartCoroutine(resetScene());
        });
    }
}
