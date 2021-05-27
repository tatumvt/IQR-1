using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public ButtonClick bc;
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
        Time.timeScale = 1;
        bc.buttonClick();
        StartCoroutine(LoadSceneScriptIE(name));
    }
    private IEnumerator LoadSceneScriptIE(string name)
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(name);
    }

    //Opens levels
    public void OpenLevelCanvas(GameObject canvas)
    {
        Time.timeScale = 1;
        bc.buttonClick();
        canvas.SetActive(true);
    }

    //Level Preview to open
    public void SelectLevel(GameObject level)
    {
        Time.timeScale = 1;
        bc.buttonClick();
        level.SetActive(true);
        levelsPanel.SetActive(false);
    }

    //Back To main level
    public void BackTomain(GameObject level)
    {
        Time.timeScale = 1;
        bc.buttonClick();
        level.SetActive(false);
        levelsPanel.SetActive(true);
    }

    //Toggles Settings menu
    public void SettingsToggle(GameObject settingView)
    {
        Time.timeScale = 1;
        bc.buttonClick();
        settingView.SetActive(!settingView.activeSelf);
    }
}
