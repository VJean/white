using UnityEngine;
using System.Collections;

public class ThrowPaintDrops : MonoBehaviour {
	public Transform paintDropPrefab;


	private const int RAYCASTLENGTH = 100;
	// Max Ammunition
	private const int MAX_AMMO = 200;
	private int currentAmmo;
	// the higher it is, the slower the drops are instantiated
	private const int GENERATION_LIMIT = 3;
	private int generationCounter;

	// Use this for initialization
	void Start () {
		ResetCounter();
		ResetAmmo();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = GetComponentInChildren<Camera>().ScreenPointToRay(GameInputManager.Instance.GetPointerPosition());
		//Debug.Log ("ray direction " + ray.direction);
		Debug.DrawRay(ray.origin, ray.direction * RAYCASTLENGTH, Color.green);

		if (GameInputManager.Instance.GetButtonThrowPaint())
		{
			++generationCounter;

			if (generationCounter > GENERATION_LIMIT)
			{
				generationCounter = 0;

				if (currentAmmo > 0){
					Transform drop = Instantiate(paintDropPrefab, ray.origin + ray.direction, Quaternion.identity) as Transform;
					drop.gameObject.GetComponent<Rigidbody>().AddForce(ray.direction * 250);

					--currentAmmo;
					Debug.Log ("Ammo : " + currentAmmo.ToString());
				}
				else {
					Debug.Log("No ammo");
				}

			}
		}
		else if (GameInputManager.Instance.GetButtonUpThrowPaint())
		{
			ResetCounter();
		}

	}

	void OnTriggerEnter(Collider col){
		Debug.Log("Trigger : "+col.tag);
		if(col.CompareTag("Checkpoint")){
			Debug.Log("Entering Checkpoint");
			ResetAmmo();
		}

	}

	void ResetCounter() {
		generationCounter = GENERATION_LIMIT;
	}

	void ResetAmmo ()
	{
		currentAmmo = MAX_AMMO;
	}
}
