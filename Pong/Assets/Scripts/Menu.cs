using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject _controls;
    public GameObject _menu;
    // Start is called before the first frame update
    void Start()
    {
        _controls.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void activateControls()
    {
        _controls.SetActive(true);
        _menu.SetActive(false);
    }
    public void deactivateControls()
    {
        _controls.SetActive(false);
        _menu.SetActive(true);  
    }
    public void Quit()
    {
        Application.Quit();
    }

}
