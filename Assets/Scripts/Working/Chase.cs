using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chase : MonoBehaviour
{
    public string preyTag;
    public string enemyTag;
    [Range(0f, 1f)]
    public float speed = 1;

    private GameObject prey;
    private GameObject enemy;
    private float mean;
    private float strength;
    private GameObject[] allPreys;
    private GameObject[] allAllies;
    private GameObject[] allEnemies;

    // for boundaries
    private Vector2 screenBounds;
    private float objectHeight;
    private float objectWidth;

    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    void Update() {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth), 
        Mathf.Clamp(transform.position.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight));
        Vector2 startingPosition = transform.position;

        allPreys = GameObject.FindGameObjectsWithTag(preyTag);
        allAllies = GameObject.FindGameObjectsWithTag(this.tag);
        allEnemies = GameObject.FindGameObjectsWithTag(enemyTag);

        if (allAllies.Length >= 45) StartCoroutine(ReloadScene());

        prey = Closest(allPreys);

        strength = (allAllies.Length / 5) * 0.1f;
        if (allAllies.Length < 15) speed += strength;
        else speed -= strength;

        if (speed < 0.7f) speed = 0.7f;
        else if (speed > 1.7f) speed = 1.7f;

        if (allAllies.Length + allPreys.Length >= 45) speed = 1.7f;

        if (prey.transform.position == transform.position) {
            transform.position = startingPosition + Random.insideUnitCircle * 0.02f;
        } else {
            transform.position = Vector2.MoveTowards(transform.position, prey.transform.position, speed * Time.deltaTime) + Random.insideUnitCircle * 0.02f;
        }

        enemy = Closest(allEnemies);
        if (enemy.transform.position != transform.position && Vector3.Distance(transform.position, enemy.transform.position) < 2f) {
            transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, -(0.5f) * Time.deltaTime) + Random.insideUnitCircle * 0.02f;
        }
    }

    GameObject Closest(GameObject[] list) {
        GameObject closest = gameObject;
        float leastDistance = Mathf.Infinity;
        float sum = 0;

        foreach (GameObject obj in list) {
            float newDistance = Vector3.Distance(transform.position, obj.transform.position);
            sum += newDistance;

            if (newDistance < leastDistance) {
                leastDistance = newDistance;
                closest = obj;
            }
        }

        mean = sum / allEnemies.Length;

        return closest;
    }

    IEnumerator ReloadScene() {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}