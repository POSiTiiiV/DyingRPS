using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public string preyTag;
    public float speed = 1;

    private GameObject prey;
    private float strength = 2f;
    private float mean;
    private GameObject[] allEnemies;
    private GameObject[] allAllies;

    void Update() {
        Vector2 startingPosition = transform.position;

        allEnemies = GameObject.FindGameObjectsWithTag(preyTag);
        allAllies = GameObject.FindGameObjectsWithTag(this.tag);
        // strength *= allAllies.Length;
        prey = Closest();
        if (prey.transform.position == transform.position) {
            transform.position = startingPosition + Random.insideUnitCircle * 0.04f;
        } else {
            transform.position = Vector2.MoveTowards(transform.position, prey.transform.position, mean * speed * Time.deltaTime / strength) + Random.insideUnitCircle * 0.04f;
        }
    }

    GameObject Closest() {
        GameObject closest = gameObject;
        float leastDistance = Mathf.Infinity;
        float sum = 0;

        foreach (GameObject prey in allEnemies) {
            float newDistance = Vector3.Distance(transform.position, prey.transform.position);
            sum += newDistance;

            if (newDistance < leastDistance) {
                leastDistance = newDistance;
                closest = prey;
            }
        }

        mean = sum / allEnemies.Length;

        return closest;
    }
}