using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource As;
    public float timedestroy = 1.0f;


    public  AudioClip Click;
    public float Vollum = 0.5f;



    // Start is called before the first frame update
    void Awake()
    {
        As = gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);


    }
    public void Start()
    {
        ChangeVall();
    }
    public void ChangeVall()
    {
        if (PlayerPrefs.HasKey("VollApl"))

        {
            Vollum = PlayerPrefs.GetFloat("VollApl");

        }

        As.volume = Vollum;
    }

    public void OnDestCheck()
    {
        StartCoroutine(destAu());
    }
    public IEnumerator destAu()
    {
        
        yield return new WaitForSeconds(timedestroy);
        
        Destroy(this.gameObject);
    
    }

    public  void PlayClick()
    {
        As.PlayOneShot(Click);
    }









    

       
    
}
