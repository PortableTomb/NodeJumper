using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;

    public Transform cameraRigTransform;
    public Transform cameraHeadTransform;
    public GraphManager graphManager;
    public GameObject laserPrefab;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void laserHit(RaycastHit hit)
    {
        GameObject collisionObject = hit.transform.gameObject;
        Debug.Log("Hit " + collisionObject.name);
        GameObject destinationObject = graphManager.getMainNode(collisionObject.name);
        Vector3 difference = cameraRigTransform.position - cameraHeadTransform.position;
        difference.y = 0;
        Vector3 offset = new Vector3(0.5f, -1f, 0.5f);
        cameraRigTransform.position = destinationObject.transform.position + difference + offset;
        cameraRigTransform.LookAt(collisionObject.transform);
        cameraRigTransform.rotation = Quaternion.identity;
    }

    public void updateLaser(RaycastHit ray)
    {
        //set laserposition
        Vector3 startPoint = trackedObj.transform.position;
        Vector3 endPoint = startPoint + trackedObj.transform.forward * 100;
        laserTransform.position = Vector3.Lerp(startPoint, endPoint, .5f);
        //orient laser towards point where raycast hit
        laserTransform.LookAt(endPoint);
        //create the laser
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            100);
    }

    void Start()
    {
        //create laser
        laser = Instantiate(laserPrefab);
        //for convenient access to transform
        laserTransform = laser.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //intialize raycast
        RaycastHit ray;
        bool hit = Physics.Raycast(trackedObj.transform.position, trackedObj.transform.forward, out ray, 150.0f);
        updateLaser(ray);

        if (hit)
        {
            //if (Controller.GetHairTrigger())
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                hitPoint = ray.point;
                laserHit(ray);
            }
        }
    }
}
