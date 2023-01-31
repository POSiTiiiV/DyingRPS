using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPaper : MonoBehaviour
{
    public GameObject paperPrefab;
    public AudioSource paperSound;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "stone" && GameObject.FindGameObjectsWithTag("paper").Length <= 15) {
            GameObject stone = Instantiate(paperPrefab, collision.transform.position, Quaternion.identity);
            paperSound.Play();
            Destroy(collision.gameObject);
        }
    }
}
