using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePaper : MonoBehaviour
{
    public float speed;
    private float mean;
    public float strength = 0.2f;

    private GameObject paper;
    private GameObject[] allScissors;
    private GameObject[] allPaper;
       
    void Update() {
        Vector2 startingPosition = this.transform.position;

        allPaper = GameObject.FindGameObjectsWithTag("paper");
        allScissors = GameObject.FindGameObjectsWithTag("scissors");
        strength *= allScissors.Length;
        paper = Closest();
        if (paper.transform.position == this.transform.position) {
            transform.position = startingPosition + Random.insideUnitCircle * 0.06f;
        } else {
            transform.position = Vector2.MoveTowards(transform.position, paper.transform.position, mean * speed * Time.deltaTime * 0.2f) + Random.insideUnitCircle * 0.06f;
        }
    }

    GameObject Closest() {
        GameObject closest = gameObject;
        float leastDistance = Mathf.Infinity;
        float sum = 0;

        foreach (GameObject paper in allPaper) {
            float newDistance = Vector3.Distance(transform.position, paper.transform.position);
            sum = sum + newDistance;

            if (newDistance < leastDistance) {
                leastDistance = newDistance;
                closest = paper;
            }
        }

        mean = sum / allPaper.Length;

        return closest;
    }
}
