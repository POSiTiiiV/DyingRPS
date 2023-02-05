using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private string preyTag;

    // for boundaries
    private Vector2 screenBounds;

    void Start() {
        // to find the screen size
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == preyTag) {
            if(gameObject != null) sound.Play(); // to ensure that sound we are going to play isnt destroyed/disabled(sound is a child object of the any rps)(this isnt working properly cause we still get error) 
            Destroy(collision.gameObject);
            // this ensure that if more than one object is in collison with their prey then both of then dont create a new object
            if (Physics2D.OverlapAreaAll(new Vector2(-screenBounds.x, screenBounds.y), new Vector2(screenBounds.x, -screenBounds.y)).Length < Spawn.spawn.size * 3) {
                GameObject stone = Instantiate(gameObject, collision.transform.position, Quaternion.identity);
            } else {
                Debug.LogWarning("More than " + Spawn.spawn.size * 3);
            }
            
        }
    }
}
