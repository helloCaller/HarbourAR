using UnityEngine;

public class DeviceNeverSleep : MonoBehaviour
{
  void Start()
  {
    // Disable screen dimming
    Screen.sleepTimeout = SleepTimeout.NeverSleep;
  }
}