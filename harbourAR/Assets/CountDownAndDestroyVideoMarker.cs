using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class CountDownAndDestroyVideoMarker : MonoBehaviour
{

  public Material newMaterial;

  public float delayTime;
  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(StaticBeforeDestroy());
    StartCoroutine(DestroyAfterDelay(delayTime));

  }



  IEnumerator DestroyAfterDelay(float delayInSeconds)
  {
    yield return new WaitForSeconds(delayInSeconds);
    //objectToDestroy.SetActive(false);
    Destroy(gameObject);

  }

  IEnumerator StaticBeforeDestroy()
  {

    yield return new WaitForSeconds(delayTime / 1.2f);

    GetComponent<MeshRenderer>().material = newMaterial;

  }
}
