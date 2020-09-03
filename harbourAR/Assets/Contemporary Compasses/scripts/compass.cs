using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.SceneManagement;

public class compass : MonoBehaviour
{

  //public TextMeshPro headingText;
  private bool startTracking = false;

  private float input;

  private float oldInput;

  //private float currentLatitude;
  //private float currentLongitude;

  //private float destinationLatitude = 43.6388981f;
  //private float destinationLongitude = -79.3821843f;


  private float angleFromCoordinate(float lat1, float long1, float lat2, float long2)
  {
    lat1 *= Mathf.Deg2Rad;
    lat2 *= Mathf.Deg2Rad;
    long1 *= Mathf.Deg2Rad;
    long2 *= Mathf.Deg2Rad;

    float dLon = (long2 - long1);
    float y = Mathf.Sin(dLon) * Mathf.Cos(lat2);
    float x = (Mathf.Cos(lat1) * Mathf.Sin(lat2)) - (Mathf.Sin(lat1) * Mathf.Cos(lat2) * Mathf.Cos(dLon));
    float brng = Mathf.Atan2(y, x);
    brng = Mathf.Rad2Deg * brng;
    brng = (brng + 360) % 360;
    brng = 360 - brng;
    return brng;
  }

  void Start()
  {
    Input.compass.enabled = true;
    Input.location.Start();
    StartCoroutine(InitializeCompass());
  }

  void Update()
  {
    
    //changeSceneNearDestination(currentDistanceToDestination(currentLatitude, currentLongitude, destinationLatitude, destinationLongitude));


    if (startTracking)
    {
      //currentLatitude = Input.location.lastData.latitude;
      //currentLongitude = Input.location.lastData.longitude;

      //float bearing = angleFromCoordinate(currentLatitude, currentLongitude, destinationLatitude, destinationLongitude);
      input = Input.compass.trueHeading;
      


      //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, Input.compass.magneticHeading + bearing), 100f);
      transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, Input.compass.trueHeading), 0.01f);
      
    }
  }

  IEnumerator InitializeCompass()
  {
    yield return new WaitForSeconds(1f);
    startTracking |= Input.compass.enabled;
  }


}

