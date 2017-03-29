using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Button start;
    public Button Main;
    public Button Exit;
    

	// Use this for initialization
	void Start ()
    {
        start = start.GetComponent<Button>();
        Main = Main.GetComponent<Button>();
        Exit = Exit.GetComponent<Button>();

        Cursor.visible = enabled;
        
	}
	
	// Update is called once per frame
	void Update () {}

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

  
}
