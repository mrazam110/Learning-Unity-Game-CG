using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour {

    public void PlayGame() 
    {
        SceneManager.LoadScene("Game");
    }

    public void PlayInstructions() 
    {
        SceneManager.LoadScene("Instructions");
    }

    public void PlayMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
