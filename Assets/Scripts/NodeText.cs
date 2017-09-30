using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeText : MonoBehaviour {
    private GameObject mainCamera;
    private Transform mainCameraTransform;
    private TextMesh text;

    // Use this for initialization
    void Start()
    {
        this.mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        this.mainCameraTransform = mainCamera.transform;
        this.text = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update ()
    {
        this.text.transform.LookAt(mainCameraTransform.position);
        this.text.transform.Rotate(new Vector3(0, 180, 0));
    }
}
