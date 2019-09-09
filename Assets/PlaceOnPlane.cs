using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;


public class PlaceOnPlane : MonoBehaviour
{
    public GameObject PrefabToPlace;
    public Text text;

    private ARSessionOrigin sessionOrigin;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits;


    // Start is called before the first frame update
    void Start()
    {
        sessionOrigin = GetComponent<ARSessionOrigin>();
        raycastManager = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartCoroutine(displayTouched());
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose pose = hits[0].pose;
                    Instantiate(PrefabToPlace, pose.position, pose.rotation);
                }
            }
        }
    }

    IEnumerator displayTouched()
    {
        text.enabled = true;
        yield return new WaitForSeconds(1f);
        text.enabled = false;

    }
}
