using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropdownSelectColor : MonoBehaviour
{
    Dropdown m_Dropdown;
  
    float circleColor;

   void Start()
    {
        //Fetch the Dropdown GameObject
        m_Dropdown = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });        
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {
       if(change.value == 0)
       {
           circleColor = 0.2f;
           Debug.Log(change.value);
       }
       else if(change.value == 1)
       {
           circleColor = 0.4f;
       }
        else if(change.value == 2)
       {
           circleColor = 0.6f;
       }
        else if(change.value == 3)
       {
           circleColor = 0.8f;
       }
       else
       {
           circleColor = 1f;
       }
        PlayerPrefs.SetFloat("CircleColor", circleColor);
    }
}
