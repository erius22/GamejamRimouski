using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainMenuController : MonoBehaviour
{
    public GameObject creditMenu;
    public GameObject mainMenu;
    public EventSystem eventSystem;
    public GameObject returnButton;
    public GameObject playButton;

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
    public void Credits()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(returnButton);
    }
    public void backToMainMenu() 
    {
        creditMenu.SetActive(false);
        mainMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(playButton);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
