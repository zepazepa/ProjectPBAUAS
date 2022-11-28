using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeGenerator : MonoBehaviour {
    public float TreeDistance = 2f;
    [Tooltip("Number of trees. Trees will be generated on the left and right side of the player.")]
    public int NumberOfTrees = 100;

	// Use this for initialization
	void Start () {
        // Generatr from the position of the car
        var player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            var position = player.transform.position;
            // Since the car moves along the Z axis, generate trees along the Z axis
            Vector3 treePos;
            GameObject p;
            for(int i = 0; i < NumberOfTrees; i ++)
            {
                // Left side
                treePos = new Vector3(position.x + 5, position.y - 1, position.z + i * TreeDistance);
                p = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                p.transform.position = treePos;
                // Right side
                treePos = new Vector3(position.x - 5, position.y - 1, position.z + i * TreeDistance);
                p = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                p.transform.position = treePos;
            }
        }
	}
}
