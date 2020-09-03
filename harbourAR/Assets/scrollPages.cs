using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollPages : MonoBehaviour
{

  private float screenHeight;
  private Vector3 start;
  private Vector3 destination;
  private float ty;
  private bool getTime;

  private bool isScrolling;
  // Start is called before the first frame update
  // Movement speed in units per second.
  public float speed = 10.0F;

  // Time when the movement started.
  private float startTime;

  // Total distance between the markers.
  private float journeyLength;

  void Start()
  {
    // Keep a note of the time the movement started.
    startTime = Time.time;

    // Calculate the journey length.
    journeyLength = Vector3.Distance(transform.position, destination);

    screenHeight = Screen.height + (Screen.height / 2);
    destination = new Vector3(375f, screenHeight, 0f);

    //  //Debug.Log("I start here: " + transform.position);

  }

  //// Update is called once per frame
  void Update()
  {




    if (isScrolling)
    {


      ty = transform.position.y;
      // Distance moved equals elapsed time times speed..
      float distCovered = (Time.time - startTime) * speed;

      // Fraction of journey completed equals current distance divided by total distance.
      float fractionOfJourney = distCovered / journeyLength;

      // Set our position as a fraction of the distance between the markers.

      transform.position = Vector3.Lerp(start, destination, fractionOfJourney);

      Debug.Log(fractionOfJourney);
      if (fractionOfJourney >= 0.15f)
      {

        isScrolling = false;
        screenHeight += screenHeight;
      }
    }
   
  }



  




  public void Scroll()
{
  isScrolling = true;
}
 
 

}
