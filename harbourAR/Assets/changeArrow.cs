using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeArrow : MonoBehaviour
{
  private bool isFacingUp;

  public void ChangeArrow()
  {
    StartCoroutine(Rotate(Vector3.forward, 180, 0.1f));
  }

  IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
  {
    Quaternion from = transform.rotation;
    Quaternion to = transform.rotation;
    to *= Quaternion.Euler(axis * angle);

    float elapsed = 0.0f;
    while (elapsed < duration)
    {
      transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
      elapsed += Time.deltaTime;
      yield return null;
    }
    transform.rotation = to;
  }
  
}
