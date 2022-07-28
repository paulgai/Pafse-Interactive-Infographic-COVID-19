using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Place : MonoBehaviour
{
    public bool isHappy = true;

    public bool isOccupied = false;

    public Sprite Happy;

    public Sprite Sad;

    public Color HappyColor;

    public Color SadColor;

    private void Start()
    {
        if (isHappy)
        {
            this.GetComponent<Image>().color = HappyColor;
            this.GetComponent<Image>().sprite = Happy;
        }
        else 
        {
            this.GetComponent<Image>().color = SadColor;
            this.GetComponent<Image>().sprite = Sad;

        }
    }

}
