using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GV : MonoBehaviour
{
    public GameObject Congrats;
    private int correct;
    public GameObject ReloadButton;
    public int Correct
    {
        get { return correct; }
        set
        {
            correct = value;
            Debug.Log("correct=" + correct);
            Content content = Congrats.transform.GetChild(0).GetComponent<Content>();
            if (correct < 11)
            {
                content.ButtonText.GetComponent<TextMeshProUGUI>().text = "Συνέχισε στο επόμενο";
            }
            else if (correct == 11)
            {
                content.ButtonText.GetComponent<TextMeshProUGUI>().text = "Συνέχισε στο τελευταίο";
            }
            else if (correct == 12) 
            {
                content.ButtonText.GetComponent<TextMeshProUGUI>().text = "Δες πώς μπορείς να προστατευθείς";
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