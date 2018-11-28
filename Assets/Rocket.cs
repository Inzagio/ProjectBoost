using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody _rigidBody;
    AudioSource _thrustAudio;
    [SerializeField] private float _rcsThrust = 100f;
    [SerializeField] private float _engineThrust = 250f;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _thrustAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Thrust();
        Drag();
    }

    private void Rotate()
    {
        _rigidBody.freezeRotation = true;

        float rotationThisFrame = _rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A)) //Left
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D)) //Right
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        _rigidBody.freezeRotation = false;
    }

    private void Thrust()
    {
        float thrustThisFrame = _engineThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            _rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);
            if (!_thrustAudio.isPlaying)
            {
                _thrustAudio.Play();
            }
        }
        else
        {
            _thrustAudio.Stop();
        }
    }
    private void Drag()
    {
        if (Input.GetKey(KeyCode.S))
        {
            _rigidBody.AddRelativeForce(Vector3.down);
        }
    }
}
