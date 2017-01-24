using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public Vector2 dest;
    public float speed = 1.0f;
    public float distance = 1.0f;
    public GameObject node;
    public GameObject player;
    public GameObject lastNode;
    public bool isConnected = false;

    public LineRenderer lr;
    int vertexCount = 2;
    public List<GameObject> Nodes = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        lr = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        lastNode = transform.gameObject;
        Nodes.Add(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
       transform.position = Vector2.MoveTowards(transform.position, dest, speed);

        if((Vector2)transform.position != dest)
        {
            if(Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                createNode();
            }
        }
        else if(!isConnected)
        {
            isConnected = true;

            while (Vector2.Distance(player.transform.position, lastNode.transform.position) > distance) {
                createNode();
            }
            lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();

            
        }

        RenderLine();
	}

    void RenderLine() {
        lr.numPositions= vertexCount;
        int i;
        for (i = 0; i < Nodes.Count; i++) {
            lr.SetPosition(i, Nodes[i].transform.position);
        }
        lr.SetPosition(i,player.transform.position);
    }

    void createNode()
    {
        Vector2 newPosition = player.transform.position - lastNode.transform.position;
        newPosition.Normalize();
        newPosition *= distance;
        newPosition += (Vector2)lastNode.transform.position;
        GameObject tempObj = Instantiate(node, newPosition, Quaternion.identity);
        tempObj.transform.SetParent(transform);
        lastNode.GetComponent<HingeJoint2D>().connectedBody = tempObj.GetComponent<Rigidbody2D>();
        lastNode = tempObj;

        Nodes.Add(lastNode);
        vertexCount++;
    }
}
 