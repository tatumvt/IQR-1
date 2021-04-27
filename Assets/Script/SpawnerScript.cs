using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    //Time to spawn enemies
    [SerializeField] private float spawnEvery = 5f;
    //Object to spawn
    public GameObject spawnPrefab;

    private void Start()
    {
        StartCoroutine("SpawnRoutine");
        GameObject go = GameObject.Instantiate(spawnPrefab);
        go.transform.position = this.transform.position;
    }

    //Spawn object at spawner position every few seconds asigned
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
