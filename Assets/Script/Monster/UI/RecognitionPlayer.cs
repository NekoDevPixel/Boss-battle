using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RecognitionPlayer : MonoBehaviour
{
    public GameObject monsterUI;
    public GameObject monster;
    DOTweenAnimation UpHPbar;


    void Start()
    {
        monsterUI.SetActive(false);
        UpHPbar = monsterUI.GetComponent<DOTweenAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered detection range");
            UpHPbar.DOPlay();
            monsterUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player exited detection range");
            UpHPbar.DORewind();
            monsterUI.SetActive(false);
        }
    }

    void Update()
    {
        if (BossIFM.Instance.monsterHealth <= 0)
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
