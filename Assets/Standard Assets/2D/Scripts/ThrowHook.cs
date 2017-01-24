using System.Collections;
using UnityEngine;

public class ThrowHook : MonoBehaviour
{
    public GameObject hook; // Holds the hook prefab.

    GameObject curHook; // Keeps a reference of the hook that was created.

    public bool ropeActive;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0)) // Check if there is a left mouse click
        {
            if (!ropeActive)
            {
                Vector2 dest = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Converts from screen coordinates to the coordinates in the game world.
                curHook = Instantiate(hook, transform.position, Quaternion.identity);
                curHook.GetComponent<RopeScript>().dest = dest;
                ropeActive = true;
            }
            else {
                Destroy(curHook);
                ropeActive = false;
            }
        }
	}
}
