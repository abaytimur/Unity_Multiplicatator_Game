using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private Image resultImage;
    [SerializeField] private Text correctText, wrongText, pointText;
    [SerializeField] private GameObject restartButton, mainMenuButton;

    private float _timer;
    private bool _openImage;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        _timer = 0;
        _openImage = true;
        correctText.text = "";
        wrongText.text = "";
        pointText.text = "";

        restartButton.GetComponent<RectTransform>().localScale = Vector3.zero;
        mainMenuButton.GetComponent<RectTransform>().localScale = Vector3.zero;

        StartCoroutine(OpenImageRoutine());
    }

    IEnumerator OpenImageRoutine()
    {
        while (_openImage)
        {
            _timer += .15f;
            resultImage.fillAmount = _timer;
            yield return new WaitForSeconds(.1f);

            if (_timer>=1f)
            {
                _timer = 1;
                _openImage = false;

                correctText.text = $"{_gameManager.correctAnswerNumber.ToString()} CORRECT";
                wrongText.text = $"{_gameManager.wrongAnswerNumber.ToString()} WRONG";
                pointText.text = $"{_gameManager.totalPoints.ToString()} POINTS";
                
                restartButton.GetComponent<RectTransform>().DOScale(1f, .3f);
                mainMenuButton.GetComponent<RectTransform>().DOScale(1f, .3f);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
