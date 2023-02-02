using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public string preyTag;
    [Range(0f, 1f)]
    public float speed = 1;
    [Range(1f, 50f)]
    public float strength;

    private GameObject prey;
    private float mean;
    private GameObject[] allEnemies;
    private GameObject[] allAllies;

    void Update() {
        Vector2 startingPosition = transform.position;

        allEnemies = GameObject.FindGameObjectsWithTag(preyTag);
        allAllies = GameObject.FindGameObjectsWithTag(this.tag);
        prey = Closest();
        if (prey.transform.position == transform.position) {
            transform.position = startingPosition + Random.insideUnitCircle * 0.04f;
        } else {
            transform.position = Vector2.MoveTowards(transform.position, prey.transform.position, speed * Time.deltaTime) + Random.insideUnitCircle * 0.04f;
            // transform.position = Vector2.MoveTowards(transform.position, prey.transform.position, speed * Time.deltaTime);
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