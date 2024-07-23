using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bot;
    public Transform spawnPoint;
    public float spawnInterval = 3f;

    private bool isPlayerOnTile = false;

    private Coroutine spawnCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnTile = true;
            spawnCoroutine = StartCoroutine(Spawn());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnTile = false;
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    private IEnumerator Spawn()
    {
        while (isPlayerOnTile)
        {
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(bot, spawnPoint.position, Quaternion.identity);
        }
    }

}
