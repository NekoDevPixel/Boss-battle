using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecognitionPlayer : MonoBehaviour
{
    public GameObject monsterUI;
    public GameObject monster;


    void Start()
    {
        monsterUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered detection range");
            monsterUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player exited detection range");
            monsterUI.SetActive(false);
        }
    }

    void Update()
    {
        if (GameManager.Instance.monsterHealth <= 0)
        {
            StartCoroutine(Stoptime());
        }
    }

    IEnumerator Stoptime()
    {
        yield return new WaitForSeconds(0.3f);
        monster.SetActive(false);
        monsterUI.SetActive(false);
    }

}
