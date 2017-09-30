using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkNode : MonoBehaviour {
    private const float MAX_DISTANCE = 1.0f;

    private GameObject mainNode;
    private Transform mainNodeTransform;
    private GameObject gameManager;
    private GraphManager graphManager;

	// Use this for initialization
	void Start ()
    {
        gameManager = GameObject.Find("GameManager");
        graphManager = gameManager.GetComponent<GraphManager>();
        mainNode = graphManager.getMainNode(transform.parent.name);
        mainNodeTransform = mainNode.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Vector3 distance = transform.position - mainNodeTransform.position;
        transform.position = Vector3.Lerp(transform.position, mainNodeTransform.position, 0.1f * Time.deltaTime);
	}
}
