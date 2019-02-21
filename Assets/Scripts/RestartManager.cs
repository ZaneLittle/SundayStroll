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
        // Lock corountine from multiple instances and log action
        transitioning = true; 
        Debug.Log("Resetting scene.");

        AsyncOperation resetAsync = SceneManager.LoadSceneAsync
        (
            SceneManager.GetActiveScene().name
        );

        yield return resetAsync;
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
