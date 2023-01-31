using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStone : MonoBehaviour
{   
    public GameObject stonePrefab;
    public AudioSource stoneSound;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "scissors" && GameObject.FindGameObjectsWithTag("stone").Length <= 15) {
            GameObject stone = Instantiate(stonePrefab, collision.transform.position, Quaternion.identity);
            stoneSound.Play();
            Destroy(collision.gameObject);
        }
    }
}
