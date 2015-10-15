using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Boundary")
			return;
			
		Destroy(other.gameObject);
		Destroy(gameObject);
    }
}
