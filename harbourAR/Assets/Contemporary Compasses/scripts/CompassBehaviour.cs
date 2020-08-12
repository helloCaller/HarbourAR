using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class CompassBehaviour : MonoBehaviour {

  public TextMeshPro headingText;
  private bool startTracking = false;

  private float currentLatitude;
  private float currentLongitude;

  private float destinationLatitude = 43.639399f;
  private float destinationLongitude = -79.382059f;


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

  void Start() {
    Input.compass.enabled = true;
    Input.location.Start();
    StartCoroutine(InitializeCompass());
  }

  void Update() {
		//print(currentDistanceToDestination(currentLatitude, currentLongitude, destinationLatitude, destinationLongitude));
	changeSceneNearDestination(currentDistanceToDestination(currentLatitude, currentLongitude, destinationLatitude, destinationLongitude));


	if (startTracking) {
      currentLatitude = Input.location.lastData.latitude;
      currentLongitude = Input.location.lastData.longitude;
	  print(currentDistanceToDestination(currentLatitude, currentLongitude, destinationLatitude, destinationLongitude));
	  float bearing = angleFromCoordinate(currentLatitude, currentLongitude, destinationLatitude, destinationLongitude);
			
	  transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, Input.compass.magneticHeading + bearing), 100f);
      //transform.rotation = Quaternion.Euler(0, 0, Input.compass.trueHeading);
      headingText.text = ((int)Input.compass.trueHeading).ToString() + "° " + DegreesToCardinalDetailed(Input.compass.trueHeading);
    }
  }

  IEnumerator InitializeCompass() {
    yield return new WaitForSeconds(1f);
    startTracking |= Input.compass.enabled;
  }

  private static string DegreesToCardinalDetailed(double degrees) {
    string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
    return caridnals[(int)Math.Round(((double)degrees * 10 % 3600) / 225)];
  }

  private float currentDistanceToDestination(float currentLat, float currentLong, float destinationLat, float destinationLong){
		float latSquare = Mathf.Pow((destinationLat - currentLat), 2);
		float longSquare = Mathf.Pow((destinationLong - currentLong), 2);
		return Mathf.Sqrt(latSquare + longSquare);

  }

  private void changeSceneNearDestination (float dist) {
		float allowance = 0.0005f;
        if (dist <= allowance) {
			SceneManager.LoadScene("MainAR");
		}
		
  }


}

