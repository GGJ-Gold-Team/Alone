using UnityEngine;

public class PlayerAudioManager : MonoBehaviour {
    [SerializeField] AudioSource walkingSnowAudioSource;
    [SerializeField] AudioSource walkingCabinAudioSource;

    [SerializeField] LayerMask cabinLayer;
    [SerializeField] LayerMask terrainLayer;

    bool isPlaying;
    float magnitude;
    Rigidbody rigidbody;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        isPlaying = walkingCabinAudioSource.isPlaying || walkingSnowAudioSource.isPlaying;
        magnitude = Vector3.Magnitude(rigidbody.velocity);

        if (magnitude > 0.5f) {
            PlayWalkAudio();
        } else {
            StopWalkAudio();
        }
    }

    void PlayWalkAudio() {
        if (!isPlaying) {
            AudioSource source = walkingSnowAudioSource;
            RaycastHit cabinHit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out cabinHit, 2f, cabinLayer)) {
                source = walkingCabinAudioSource;
            }

            source.Play();
        }
    }

    void StopWalkAudio() {
        walkingCabinAudioSource.Stop();
        walkingSnowAudioSource.Stop();
    }
}
