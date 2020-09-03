using System.Collections;
using System.Collections.Generic;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine;

public class changeButtons : MonoBehaviour
{

  private int panelNumber;
  public GameObject button1;
 
  // Start is called before the first frame update
  public void checkPanelNumber()
  {
    panelNumber = GetComponent<SimpleScrollSnap>().CurrentPanel;
    if (panelNumber == 14)
    {
      button1.SetActive(false);
      
    }
  }

}
