using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSpawner : MonoBehaviour
{
    public GameObject[] leafPrefabs;
    public float minDistance = 5f;
    public float maxDistance = 10f;
    public float interval = 5f;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f); // wait for 5 seconds
        while (true)
        {
            Vector3 delta = new Vector3(Random.Range(-7, 7), 2);
            int randomIndex = Random.Range(0, leafPrefabs.Length);
            Instantiate(leafPrefabs[randomIndex], delta, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }
}
