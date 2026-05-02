using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditMenu : MonoBehaviour
{
    public GameObject CreditText;
    public GameObject CreditBackground;
    public GameObject CreditsX;
    public void SetActive()
    {
        CreditText.SetActive(true);
        CreditBackground.SetActive(true);
        CreditsX.SetActive(true); 
    }
    public void SetInActive()
    {
        CreditText.SetActive(false);
        CreditBackground.SetActive(false);
        CreditsX.SetActive(false);
    }
}
