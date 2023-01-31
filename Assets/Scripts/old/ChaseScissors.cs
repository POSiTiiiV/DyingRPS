using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScissors : MonoBehaviour
{
    public float speed;
    private float mean;
    public float strength = 0.2f;

    private GameObject scissors;
    private GameObject[] allStone;
    private GameObject[] allScissors;
       
    void Update() {
        Vector2 startingPosition = this.transform.position;

        allScissors = GameObject.FindGameObjectsWithTag("scissors");
        allStone = GameObject.FindGameObjectsWithTag("stone");
        strength *= allStone.Length;
        scissors = Closest();
        if (scissors.transform.position == this.transform.position) {
            transform.position = startingPosition + Random.insideUnitCircle * 0.06f;
        } else {
            transform.position = Vector2.MoveTowards(transform.position, scissors.transform.position, mean * speed * Time.deltaTime * 0.2f) + Random.insideUnitCircle * 0.06f;
        }
    }

    GameObject Closest() {
        GameObject closest = gameObject;
        float leastDistance = Mathf.Infinity;
        float sum = 0;

        foreach (GameObject scissors in allScissors) {
            float newDistance = Vector3.Distance(transform.position, scissors.transform.position);
            sum = sum + newDistance;

            if (newDistance < leastDistance) {
                leastDistance = newDistance;
                closest = scissors;
            }
        }

        mean = sum / allScissors.Length;

        return closest;
    }
}
