using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{

  private int screenHeight;
  private int screenWidth;
  // Start is called before the first frame update
  void Awake()
  {
    screenHeight = Screen.height / 2;
    screenWidth = Screen.width / 2;

    Screen.SetResolution(screenWidth, screenHeight, true);
  }

}
