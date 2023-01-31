using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour {
    public GameObject Countdown;

    void Start() {
        Time.timeScale = 0;
        StartCoroutine(Sleep());
    }

    IEnumerator Sleep() {
        yield return new WaitForSecondsRealtime(5);
        Countdown.SetActive(false);
        Time.timeScale = 1;
    }
}
