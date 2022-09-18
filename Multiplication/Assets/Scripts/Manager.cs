using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void repeatRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
