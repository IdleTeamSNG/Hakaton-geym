using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimScr : MonoBehaviour
{
    public GameObject targ;
    public float t;
    private Animator anim;
    public IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(t);
        anim.SetBool("Start", true);

    }
    // Start is called before the first frame update
    void Start()
    {
        anim = targ.GetComponent<Animator>();
        StartCoroutine(StartAnim());

    }
    public void OnClick()
    {
        anim.SetBool("Click", true);
    }
}
