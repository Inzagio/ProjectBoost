using UnityEngine;
using UnityEngine.SceneManagement;


public class Rocket : MonoBehaviour
{
    Rigidbody _rigidBody;
    AudioSource _thrustAudio;
    [SerializeField] private float _rcsThrust = 100f;
    [SerializeField] private float _engineThrust = 250f;

    enum State
    {
        Alive,
        Dying,
        Transcending
    }

    State state = State.Alive;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _thrustAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            Rotate();
            Thrust();
            Drag();
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (state != State.Alive) return;
        var tag = collision.gameObject.tag;
        if (tag == "Finish")
        {
            state = State.Transcending;
            Invoke("LoadNextLevel", 1f);
        }
        else if (tag != "Friendly")
        {
            state = State.Dying;
            Invoke("LoadFirstLevel", 1f);
        }

    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadNextLevel()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
