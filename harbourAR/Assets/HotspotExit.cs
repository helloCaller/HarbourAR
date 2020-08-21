using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotExit : MonoBehaviour
{
  private GameObject hotspotObject;
    // Start is called before the first frame update
    void Start()
    {
      hotspotObject = gameObject;
     
    }

    // Update is called once per frame
    public void MakeItGoAway()
  {
    //hotspotObject.SetActive(false);
    Destroy(hotspotObject);
  }
}
