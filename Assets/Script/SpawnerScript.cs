using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] protected float spawnEvery = 5f;
    public GameObject spawnPrefab;

    private void Start()
    {
        StartCoroutine("SpawnRoutine");
        GameObject go = GameObject.Instantiate(spawnPrefab);
        go.transform.position = this.transform.position;
    }

    protected virtual IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnEvery);
            GameObject go = GameObject.Instantiate(spawnPrefab);
            go.transform.position = this.transform.position;
        }
    }
}
