using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ProgrammManager : MonoBehaviour
{
    private ARRaycastManager ARRaycastManagerScript;

    [Header("Put your planeMarker here")]
    [SerializeField] private GameObject PlaneMarkerPrefab;
    public GameObject ObjectToSpawn;
    [Header("Put ScrollView here")]
    public GameObject ScrollView;
    [Header("Put DeleteButton here")]
    public GameObject DeleteButton;

    [SerializeField] private Camera ARCamera;

    public bool ChooseObject = false;

    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        PlaneMarkerPrefab.SetActive(false);
        ScrollView.SetActive(false);
        DeleteButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ChooseObject && GameObject.FindWithTag("logo") == null)
        {
            ShowMarkerAndSetObject();
        }
    }

    void ShowMarkerAndSetObject()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // show marker
        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
        }
       // set object
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            var spawned = Instantiate(ObjectToSpawn, hits[0].pose.position, Quaternion.Euler(0, Camera.main.transform.eulerAngles.y + 180, 0));
            spawned.tag = "logo";
            ChooseObject = false;
            PlaneMarkerPrefab.SetActive(false);
            DestroyAllPlanes();
            DeleteButton.SetActive(true);
        }
    }

    void DestroyAllPlanes()
	{
        GameObject[] planes = GameObject.FindGameObjectsWithTag("plane");
        for (int i = 0; i < planes.Length; i++)
        {
            Destroy(planes[i]);
        }
    }
}
