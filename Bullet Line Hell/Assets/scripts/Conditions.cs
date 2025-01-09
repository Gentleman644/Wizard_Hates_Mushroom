using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class Conditions : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winLoseText;
    [SerializeField] private TextMeshProUGUI timerText;
    public float timerUntilWin = 10f;
    public UnityEvent winMethods;
    private Boolean didNotLose = true;
    private float timer;

    private void Awake()
    {
        timer = timerUntilWin;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.P))
        {
            Application.Quit();
        }

        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            int timerToDisplay = (int)timer;
            timerText.text = timerToDisplay.ToString();
        }
        else if(didNotLose)
        {
            winMethods.Invoke();
        }
    }

    public void winScreen()
    {
        winLoseText.text = "YOU WIN";
        winLoseText.color = Color.green;
        timerText.enabled = false;
    }

    public void loseScreen()
    {
        didNotLose = false;
        winLoseText.text = "YOU LOSE";
        winLoseText.color = Color.red;
        timerText.enabled = false;
    }
}
