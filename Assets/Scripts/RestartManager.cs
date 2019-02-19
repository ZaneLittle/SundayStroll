using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    // TODO: Doesnt work with UI Text
    private void OnMouseUp()
    {
        Debug.Log("Resetting scene.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
