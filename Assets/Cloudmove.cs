using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloudmove : MonoBehaviour
{

	public float speed = 10;

	private Vector3 obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= new Vector3 (Mathf.Sin (Time.time) * speed, obj.y, transform.position.z);
    }
}
