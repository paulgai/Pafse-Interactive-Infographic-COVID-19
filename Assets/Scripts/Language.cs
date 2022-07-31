using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Language : MonoBehaviour
{
    public string GR;
    public string EN;
    private GV gv;
    private void Start()
    {
        gv = GameObject.Find("Canvas").GetComponent<GV>();
        if (gv.language == GV.Language.GR)
        {
            GetComponent<TextMeshProUGUI>().text = GR;
        }
        else if (gv.language == GV.Language.EN)
        {
            GetComponent<TextMeshProUGUI>().text = EN;
        }
    }
}
