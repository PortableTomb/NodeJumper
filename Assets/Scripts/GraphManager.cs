using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour {
    private Transform graph;

    //constants
    static public float MAIN_LOWER_BOUND = -2.0f;
    static public float MAIN_UPPER_BOUND = 2.0f;
    static public float LINK_LOWER_BOUND = -1.0f;
    static public float LINK_UPPER_BOUND = 1.0f;


    public GameObject mainNodePreFab;
    public GameObject linkNodePreFab;

    public LinkNode[] linkNodes;
    public MainNode[] mainNodes;

    public class MainNode
    {
        public string name;
        public LinkNode[] links;

        public MainNode(string name, LinkNode[] links)
        {
            this.name = name;
            this.links = links;
        }
    }

    public class LinkNode
    {
        public string name;
        public MainNode main;

        public LinkNode(string name)
        {
           this.name = name;
        }

        public void setMainNode(MainNode main)
        {
            this.main = main;
        }
    }

    void SpawnMainNodes()
    {
        graph = new GameObject("Graph").transform;

        for (int i = 0; i < mainNodes.Length; i++)
        {
            float x = Random.Range(MAIN_LOWER_BOUND, MAIN_UPPER_BOUND);
            float y = Random.Range(MAIN_LOWER_BOUND, MAIN_UPPER_BOUND);
            float z = Random.Range(MAIN_LOWER_BOUND, MAIN_UPPER_BOUND);
            GameObject main = Instantiate(mainNodePreFab, new Vector3(x, y, z), Quaternion.identity);
            main.transform.SetParent(graph);
            main.name = mainNodes[i].name;
      
            TextMesh mesh = main.GetComponentInChildren<TextMesh>();
            mesh.text = mainNodes[i].name;

            for (int j = 0; j < mainNodes[i].links.Length; j++)
            {
                float xOffset = x + Random.Range(-1.0f, 1.0f);
                float yOffset = y + Random.Range(-1.0f, 1.0f);
                float zOffset = z + Random.Range(-1.0f, 1.0f);
                GameObject link = Instantiate(linkNodePreFab, new Vector3(xOffset, yOffset, zOffset), Quaternion.identity);
                link.transform.SetParent(main.transform);
                link.name = mainNodes[i].links[j].name;
            }
        }
    }

	// Use this for initialization
	void Awake ()
    {
        linkNodes = new LinkNode[4]
        {
            new LinkNode("Star Wars"),
            new LinkNode("Mark Hamill"),
            new LinkNode("Carrie Fisher"),
            new LinkNode("Harrison Ford")
        };

        mainNodes = new MainNode[4]
        {
            new MainNode("Star Wars", new LinkNode[]
            {
                linkNodes[1],
                linkNodes[2],
                linkNodes[3]
            }),
            new MainNode("Mark Hamill", new LinkNode[]
            {
                linkNodes[0]
            }),
            new MainNode("Carrie Fisher", new LinkNode[]
            {
                linkNodes[0]
            }),
            new MainNode("Harrison Ford", new LinkNode[]
            {
                linkNodes[0]
            })
        };

        linkNodes[0].setMainNode(mainNodes[0]);
        linkNodes[1].setMainNode(mainNodes[1]);
        linkNodes[2].setMainNode(mainNodes[2]);
        linkNodes[3].setMainNode(mainNodes[3]);

        SpawnMainNodes();
	}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
