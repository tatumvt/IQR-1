using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    [SerializeField]
    private string Name;
    private void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(Name).ToString();
    }
}
