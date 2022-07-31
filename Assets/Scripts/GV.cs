using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GV : MonoBehaviour
{
    public enum Language { GR, EN };

    public Language language;
    public GameObject Congrats;
    private int correct;
    public GameObject ReloadButton;
    public int Correct
    {
        get { return correct; }
        set
        {
            correct = value;
            //Debug.Log("correct=" + correct);
            Content content = Congrats.transform.GetChild(0).GetComponent<Content>();
            if (correct < 11)
            {
                if (language == Language.GR)
                {
                    content.ButtonText.GetComponent<TextMeshProUGUI>().text = "Συνέχισε στο επόμενο";
                }
                else if (language == Language.EN) 
                {
                    content.ButtonText.GetComponent<TextMeshProUGUI>().text = "Continue to the next";
                }
             }
            else if (correct == 11)
            {
                if (language == Language.GR)
                {
                    content.ButtonText.GetComponent<TextMeshProUGUI>().text = "Συνέχισε στο τελευταίο";
                }
                else if (language == Language.EN)
                {
                    content.ButtonText.GetComponent<TextMeshProUGUI>().text = "Continue to the last";
                }
                
            }
            else if (correct == 12) 
            {
                if (language == Language.GR)
                {
                    content.ButtonText.GetComponent<TextMeshProUGUI>().text = "Δες πώς μπορείς να προστατευθείς";
                }
                else if (language == Language.EN)
                {
                    content.ButtonText.GetComponent<TextMeshProUGUI>().text = "See how you can protect yourself";
                }
                
                content.RestartButton.SetActive(true);
                ReloadButton.SetActive(true);
            }
            Congrats.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}