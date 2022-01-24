using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadIndication : MonoBehaviour
{
    public string SceneName;
    private readonly string[] Hints = new string[] //Подсказки во время загрузки
    {
        "Ваша жизнь длится дольше, когда вы дышите.",
        "Почти всегда в третьем этаже пол ниже потолка.",
        "Если мужчине зовут Наташа, то это женщина!",
    };
    public Text ProgressText, HintText;
    public Image ProgressImage;

    private void Start()
    {
        StartCoroutine(LoadingFunction());
        HintText.text = Hints[Random.Range(0, Hints.Length)]; //Показываем случайную подсказку
    }

    IEnumerator LoadingFunction()
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(SceneName);
        while (!Operation.isDone)
        {
            float Progress = Operation.progress;
            ProgressText.text = $"{(Progress * 100).ToString("0")}%"; //Процент загрузки
            ProgressImage.fillAmount = Progress;
            yield return null;
        }
    }
}