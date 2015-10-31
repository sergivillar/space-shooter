using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public SimpleTouchPad touchPad;
    public SimpleTouchAreaButton areaButton;
    
    private float nextFire;
    private Quaternion calibrationQuaternion;
    
    void Start()
    {
        CalibrateAccelerometer();
    }

    void Update()
    {
        if (areaButton.CanFire() && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // GameObject clone =
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;

            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        // Vector3 accelerationRaw = Input.acceleration;
        // Vector3 acceleration = FixAccelleration(accelerationRaw);
        // Vector3 movement = new Vector3(acceleration.x, 0.0f, acceleration.y);
        
        Vector2 direction = touchPad.GetDirection();
        Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);

        Rigidbody rigibody = GetComponent<Rigidbody>();
        rigibody.velocity = movement * speed;

        rigibody.position = new Vector3
        (
                Mathf.Clamp(rigibody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
                Mathf.Clamp(rigibody.position.z, boundary.zMin, boundary.zMax)
        );

        rigibody.rotation = Quaternion.Euler(0.0f, 0.0f, rigibody.velocity.x * -tilt);
    }

    // User to calibrate Input.acceleration 
    void CalibrateAccelerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f , -1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    // Get the 'calibrated' value from the input
    Vector3 FixAccelleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }
}
