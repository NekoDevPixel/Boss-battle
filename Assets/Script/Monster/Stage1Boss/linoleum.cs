using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class linoleum : MonoBehaviour
{
    private DOTweenAnimation linoAnime;
    public bool isanime = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        linoAnime = GetComponent<DOTweenAnimation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isanime == false)
        {
            isPlayerAnime();
        }
        
        if (!isanime)
        {
            PlayLinoAnime();
        }
    }

    

    public void PlayLinoAnime()
    {
        linoAnime.DOPlay();
    }
    public void StopLinoAnime()
    {
        linoAnime.DOKill();
        linoAnime.DORewind();
        
    }

    public void isPlayerAnime()
    {
        if (linoAnime != null && linoAnime.tween != null)
        {
            if (!linoAnime.tween.IsPlaying() && linoAnime.tween.IsComplete())
            {
                Debug.Log("끝");
                isanime = true;
                StopLinoAnime();
            }
        }
    }
}


