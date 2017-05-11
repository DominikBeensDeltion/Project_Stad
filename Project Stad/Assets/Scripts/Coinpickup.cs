using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinpickup : MonoBehaviour {
    public int value;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDestroy()
    {
        GameManager.money += value;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
