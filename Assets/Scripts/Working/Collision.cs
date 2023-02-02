using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public AudioSource sound;
    public string preyTag;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == preyTag) {
            if(gameObject != null) sound.Play();
            Destroy(collision.gameObject);
            if (Physics2D.OverlapAreaAll(new Vector2(-5.6f, 10f), new Vector2(5.6f, -10f)).Length < 30) {
                GameObject stone = Instantiate(gameObject, collision.transform.position, Quaternion.identity);
            } else {
                Debug.LogWarning("More than 30");
            }
            
        }
    }
}
