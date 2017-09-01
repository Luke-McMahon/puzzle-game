using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTileMovement : MonoBehaviour {

    public int m_Moves = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
            m_Moves++;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
            m_Moves++;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
            m_Moves++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
            m_Moves++;
        }
    }
}
