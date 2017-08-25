using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;
	public float smoothing = 1;

	private float[] parallaxScales;
	private Transform cameraTransform;
	private Vector3 previousCameraPosition;

	void Awake() {
		cameraTransform = Camera.main.transform;
	}

	void Start() {
		previousCameraPosition = cameraTransform.position;

		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z * -1;
		}
	}

	// Update is called once per frame
	void Update() {
		for (int i = 0; i < backgrounds.Length; i++) {
			Transform background = backgrounds[i];

			float parallax = (previousCameraPosition.x - cameraTransform.position.x) * parallaxScales[i];
			float backgoundTargetPositionX = background.position.x + parallax;
			Vector3 backgroundTargetPosition = new Vector3(backgoundTargetPositionX, background.position.y, background.position.z);

			background.position = Vector3.Lerp(background.position, backgroundTargetPosition, smoothing * Time.deltaTime);
		}

		previousCameraPosition = cameraTransform.position;
	}
}
