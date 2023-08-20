using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CubeInstantiator : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject objectToInstantiate;
    GameObject selectedObject;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool isObjectSelected;
    private Vector2 touchStartPos;

    public Material[] cubeMaterials;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase==TouchPhase.Began)
            {

                if(TrySelectObject(touch.position))
                {
                    isObjectSelected = true;
                    touchStartPos = touch.position;
                    return;
                }

                if(raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;
                    Instantiate(objectToInstantiate, hitPose.position, hitPose.rotation);
                }
            }
            else if(touch.phase == TouchPhase.Moved && isObjectSelected)
            {
                Vector2 touchDelta = touch.position - touchStartPos;
                MoveSelectedObject(touchDelta);
                touchStartPos = touch.position;
            }
            else if(touch.phase==TouchPhase.Ended)
            {
                isObjectSelected = false;
            }
        }
    }

    bool TrySelectObject(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("InstantiatedObject"))
            {
                selectedObject = hitObject;
                hitObject.GetComponent<MeshRenderer>().material = cubeMaterials[Random.Range(0, cubeMaterials.Length)];

                return true;
            }
        }

        return false;
    }

    void MoveSelectedObject(Vector2 touchDelta)
    {
        if (selectedObject != null)
        {
            float sensitivity = 0.001f; 

            Vector3 movementDelta = new Vector3(touchDelta.x, 0, touchDelta.y) * sensitivity;

            Vector3 newPosition = selectedObject.transform.position + movementDelta;
            selectedObject.transform.position = newPosition;
        }
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
