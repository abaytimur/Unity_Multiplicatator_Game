using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class CircleRotateManager : MonoBehaviour
{
    private string _whichAnswer;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullets")) return;
        gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);

        if (other.gameObject != null)
        {
            Destroy(other.gameObject);
        }

        switch (gameObject.name)
        {
            case "OrangeCircleImage":
                _whichAnswer = GameObject.Find("LeftText").GetComponent<Text>().text;
                break;
            case "BlueCircleImage":
                _whichAnswer = GameObject.Find("MiddleText").GetComponent<Text>().text;
                break;
            case "PinkCircleImage":
                _whichAnswer = GameObject.Find("RightText").GetComponent<Text>().text;
                break;
        }
        
        _gameManager.CheckAnswers(int.Parse(_whichAnswer));
    }
}
