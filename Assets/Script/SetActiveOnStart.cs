﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnStart : MonoBehaviour
{
    [SerializeField]
    private bool Bool;

    private void Start()
    {
        this.gameObject.SetActive(Bool);
    }
}
