using UnityEngine;

public class RecognitionPlayer : MonoBehaviour
{
    public GameObject monsterUI;


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

    

}
