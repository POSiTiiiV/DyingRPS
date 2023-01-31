using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public AudioSource sound;
    public string preyTag;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == preyTag && GameObject.FindGameObjectsWithTag(gameObject.tag).Length <= 15) {
            GameObject stone = Instantiate(gameObject, collision.transform.position, Quaternion.identity);
            sound.Play();
            Destroy(collision.gameObject);
        }
    }
}
