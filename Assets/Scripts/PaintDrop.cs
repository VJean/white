using UnityEngine;
using System.Collections;

public class PaintDrop : MonoBehaviour {
	public GameObject BlackSplash, 
		darkGraySplash, 
		lightGraySplash,
		ComparisonObject;

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
				InstantianteSpash(Quaternion.FromToRotation(Vector3.up,hitInfo.normal), hitInfo.point);
				//Instantiate(lightGraySplash, hitInfo.point, Quaternion.FromToRotation(Vector3.up,hitInfo.normal));
				Destroy(this.gameObject);
				break;
			}
		}

	}

	void InstantianteSpash(Quaternion rotation, Vector3 point){
		Debug.Log (Quaternion.Angle(rotation, ComparisonObject.transform.rotation));
		float angle = Quaternion.Angle (rotation, ComparisonObject.transform.rotation);
		GameObject Splash;
		if(angle >= 0 && angle <= 3){
			Splash = BlackSplash;
		}
		else if(angle > 3 && angle <= 50){
			Splash = lightGraySplash;
		}
		else {
			Splash = darkGraySplash;
		}
		Instantiate(Splash, point, rotation);
	}
}
