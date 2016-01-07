using UnityEngine;
using System.Collections;

public class ThrowPaintDrops : MonoBehaviour {
	public Transform paintDropPrefab;

	private const int RAYCASTLENGTH = 100;
	private const int generationRateLimit = 10;
	private int generationCounter;

	// Use this for initialization
	void Start () {
		ResetCounter();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = GetComponentInChildren<Camera>().ScreenPointToRay(GameInputManager.Instance.GetPointerPosition());
		//Debug.Log ("ray direction " + ray.direction);
		Debug.DrawRay(ray.origin, ray.direction * RAYCASTLENGTH, Color.green);

		if (GameInputManager.Instance.GetButtonThrowPaint())
		{
			++generationCounter;

			if (generationCounter > generationRateLimit)
			{
				generationCounter = 0;
				Transform drop = Instantiate(paintDropPrefab, ray.origin + ray.direction, Quaternion.identity) as Transform;
				drop.gameObject.GetComponent<Rigidbody>().AddForce(ray.direction * 250);
			}
		}
		else if (GameInputManager.Instance.GetButtonUpThrowPaint())
		{
			ResetCounter();
		}

	}

	void ResetCounter() {
		generationCounter = generationRateLimit;
	}
}
