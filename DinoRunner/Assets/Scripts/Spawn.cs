using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject cactusPrefab;

    [SerializeField] private float intervalToSpawn;

    void Start()
    {
        StartCoroutine(SpawnCactus(intervalToSpawn));
    }

    IEnumerator SpawnCactus(float t)
    {
        while (true)
        {
            yield return new WaitForSeconds(t);

            GameObject cactus = Instantiate(cactusPrefab);

            cactus.transform.position = transform.position;

            StartCoroutine(SpawnCactus(t));
        }
    }
}
