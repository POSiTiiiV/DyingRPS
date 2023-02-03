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
            for(int j=0; j<15; j++) {
                Vector2 pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                Collider2D collision = Physics2D.OverlapCircle(pos, 1f);
                while (collision != null) {
                    pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    collision = Physics2D.OverlapCircle(pos, 1f);
                }
                GameObject gobject = Instantiate(prefab, pos, Quaternion.identity);
            }
        }
        yield return new WaitForSecondsRealtime(5);
    }
}