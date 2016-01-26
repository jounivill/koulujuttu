using UnityEngine;
using System.Collections;

public class LoadLevel1 : MonoBehaviour {

    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }
}