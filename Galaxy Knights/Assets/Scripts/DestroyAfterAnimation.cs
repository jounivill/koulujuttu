using UnityEngine;
using System.Collections;

public class DestroyAfterAnimation : MonoBehaviour {

	void KillOnAnimationEnd () {
        Destroy(gameObject);
	}
}
