using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static Spawn spawn;

    [SerializeField] private GameObject[] objectPrefab;
    [SerializeField] private float minX, maxX;
    [SerializeField] private float minY, maxY;
    public int size = 15;

    void Start() {
        // since there are multiple objects thant will have Spawn sript, so to make sure only one of them should have spawn object 
        if (spawn != null && spawn != this) Destroy(this);
        else spawn = this;

        StartCoroutine(ObjectSpawn());
    }

    IEnumerator ObjectSpawn() {

        foreach (GameObject prefab in objectPrefab) {
            for(int j=0; j<size; j++) {
                Vector2 pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                Collider2D collision = Physics2D.OverlapCircle(pos, 1f); // checks if that pos is already occupied
                while (collision != null) { // if occupied run while loop till u find a empty space
                    pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    collision = Physics2D.OverlapCircle(pos, 1f);
                }
                Instantiate(prefab, pos, Quaternion.identity); // instantiate object once empty pos is find
            }
        }
        yield return new WaitForSecondsRealtime(1); // this does nothing, idk why we have to use StartCoroutine for this function(StartCoroutine requires yield return)
    }
}