using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;
	public float smoothing = 1;

	private float[] parallaxScales;
	private Transform cameraTranform;
	private Vector3 previousCameraPosition;

	void Awake() {
		camera = Camera.main.Transform;
	}

	void Start() {
		previousCameraPosition = camera.position;

		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z * -1;
		}
	}

	// Update is called once per frame
	void Update() {

	}
}
