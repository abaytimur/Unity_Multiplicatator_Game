using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private GameObject soundPanel;
    
    private bool _soundPanelOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        _soundPanelOpen = false;
        
        soundPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, -11.8f, 0);
        menuPanel.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1f, 1.5f).SetEase(Ease.OutBounce);
    }

    public void PlayTheGame()
    {
        if (PlayerPrefs.GetInt("SoundMute") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        SceneManager.LoadScene("MenuLevel2");
    }

    public void Settings()
    {
        if (PlayerPrefs.GetInt("SoundMute") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        if (!_soundPanelOpen)
        {
            soundPanel.GetComponent<RectTransform>().DOLocalMoveX(155, 0.5f);
            _soundPanelOpen = true;
        }
        else
        {
            soundPanel.GetComponent<RectTransform>().DOLocalMoveX(0, 0.5f);
            _soundPanelOpen = false;
        }
    }

    public void QuitGame()
    {
        if (PlayerPrefs.GetInt("SoundMute") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        Application.Quit();
    }
}
