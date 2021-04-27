using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    //Level canvas
    public GameObject levelsPanel;

    //Makes sure the time is at 1
    private void Start()
    {
        Time.timeScale = 1;
    }

    //Actual load on play button
    public void LoadSceneScript(string name)
    {
        SceneManager.LoadScene(name);
    }

    //Opens levels
    public void OpenLevelCanvas(GameObject canvas)
    {
        canvas.SetActive(true);
    }

    //Level Preview to open
    public void SelectLevel(GameObject level)
    {
        level.SetActive(true);
        levelsPanel.SetActive(false);
    }

    //Back To main level
    public void BackTomain(GameObject level)
    {
        level.SetActive(false);
        levelsPanel.SetActive(true);
    }

    //Toggles Settings menu
    public void SettingsToggle(GameObject settingView)
    {
        settingView.SetActive(!settingView.activeSelf);
    }
}
