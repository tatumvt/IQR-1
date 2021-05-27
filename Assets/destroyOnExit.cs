using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnExit : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject);
    }
}
