using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startImage;
    [SerializeField] private Text questionText, orangeCircleText, blueCircleText, pinkCircleText;
    [SerializeField] private Text correctAnswerNumberText, wrongAnswerNumberText, totalPointText;
    [SerializeField] private GameObject correctImage, wrongImage;
    
    private string _whichGame;
    private int _firstQuestionNumber;
    private int _secondQuestionNumber;
    private int _correctAnswer;
    private int _firstWrongAnswer, _secondWrongAnswer;
    public int correctAnswerNumber, wrongAnswerNumber, totalPoints;

    private PlayerManager _playerManager;

    private AdmobManager _admobManager;
    
    private void Awake()
    {
        _admobManager = Object.FindObjectOfType<AdmobManager>();
        _playerManager = Object.FindObjectOfType<PlayerManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        correctAnswerNumber = 0;
        wrongAnswerNumber = 0;
        totalPoints = 0;
        correctImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        wrongImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (PlayerPrefs.HasKey("WhichGame"))
        {
            _whichGame = PlayerPrefs.GetString("WhichGame");
        }

        StartCoroutine(StartImageRoutine());
    }

    IEnumerator StartImageRoutine()
    {
        startImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        startImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        startImage.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        yield return new WaitForSeconds(0.6f);

        StartGame();
    }

    void StartGame()
    {
        _playerManager.changeRotation = true;
        DisplayTheQuestion();
        
        _admobManager.ShowBanner();
    }

    private void SetFirstQuestionNumber()
    {
        switch (_whichGame)
        {
            case "two":
                _firstQuestionNumber = 2;
                break;

            case "three":
                _firstQuestionNumber = 3;
                break;

            case "four":
                _firstQuestionNumber = 4;
                break;

            case "five":
                _firstQuestionNumber = 5;
                break;

            case "six":
                _firstQuestionNumber = 6;
                break;

            case "seven":
                _firstQuestionNumber = 7;
                break;

            case "eight":
                _firstQuestionNumber = 8;
                break;

            case "nine":
                _firstQuestionNumber = 9;
                break;

            case "ten":
                _firstQuestionNumber = 10;
                break;

            case "random":
                _firstQuestionNumber = Random.Range(2, 11);
                break;
        }
    }

    private void DisplayTheQuestion()
    {
        SetFirstQuestionNumber();

        _secondQuestionNumber = Random.Range(2, 11);

        int randomNumber = Random.Range(1, 100);
        if (randomNumber <= 50)
        {
            questionText.text = $"{_firstQuestionNumber.ToString()} x {_secondQuestionNumber.ToString()}";
        }
        else
        {
            questionText.text = $"{_secondQuestionNumber.ToString()} x {_firstQuestionNumber.ToString()}";
        }

        _correctAnswer = _firstQuestionNumber * _secondQuestionNumber;

        DisplayAnswers();
    }

    private void DisplayAnswers()
    {
        _firstWrongAnswer = _correctAnswer + Random.Range(2, 10);
        if (_correctAnswer > 10)
        {
            _secondWrongAnswer = _correctAnswer - Random.Range(2, 8);
        }
        else
        {
            _secondWrongAnswer = Mathf.Abs(_correctAnswer - Random.Range(1, 5));
        }

        int randomValue = Random.Range(1, 100);
        if (randomValue <= 33)
        {
            orangeCircleText.text = _correctAnswer.ToString();
            blueCircleText.text = _firstWrongAnswer.ToString();
            pinkCircleText.text = _secondQuestionNumber.ToString();
        }
        else if (randomValue <= 66)
        {
            blueCircleText.text = _correctAnswer.ToString();
            orangeCircleText.text = _firstWrongAnswer.ToString();
            pinkCircleText.text = _secondQuestionNumber.ToString();
        }
        else
        {
            pinkCircleText.text = _correctAnswer.ToString();
            orangeCircleText.text = _firstWrongAnswer.ToString();
            blueCircleText.text = _secondQuestionNumber.ToString();
        }
    }

    public void CheckAnswers(int textAnswer)
    {
        correctImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        wrongImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        
        if (textAnswer == _correctAnswer)
        {
            correctAnswerNumber++;
            totalPoints += 20;
            correctImage.GetComponent<RectTransform>().DOScale(1f, 0.1f);
        }
        else
        {
            wrongAnswerNumber++;
            totalPoints -= 5;
            if (totalPoints<= 0)
            {
                totalPoints = 0;
            }
            
            wrongImage.GetComponent<RectTransform>().DOScale(1f, 0.1f);
        }

        correctAnswerNumberText.text = $"CORRECT: {correctAnswerNumber.ToString()}";
        wrongAnswerNumberText.text = $"WRONG: {wrongAnswerNumber.ToString()}";
        totalPointText.text = $"POINTS: {totalPoints.ToString()}";

        DisplayTheQuestion();
    }
}