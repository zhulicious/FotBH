using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class MoviePlayer : MonoBehaviour {

	public MovieTexture theMovie;


	void Start () {
		theMovie.Play();
	}

}
