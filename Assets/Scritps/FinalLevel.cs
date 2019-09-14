using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour
{
    // On destroy of last level load "Congratulations" scene
    private void OnDestroy()
    {
        SceneManager.LoadScene("Final Level Menu");
    }
}
