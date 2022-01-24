using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource As;
    public float timedestroy = 1.0f;


    public  AudioClip Click;



    // Start is called before the first frame update
    void Start()
    {
        As = gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);

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
