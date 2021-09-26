using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    private const string MainMenu = "VSTUPLENIE";
    private const string HubScene = "UROVNI";

    public static void NavigateMain()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public static void NavigateHub()
    {
        SceneManager.LoadScene(HubScene);
    }
}
