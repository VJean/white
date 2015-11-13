using UnityEngine;
using System.Collections;

public class RayCasting : MonoBehaviour {
	
	public const int RAYCASTLENGTH = 100;	// Longueur du rayon issu de la caméra
	public GameObject paint;
	void Start () 
	{
	}
	
	void Update () 
	{
		// Le raycast attache un objet cliqué
		RaycastHit hitInfo;
		Ray ray = GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction * RAYCASTLENGTH, Color.blue);
		bool rayCasted = Physics.Raycast (ray, out hitInfo, RAYCASTLENGTH);
		
		if (Input.GetMouseButtonDown (0) && rayCasted)	// L'utilisateur vient de cliquer
		{
			var hitRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
			Instantiate(paint, hitInfo.point, hitRotation);
		}
	}
}
