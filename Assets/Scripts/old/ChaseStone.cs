using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStone : MonoBehaviour
{
    public float speed;
    private float mean;
    public float strength = 0.2f;

    private GameObject stone;
    private GameObject[] allPaper;
    private GameObject[] allStone;
       
    void Update() {
        Vector2 startingPosition = this.transform.position;

        allStone = GameObject.FindGameObjectsWithTag("stone");
        allPaper = GameObject.FindGameObjectsWithTag("paper");
        strength *= allPaper.Length;
        stone = Closest();
        if (stone.transform.position == this.transform.position) {
            transform.position = startingPosition + Random.insideUnitCircle * 0.06f;
        } else {
            transform.position = Vector2.MoveTowards(transform.position, stone.transform.position, mean * speed * Time.deltaTime * strength) + Random.insideUnitCircle * 0.06f;
        }
    }

    GameObject Closest() {
        GameObject closest = gameObject;
        float leastDistance = Mathf.Infinity;
        float sum = 0;

        foreach (GameObject stone in allStone) {
            float newDistance = Vector3.Distance(transform.position, stone.transform.position);
            sum = sum + newDistance;

            if (newDistance < leastDistance) {
                leastDistance = newDistance;
                closest = stone;
            }
        }

        mean = sum / allStone.Length;

        return closest;
    }
}
