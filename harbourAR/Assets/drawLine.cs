using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour
{

  public GameObject destination;
  private LineRenderer liner;
    // Start is called before the first frame update
    void Start()
    {
    liner = GetComponent<LineRenderer>();
    

  }

  // Update is called once per frame
  void Update()
    {
      liner.SetPosition(0, transform.position);
      liner.SetPosition(1, destination.transform.position);
  }
}
