using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPlay : MonoBehaviour
{

    [SerializeField] GameObject inputForm;
    [SerializeField] GameObject playForm;
    public void clickBack()
    {
        inputForm.SetActive(true);
        playForm.SetActive(false);
    }
}
