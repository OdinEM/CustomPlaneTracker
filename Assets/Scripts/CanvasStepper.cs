using UnityEngine;

public class CanvasStepper : MonoBehaviour
{
    public GameObject[] canvases;
    private int currentIndex = 0;

    public void ShowNextCanvas()
    {
        if (currentIndex < canvases.Length - 1)
        {
            canvases[currentIndex].SetActive(false);
            currentIndex++;
            canvases[currentIndex].SetActive(true);
        }
    }

    public void ShowPreviousCanvas()
    {
        if (currentIndex > 0)
        {
            canvases[currentIndex].SetActive(false);
            currentIndex--;
            canvases[currentIndex].SetActive(true);
        }
    }
}
