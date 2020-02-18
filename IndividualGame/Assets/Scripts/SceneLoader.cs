using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Maze");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Maze");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void StartScreen()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

}
