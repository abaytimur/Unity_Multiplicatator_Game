using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject [] resultsObjects;
    
    private int _remainingTime;

    private bool _shouldTimerCount;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var object1 in resultsObjects)
        {
            object1.SetActive(true);
        }
        
        _remainingTime = 30;
        _shouldTimerCount = true;
        
        resultPanel.SetActive(false);
        
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (_shouldTimerCount)
        {
            yield return new WaitForSeconds(1f);

            if (_remainingTime<=10)
            {
                timerText.text = $"0{_remainingTime.ToString()}";
            }
            else
            {
                timerText.text = _remainingTime.ToString();
            }

            if (_remainingTime<= 0)
            {
                _shouldTimerCount = false;
                timerText.text = "";
                ClearTheScreen();
                resultPanel.SetActive(true);
            }

            _remainingTime--;
        }
    }

    private void ClearTheScreen()
    {
        foreach (var object1 in resultsObjects)
        {
            object1.SetActive(false);
        }
    }
}
