using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParentTimer : MonoBehaviour
{
  public GameObject parentObj;
  private float timeLeft = 15.0f;
  // Start is called before the first frame update
  void Start()
  {
    

  }

  private void Update()
  {
    timeLeft -= Time.deltaTime;
   
    if (timeLeft < 0)
    {
      Destroy(parentObj);
    }
  }

}
