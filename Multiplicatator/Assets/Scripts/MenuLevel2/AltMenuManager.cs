using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AltMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject altMenuPanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClick;
    
    // Start is called before the first frame update
    void Start()
    {
        if (altMenuPanel != null)
        {
            altMenuPanel.GetComponent<CanvasGroup>().DOFade(1f, 1f);
            altMenuPanel.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutBack);
        }
        
    }

    public void WhichGameToOpen(string whichGame)
    {
        if (PlayerPrefs.GetInt("SoundMute") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        PlayerPrefs.SetString("WhichGame", whichGame);
        SceneManager.LoadScene("GameLevel");
    }

    public void GoBack()
    {
        if (PlayerPrefs.GetInt("SoundMute") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }
        SceneManager.LoadScene("MenuLevel");
    }
}
