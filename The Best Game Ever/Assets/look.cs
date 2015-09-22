using UnityEngine;
using System.Collections;

public class look : MonoBehaviour {
	public float yaw;
	public float acyaw;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		acyaw = transform.rotation.eulerAngles.x;
		yaw = Input.GetAxis ("Mouse Y");
		//Debug.Log (yaw);
		if (acyaw > 90 && acyaw < 180)
			transform.Rotate( -20, 0, 0);;
		if (acyaw > 180 && acyaw < 270)
			transform.Rotate( -yaw, 0, 0);
		transform.Rotate( -yaw, 0, 0);
		//if (eulerAngles.x > 90) {
		
		//}

		Debug.Log(transform.rotation.eulerAngles.x);
	}
}
