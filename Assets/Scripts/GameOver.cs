using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void StartButton(){
        SceneManager.LoadScene("Principal");
    }

        public void CancelButton(){
        Application.Quit();
    }
}
