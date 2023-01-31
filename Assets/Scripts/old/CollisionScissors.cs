using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScissors : MonoBehaviour
{
    public GameObject scissorsPrefab;
    public AudioSource scissorsSound;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "paper" && GameObject.FindGameObjectsWithTag("scissors").Length <= 15) {
            GameObject stone = Instantiate(scissorsPrefab, collision.transform.position, Quaternion.identity);
            scissorsSound.Play();
            Destroy(collision.gameObject);
        }
    }
}
