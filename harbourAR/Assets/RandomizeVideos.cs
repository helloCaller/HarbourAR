﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RandomizeVideos : MonoBehaviour
{

  [SerializeField]
   public VideoClip[] videos;

  public GameObject rootOfPrefab;
  //public GameObject quadParent;


  private List<int> videosPlayed;
  private List<int> videosUnplayed;
  private System.Random randomize;

  private int currentVideo;

  private VideoPlayer videoPlayer;

  
  //public Vector3 arWallPositionTweaks;
  //public Vector3 arWallScaleTweaks;
  // Start is called before the first frame update
  void Start()
  {
    videoPlayer = gameObject.GetComponent<VideoPlayer>();

    videoPlayer.loopPointReached += OnVideoClipEnd;

    randomize = new System.Random();
    videosUnplayed = new List<int>();
    videosPlayed = new List<int>();

    for (int i = 0; i < videos.Length; i++)
    {
      videosUnplayed.Add(i);
    }
   
    currentVideo = GetNextARVideoIndex();
    videoPlayer.clip = videos[currentVideo];

    

    //float coordinateX = quadParent.transform.position.x;
    //float coordinateY = quadParent.transform.position.y;
    //float coordinateZ = quadParent.transform.position.z;
    //quadParent.transform.Translate(coordinateX + arWallPositionTweaks.x, coordinateY + arWallPositionTweaks.y, coordinateZ + arWallPositionTweaks.z);

  }

    int GetNextARVideoIndex()
  {
    int remainingVideosCount = videosUnplayed.Count;
    int randomRemainingVideo = videosUnplayed[randomize.Next(remainingVideosCount)];
    return randomRemainingVideo;

  }

  void OnVideoClipEnd(VideoPlayer player)
  {
    
      videosUnplayed.Remove(currentVideo);
      videosPlayed.Add(currentVideo);

      if (videosPlayed.Count == videos.Length - 3)
      {
        Destroy(rootOfPrefab);
      }
      else
      {
        currentVideo = GetNextARVideoIndex();
        videoPlayer.clip = videos[currentVideo];
        StartCoroutine(PlayAfterDelay(3));
      }
     
  }

  IEnumerator PlayAfterDelay(int delayInSeconds)
  {
    yield return new WaitForSeconds(delayInSeconds);
    videoPlayer.Play();
  }

  
}
