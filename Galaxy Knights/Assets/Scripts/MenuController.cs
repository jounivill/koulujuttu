using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GUITexture Credits;

    void Start()
    {
        Credits.enabled = false;

    }

    public void OpenCredits()
    {
        Credits.enabled = true;
    }
    public void CloseCredits()
    {
        Credits.enabled = false;
    }
}
