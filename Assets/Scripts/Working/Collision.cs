using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public AudioSource sound;
    public string preyTag;

    // for boundaries
    private Vector2 screenBounds;

    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == preyTag) {
            if(gameObject != null) sound.Play();
            Destroy(collision.gameObject);
            if (Physics2D.OverlapAreaAll(new Vector2(-screenBounds.x, screenBounds.y), new Vector2(screenBounds.x, -screenBounds.y)).Length < Spawn.spawn.size * 3) {
                GameObject stone = Instantiate(gameObject, collision.transform.position, Quaternion.identity);
            } else {
                Debug.LogWarning("More than " + Spawn.spawn.size * 3);
            }
            
        }
    }
}
