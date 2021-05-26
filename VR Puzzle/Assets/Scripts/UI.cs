using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() //The UI in the games menu is implemented for replayability if the users wishes to.
    {
        Application.Quit();
    }
}
