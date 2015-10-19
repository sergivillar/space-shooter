using UnityEngine;

public class WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Fire()
    {
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
    }
}
