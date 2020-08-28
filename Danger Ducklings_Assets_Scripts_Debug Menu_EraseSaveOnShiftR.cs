using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseSaveOnShiftR : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            PlayerPrefs.DeleteAll();
            //Debug.Log("Deleted w/ shift R"); 
        }
    }

    public void EraseData()
    {
        PlayerPrefs.DeleteAll();
        //Debug.Log("Deleted with debug menu");  
    }
}
