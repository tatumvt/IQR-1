using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject buttonPanel;
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void LoadSceneScript(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OpenLevelCanvas(GameObject canvas)
    {
        canvas.SetActive(true);
    }

    public void SelectLevel(GameObject level)
    {
        level.SetActive(true);
        buttonPanel.SetActive(false);
    }

    public void BackTomain(GameObject level)
    {
        level.SetActive(false);
        buttonPanel.SetActive(true);
    }

    public void SettingsToggle(GameObject settingView)
    {
        settingView.SetActive(!settingView.activeSelf);
    }
}
