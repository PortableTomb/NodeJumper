using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour {
    private Transform graph;

    //constants
    static public float MAIN_LOWER_BOUND = -50.0f;
    static public float MAIN_UPPER_BOUND = 50.0f;
    static public float LINK_LOWER_BOUND = -5.0f;
    static public float LINK_UPPER_BOUND = 5.0f;


    public GameObject mainNodePreFab;
    public GameObject linkNodePreFab;
    public Transform cameraRigTransform;
    public Transform cameraHeadTransform;

    public LinkNode[] linkNodes;
    public MainNode[] mainNodes;

    public class MainNode
    {
        public string name;
        public GameObject node;
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
        public GameObject node;
        public MainNode main;

        public LinkNode(string name)
        {
           this.name = name;
        }
    }

    void SpawnNodes()
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
            mainNodes[i].node = main;
      
            TextMesh mainMesh = main.GetComponentInChildren<TextMesh>();
            mainMesh.text = mainNodes[i].name;

            for (int j = 0; j < mainNodes[i].links.Length; j++)
            {
                float xOffset = x + Random.Range(LINK_LOWER_BOUND, LINK_UPPER_BOUND);
                float yOffset = y + Random.Range(LINK_LOWER_BOUND, LINK_UPPER_BOUND);
                float zOffset = z + Random.Range(LINK_LOWER_BOUND, LINK_UPPER_BOUND);

                GameObject link = Instantiate(linkNodePreFab, new Vector3(xOffset, yOffset, zOffset), Quaternion.identity);
                link.transform.SetParent(main.transform);
                link.name = mainNodes[i].links[j].name;

                TextMesh linkMesh = link.GetComponentInChildren<TextMesh>();
                linkMesh.text = mainNodes[i].links[j].name;
            }
        }
    }

    public GameObject getMainNode(string name)
    {
        for (int i = 0; i < mainNodes.Length; i++)
        {
            if (mainNodes[i].name == name)
            {
                Debug.Log("Successfully found main node -> " + name);
                return mainNodes[i].node;
            }
        }

        Debug.Log("Could not find main node -> " + name);
        return null;
    }

	// Use this for initialization
	void Awake ()
    {

        mainNodes = new MainNode[]
        {
            new MainNode("Alec Baldwin", new LinkNode[]
            {
                new LinkNode("The Departed"),
                new LinkNode("The Hunt for Red October")
            }),
            new MainNode("Apollo 13", new LinkNode[]
            {
                new LinkNode("Kevin Bacon"),
                new LinkNode("Bill Paxton")
            }),
            new MainNode("Ben Affleck", new LinkNode[]
            {
                new LinkNode("The Sum of All Fears"),
                new LinkNode("Good Will Hunting")
            }),
            new MainNode("Bill Paxton", new LinkNode[]
            {
                new LinkNode("Apollo 13"),
                new LinkNode("Titanic")
            }),
            new MainNode("Chris Pine", new LinkNode[]
            {
                new LinkNode("Star Trek"),
                new LinkNode("Jack Ryan")
            }),
            new MainNode("Django Unchained", new LinkNode[]
            {
                new LinkNode("Quentin Tarantino"),
                new LinkNode("Leonardo DiCaprio"),
                new LinkNode("Samuel L Jackson")
            }),
            new MainNode("Footloose", new LinkNode[]
            {
                new LinkNode("Kevin Bacon"),
                new LinkNode("John Lithgow")
            }),
            new MainNode("George Lucas", new LinkNode[]
            {
                new LinkNode("Star Wars"),
                new LinkNode("Indiana Jones")
            }),
            new MainNode("Good Will Hunting", new LinkNode[]
            {
                new LinkNode("Matt Damon"),
                new LinkNode("Ben Affleck")
            }),
            new MainNode("Harrison Ford", new LinkNode[]
            {
                new LinkNode("Star Wars"),
                new LinkNode("Indiana Jones")
            }),
            new MainNode("Indiana Jones", new LinkNode[]
            {
                new LinkNode("George Lucas"),
                new LinkNode("Harrison Ford")
            }),
            new MainNode("Interstellar", new LinkNode[]
            {
                new LinkNode("Matt Damon"),
                new LinkNode("John Lithgow")
            }),
            new MainNode("Jack Ryan", new LinkNode[]
            {
                new LinkNode("Chris Pine"),
                new LinkNode("Tom Clancy")
            }),
            new MainNode("John Lithgow", new LinkNode[]
            {
                new LinkNode("Footloose"),
                new LinkNode("Interstellar")
            }),
            new MainNode("Kevin Bacon", new LinkNode[]
            {
                new LinkNode("Bacon"),
                new LinkNode("Bacon"),
                new LinkNode("Bacon"),
                new LinkNode("Bacon"),
                new LinkNode("Bacon"),
                new LinkNode("Bacon"),
                new LinkNode("Bacon"),
                new LinkNode("Bacon"),
                new LinkNode("Bacon"),
                new LinkNode("Bacon")
            }),
            new MainNode("Leonardo DiCaprio", new LinkNode[]
            {
                new LinkNode("The Departed"),
                new LinkNode("Django Unchained"),
                new LinkNode("Titanic")
            }),
            new MainNode("Matt Damon", new LinkNode[]
            {
                new LinkNode("Good Will Hunting"),
                new LinkNode("Interstellar")
            }),
            new MainNode("Mystic River", new LinkNode[]
            {
                new LinkNode("Kevin Bacon"),
                new LinkNode("Sean Penn")
            }),
            new MainNode("Pulp Fiction", new LinkNode[]
            {
                new LinkNode("Samuel L Jackson"),
                new LinkNode("Quentin Tarantino")
            }),
            new MainNode("Quentin Tarantino", new LinkNode[]
            {
                new LinkNode("Pulp Fiction"),
                new LinkNode("Django Unchained")
            }),
            new MainNode("Samuel L Jackson", new LinkNode[]
            {
                new LinkNode("Star Wars"),
                new LinkNode("Django Unchained"),
                new LinkNode("Pulp Fiction")
            }),
            new MainNode("Sean Connery", new LinkNode[]
            {
                new LinkNode("Indiana Jones"),
                new LinkNode("The Hunt for Red October")
            }),
            new MainNode("Sean Penn", new LinkNode[]
            {
                new LinkNode("Mystic River")
            }),
            new MainNode("Simon Pegg", new LinkNode[]
            {
                new LinkNode("Star Trek")
            }),
            new MainNode("Star Trek", new LinkNode[]
            {
                new LinkNode("Chris Pine"),
                new LinkNode("Simon Pegg")
            }),
            new MainNode("Star Wars", new LinkNode[]
            {
                new LinkNode("Harrison Ford"),
                new LinkNode("George Lucas"),
                new LinkNode("Samuel L Jackson")
            }),
            new MainNode("The Departed", new LinkNode[]
            {
                new LinkNode("Alec Baldwin"),
                new LinkNode("Leonardo DiCaprio"),
                new LinkNode("Matt Damon")
            }),
            new MainNode("The Hunt for Red October", new LinkNode[]
            {
                new LinkNode("Sean Connery"),
                new LinkNode("Alec Baldwin")
            }),
            new MainNode("The Sum of All Fears", new LinkNode[]
            {
                new LinkNode("Tom Clancy"),
                new LinkNode("Ben Affleck")
            }),
            new MainNode("Titanic", new LinkNode[]
            {
                new LinkNode("Leonardo DiCaprio"),
                new LinkNode("Bill Paxton")
            }),
            new MainNode("Tom Clancy", new LinkNode[]
            {
                new LinkNode("The Sum of All Fears"),
                new LinkNode("The Hunt for Red October")
            })
        };

        SpawnNodes();

        //init starting position
        Vector3 difference = cameraRigTransform.position - cameraHeadTransform.position;
        difference.y = 0;
        Vector3 offset = new Vector3(0.5f, -1f, 0.5f);
        GameObject startingObject = getMainNode("The Sum of All Fears");
        cameraRigTransform.position = startingObject.transform.position + difference + offset;
        cameraRigTransform.LookAt(startingObject.transform);
        cameraRigTransform.rotation = Quaternion.identity;
	}
}
