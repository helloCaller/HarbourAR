using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RandomizeVideos : MonoBehaviour
{

  [SerializeField]
   public VideoClip[] videos;

  public GameObject rootOfPrefab;


  private List<int> videosPlayed;
  private List<int> videosUnplayed;
  private System.Random randomize;

  private int currentVideo;

 private VideoPlayer videoPlayer;
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

    if(videosPlayed.Count == videos.Length)
    {
      Destroy(rootOfPrefab);
    } else
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
