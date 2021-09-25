using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTomenu : MonoBehaviour
{
    public void OnBackClic()
    {
        SceneManager.LoadScene("VSTUPLENIE");
    }
}
