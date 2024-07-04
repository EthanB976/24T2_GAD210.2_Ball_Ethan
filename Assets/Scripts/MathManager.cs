using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MathManager : MonoBehaviour
{
    //first value
    private int lowFirstValue = 0;
    private int highFirstValue = 10;
    public int firstValue;

    //sceond value
    private int lowSecondValue = 0;
    private int highSecondValue = 10;
    public int secondValue;

    //the problem text
    [SerializeField] public TextMeshProUGUI gameText;
    [SerializeField] private TextMeshProUGUI correctText;

    //final answer value
    public int finalValue;

    //bools to check which operation to do 
    private bool isAdd = false;
    private bool isSub = false;
    private bool isMulti = false;
    private bool isDiv = false;

    //this checks the input otherwise answervalue will always  = 0 which is wrong
    private string input;

    Timer timer;

    // Start is called before that first frame update
    private void Start()
    {
        timer = GetComponent<Timer>();
        AskQuestion();
    }

   
   public void AskQuestion()
    {

        firstValue = Random.Range(lowFirstValue, highFirstValue);
        secondValue = Random.Range(lowSecondValue, highSecondValue);
        int i = Random.Range(1, 5);
        //added this to check if highest variable was ever being reach, for some reason its not 99.9% of the time
        Debug.Log(i);
        if (i == 1)
        {
            isAdd = true;
            finalValue = firstValue + secondValue;
            Debug.Log("Adding");
        }
        else if (i == 2)
        {
            isSub = true;
            finalValue = firstValue - secondValue;
            Debug.Log("Subtracting");
        }
        else if (i == 3)
        {
            isMulti = true;
            finalValue = firstValue * secondValue;
            Debug.Log("Multipling");
        }
        else if (i == 4)
        {
            isDiv = true;
            finalValue = firstValue / secondValue;
            Debug.Log("Dividing");
        }
        //I don't know why we never generate the highest value here??? so lets just add another vaule
        else if (i == 5)
        {
            isDiv = true;
            finalValue = firstValue / secondValue;
            Debug.Log("Dividing");
        }

        Debug.Log("Answer Value = " + finalValue);
        if (isAdd == true)
        {
            gameText.text = firstValue + "+" + secondValue.ToString();
        }
        if (isSub == true)
        {
            gameText.text = firstValue + "-" + secondValue.ToString();
        }
        if (isMulti == true)
        {
            gameText.text = firstValue + "*" + secondValue.ToString();
        }
        if (isDiv == true)
        {
            gameText.text = firstValue + "/" + secondValue.ToString();
        }

        
    }

    public void EndAnswer(string answerString)
    {
        
        
        Debug.Log("Button Pressed!!!");

        input = answerString;
        int answerValue;
        int.TryParse(input, out answerValue);
        if (answerValue == finalValue)
        {
            Debug.Log("correct!!");
            correctText.text = "Correct!!";
        }
        else
        {
            Debug.Log("false!!");
            correctText.text = "False!!";
        }
        //this lets us know the input is working and functioning correctly

        AskQuestion();
        
        timer.ResetTimer();


    }


    

}
