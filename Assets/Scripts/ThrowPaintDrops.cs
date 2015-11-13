using UnityEngine;
using System.Collections;

public class ThrowPaintDrops : MonoBehaviour {
	public Transform paintDropPrefab;

	private const int RAYCASTLENGTH = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
				
		Debug.DrawRay(ray.origin, ray.direction * RAYCASTLENGTH, Color.green);
		
		if (Input.GetMouseButton(0))
		{
			Transform drop = Instantiate(paintDropPrefab, ray.origin, Quaternion.identity) as Transform;
			drop.gameObject.GetComponent<Rigidbody>().AddForce(ray.direction * 300);
		}

	}
}
