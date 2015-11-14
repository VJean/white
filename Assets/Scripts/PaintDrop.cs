using UnityEngine;
using System.Collections;

public class PaintDrop : MonoBehaviour {
	public GameObject PaintSplash;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision colInfo){
		// Paint only paintable objects
		if (!colInfo.gameObject.CompareTag("Paintable"))
			return;

		Debug.Log("Paintdrop collision, "+colInfo.contacts.Length+" points");

		ContactPoint contact = colInfo.contacts[colInfo.contacts.Length - 1];

		Debug.Log("Collision normal : "+contact.normal);

		// Apply a paint splash decal onto the object we collided with
		Instantiate(PaintSplash, contact.point, Quaternion.FromToRotation(Vector3.up,contact.normal));

		// Destroy this paintdrop
		Destroy(this.gameObject);
	}
}
