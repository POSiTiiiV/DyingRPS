using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] objectPrefab;
    public float minX, maxX;
    public float minY, maxY;

    void Start() {
        StartCoroutine(ObjectSpawn());
    }

    IEnumerator ObjectSpawn() {

        foreach (GameObject prefab in objectPrefab) {
            for(int j=0; j<5; j++) {
                Vector2 pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                var collisions = Physics.OverlapSphere(pos, 3);
                while (collisions.Length > 0) {
                    pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    collisions = Physics.OverlapSphere(pos, 3);
                }
                GameObject gobject = Instantiate(prefab, pos, Quaternion.identity);
            }
        }
        yield return new WaitForSecondsRealtime(5);
    }
}