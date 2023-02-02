using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public AudioSource sound;
    public string preyTag;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == preyTag) {
            sound.Play();
            GameObject stone = Instantiate(gameObject, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
