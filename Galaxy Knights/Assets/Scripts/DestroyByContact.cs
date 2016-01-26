using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject SmallExplosion;
    public GameObject PlayerExplosion;

    void OnTriggerEnter(Collider other)  {

        Instantiate(SmallExplosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
