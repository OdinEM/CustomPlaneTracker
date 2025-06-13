using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject[] scenes;
    private int currentSceneIndex = 0;

    void Start()
    {
        ShowScene(0);
    }

    public void NextScene()
    {
        scenes[currentSceneIndex].SetActive(false);
        currentSceneIndex++;
        if (currentSceneIndex >= scenes.Length)
            currentSceneIndex = 0;
        scenes[currentSceneIndex].SetActive(true);
    }

    public void PreviousScene()
    {
        scenes[currentSceneIndex].SetActive(false);
        currentSceneIndex--;
        if (currentSceneIndex < 0)
            currentSceneIndex = scenes.Length - 1;
        scenes[currentSceneIndex].SetActive(true);
    }

    private void ShowScene(int index)
    {
        for (int i = 0; i < scenes.Length; i++)
            scenes[i].SetActive(i == index);
    }
}
