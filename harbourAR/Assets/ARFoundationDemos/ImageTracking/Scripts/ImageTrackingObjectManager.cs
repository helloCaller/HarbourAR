using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTrackingObjectManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Image manager on the AR Session Origin")]
    ARTrackedImageManager m_ImageManager;

    /// <summary>
    /// Get the <c>ARTrackedImageManager</c>
    /// </summary>
    public ARTrackedImageManager ImageManager
    {
        get => m_ImageManager;
        set => m_ImageManager = value;
    }

    [SerializeField]
    [Tooltip("Reference Image Library")]
    XRReferenceImageLibrary m_ImageLibrary;

    /// <summary>
    /// Get the <c>XRReferenceImageLibrary</c>
    /// </summary>
    public XRReferenceImageLibrary ImageLibrary
    {
        get => m_ImageLibrary;
        set => m_ImageLibrary = value;
    }


	[SerializeField]
	[Tooltip("Prefab for tracked 1 image")]
	GameObject m_OnePrefab;

  /// <summary>
  /// Get the one prefab
  /// </summary>
  public GameObject onePrefab
  {
    get => m_OnePrefab;
    set => m_OnePrefab = value;
  }

  GameObject m_SpawnedOnePrefab;

	/// <summary>
	/// get the spawned one prefab
	/// </summary>
	public GameObject spawnedOnePrefab
	{
		get => m_SpawnedOnePrefab;
		set => m_SpawnedOnePrefab = value;
	}

	[SerializeField]
	[Tooltip("Prefab for tracked 2 image")]
	GameObject m_TwoPrefab;

	/// <summary>
	/// get the two prefab
	/// </summary>
	public GameObject twoPrefab
	{
		get => m_TwoPrefab;
		set => m_TwoPrefab = value;
	}

	GameObject m_SpawnedTwoPrefab;

	/// <summary>
	/// get the spawned two prefab
	/// </summary>
	public GameObject spawnedTwoPrefab
	{
		get => m_SpawnedTwoPrefab;
		set => m_SpawnedTwoPrefab = value;
	}

	[SerializeField]
	[Tooltip("Prefab for tracked 3 image")]
	GameObject m_ThreePrefab;

	/// <summary>
	/// Get the one prefab
	/// </summary>
	public GameObject ThreePrefab
	{
		get => m_ThreePrefab;
		set => m_ThreePrefab = value;
	}

	GameObject m_SpawnedThreePrefab;

	/// <summary>
	/// get the spawned one prefab
	/// </summary>
	public GameObject spawnedThreePrefab
	{
		get => m_SpawnedThreePrefab;
		set => m_SpawnedThreePrefab = value;
	}

	[SerializeField]
	[Tooltip("Prefab for tracked 1 image")]
	GameObject m_FourPrefab;

	/// <summary>
	/// Get the one prefab
	/// </summary>
	public GameObject FourPrefab
	{
		get => m_FourPrefab;
		set => m_FourPrefab = value;
	}

	GameObject m_SpawnedFourPrefab;

	/// <summary>
	/// get the spawned one prefab
	/// </summary>
	public GameObject spawnedFourPrefab
	{
		get => m_SpawnedFourPrefab;
		set => m_SpawnedFourPrefab = value;
	}


  [SerializeField]
  [Tooltip("Prefab for tracked 1 image")]
  GameObject m_WallPrefab;

  /// <summary>
  /// Get the one prefab
  /// </summary>
  public GameObject WallPrefab
  {
    get => m_WallPrefab;
    set => m_WallPrefab = value;
  }

  GameObject m_SpawnedWallPrefab;

  /// <summary>
  /// get the spawned one prefab
  /// </summary>
  public GameObject spawnedWallPrefab
  {
    get => m_SpawnedWallPrefab;
    set => m_SpawnedWallPrefab = value;
  }

  int m_NumberOfTrackedImages;


	NumberManager m_OneNumberManager;
	NumberManager m_TwoNumberManager;
	NumberManager m_ThreeNumberManager;
	NumberManager m_FourNumberManager;
  NumberManager m_WallNumberManager;

  static Guid s_FirstImageGUID;
	static Guid s_SecondImageGUID;
	static Guid s_ThirdImageGUID;
	static Guid s_FourthImageGUID;
  static Guid s_WallImageGUID;


 


  void OnEnable()
    {
		s_FirstImageGUID = m_ImageLibrary[0].guid;
		s_SecondImageGUID = m_ImageLibrary[1].guid;
		s_ThirdImageGUID = m_ImageLibrary[2].guid;
		s_FourthImageGUID = m_ImageLibrary[3].guid;
    s_WallImageGUID = m_ImageLibrary[4].guid;






    m_ImageManager.trackedImagesChanged += ImageManagerOnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_ImageManager.trackedImagesChanged -= ImageManagerOnTrackedImagesChanged;
    }

    void ImageManagerOnTrackedImagesChanged(ARTrackedImagesChangedEventArgs obj)
    {
        // added, spawn prefab
        foreach(ARTrackedImage image in obj.added)
        {

			if (image.referenceImage.guid == s_FirstImageGUID)
			{
				m_SpawnedOnePrefab = Instantiate(m_OnePrefab, image.transform.position, image.transform.rotation);
				m_OneNumberManager = m_SpawnedOnePrefab.GetComponent<NumberManager>();
        
        
			}
			else if (image.referenceImage.guid == s_SecondImageGUID)
			{
				m_SpawnedTwoPrefab = Instantiate(m_TwoPrefab, image.transform.position, image.transform.rotation);
				m_TwoNumberManager = m_SpawnedTwoPrefab.GetComponent<NumberManager>();
				

			}
			else if (image.referenceImage.guid == s_ThirdImageGUID)
			{
				m_SpawnedThreePrefab = Instantiate(m_ThreePrefab, image.transform.position, image.transform.rotation);
				m_ThreeNumberManager = m_SpawnedThreePrefab.GetComponent<NumberManager>();
			}
			else if (image.referenceImage.guid == s_FourthImageGUID)
			{
				m_SpawnedFourPrefab = Instantiate(m_FourPrefab, image.transform.position, image.transform.rotation);
				m_FourNumberManager = m_SpawnedFourPrefab.GetComponent<NumberManager>();
			}
      else if (image.referenceImage.guid == s_WallImageGUID)
      {
        m_SpawnedWallPrefab = Instantiate(m_WallPrefab, image.transform.position, image.transform.rotation);
        m_WallNumberManager = m_SpawnedWallPrefab.GetComponent<NumberManager>();
      }

    }

	// updated, set prefab position and rotation
	foreach (ARTrackedImage image in obj.updated)
	{
			Debug.Log(image.trackingState);
			
		// image is tracking or tracking with limited state, show visuals and update it's position and rotation
		if (image.trackingState == TrackingState.Tracking)
		{

				if (image.referenceImage.guid == s_FirstImageGUID)
				{
					m_OneNumberManager.EnableARVideoObj(true);
					m_SpawnedOnePrefab.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);

				}
				else if (image.referenceImage.guid == s_SecondImageGUID)
				{
					m_TwoNumberManager.EnableARVideoObj(true);
					m_SpawnedTwoPrefab.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
					
				}
				else if (image.referenceImage.guid == s_ThirdImageGUID)
				{
					m_ThreeNumberManager.EnableARVideoObj(true);
					m_SpawnedThreePrefab.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
				}
				else if (image.referenceImage.guid == s_FourthImageGUID)
				{
					m_FourNumberManager.EnableARVideoObj(true);
					m_SpawnedFourPrefab.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
				}
        else if (image.referenceImage.guid == s_WallImageGUID)
        {
          m_WallNumberManager.EnableARVideoObj(true);
          m_SpawnedWallPrefab.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
        }
      }
		// image is no longer tracking, disable visuals TrackingState.Limited TrackingState.None
		else if (image.trackingState == TrackingState.Limited)
		{
				m_OneNumberManager.EnableARVideoObj(false);
				m_TwoNumberManager.EnableARVideoObj(false);
				m_ThreeNumberManager.EnableARVideoObj(false);
				m_FourNumberManager.EnableARVideoObj(false);
        m_WallNumberManager.EnableARVideoObj(false);

        //if (image.referenceImage.guid == s_FirstImageGUID)
        //{
        //	m_OneNumberManager.EnableARVideoObj(false);
        //	Destroy(m_SpawnedOnePrefab);
        //}
        //else if (image.referenceImage.guid == s_SecondImageGUID)
        //{
        //	m_TwoNumberManager.EnableARVideoObj(false);
        //	Destroy(m_SpawnedTwoPrefab);
        //}
        //else if (image.referenceImage.guid == s_ThirdImageGUID)
        //{
        //	m_ThreeNumberManager.EnableARVideoObj(false);
        //}
        //else if (image.referenceImage.guid == s_FourthImageGUID)
        //{
        //	m_FourNumberManager.EnableARVideoObj(false);
        //}
      }
		}
	
        
        // removed, destroy spawned instance
        foreach(ARTrackedImage image in obj.removed)
        {
					if (image.referenceImage.guid == s_FirstImageGUID)
            {
                Destroy(m_SpawnedOnePrefab);
              }
            else if (image.referenceImage.guid == s_FirstImageGUID)
            {
                Destroy(m_SpawnedTwoPrefab);
            }
			else if (image.referenceImage.guid == s_ThirdImageGUID)
			{
				Destroy(m_SpawnedThreePrefab);
			}
			else if (image.referenceImage.guid == s_FourthImageGUID)
			{
				Destroy(m_SpawnedFourPrefab);
			}
      else if (image.referenceImage.guid == s_WallImageGUID)
      {
        Destroy(m_SpawnedWallPrefab);
      }
    }

 }

    public int NumberOfTrackedImages()
    {
        m_NumberOfTrackedImages = 0;
        foreach (ARTrackedImage image in m_ImageManager.trackables)
        {
            if (image.trackingState == TrackingState.Tracking)
            {
                m_NumberOfTrackedImages++;
            }
        }
        return m_NumberOfTrackedImages;
    }
}
