using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenWebsite : MonoBehaviour
{


    // Update is called once per frame
  public void GoToWebAR(int site)
  {

    if (site == 0)
    {
      Application.OpenURL("https://adelheid.ca/lotx");
    } else
    {
      Application.OpenURL("https://adelheid.ca");
    }


  }
}
