using UnityEngine;
using System.Collections;

public class PaintDrop : MonoBehaviour {
	public GameObject PaintSplash;

	public const float RAYCASTLENGTH = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray[] rays = new Ray[6];
		rays [0] = new Ray (transform.position, transform.forward);
		rays [1] = new Ray (transform.position, - transform.forward);
		rays [2] = new Ray (transform.position, transform.up);
		rays [3] = new Ray (transform.position, - transform.up);
		rays [4] = new Ray (transform.position, transform.right);
		rays [5] = new Ray(transform.position, - transform.right);

		foreach(Ray ray in rays){
			RaycastHit hitInfo;
			bool rayCasted = Physics.Raycast (ray, out hitInfo, RAYCASTLENGTH);
			if(rayCasted && hitInfo.transform.CompareTag("Paintable")){
				Instantiate(PaintSplash, hitInfo.point, Quaternion.FromToRotation(Vector3.up,hitInfo.normal));
				Destroy(this.gameObject);
				break;
			}
		}

	}
}
