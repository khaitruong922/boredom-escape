#pragma warning disable 0649

using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    private bool isPausing = false;
    [SerializeField]
    private GameObject pauseLayer;
    [SerializeField]
    private Image pauseImage;
    [SerializeField]
    private Sprite pauseSprite;
    [SerializeField]
    private Sprite resumeSprite;
    private void Start()
    {
        Resume();
    }
    public void SwitchState()
    {
        if (isPausing)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Pause()
    {

        isPausing = true;
        pauseImage.sprite = resumeSprite;
        pauseLayer.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        isPausing = false;
        pauseImage.sprite = pauseSprite;
        pauseLayer.SetActive(false);
        Time.timeScale = 1f;
    }
}

