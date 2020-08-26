﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : MonoBehaviour
{
  private bool toggle = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ToggleInfoVisibility()
    {
      gameObject.SetActive(toggle);
      toggle = !toggle;
    }
}
