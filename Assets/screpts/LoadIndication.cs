using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadIndication : MonoBehaviour
{
    public string SceneName;
    private readonly string[] Hints = new string[] //��������� �� ����� ��������
    {
        "���� ����� ������ ������, ����� �� ������.",
        "����� ������ � ������� ����� ��� ���� �������.",
        "���� ������� ����� ������, �� ��� �������!",
    };
    public Text ProgressText, HintText;
    public Image ProgressImage;

    private void Start()
    {
        StartCoroutine(LoadingFunction());
        HintText.text = Hints[Random.Range(0, Hints.Length)]; //���������� ��������� ���������
    }

    IEnumerator LoadingFunction()
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(SceneName);
        while (!Operation.isDone)
        {
            float Progress = Operation.progress;
            ProgressText.text = $"{(Progress * 100).ToString("0")}%"; //������� ��������
            ProgressImage.fillAmount = Progress;
            yield return null;
        }
    }
}