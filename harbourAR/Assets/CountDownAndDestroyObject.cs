using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownAndDestroyObject : MonoBehaviour
{

  public GameObject objectToDestroy;
  public int delayTime;
    // Start is called before the first frame update
    void Start()
    {

    StartCoroutine(DestroyAfterDelay(delayTime));
  }

 

  IEnumerator DestroyAfterDelay(int delayInSeconds)
  {
    yield return new WaitForSeconds(delayInSeconds);
    

     objectToDestroy.SetActive(false);
  }
}
