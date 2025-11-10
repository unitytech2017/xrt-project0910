using UnityEngine;

public class CollisionSoundPlayer : MonoBehaviour
{
    // 버튼 A와 충돌 시 재생할 오디오 클립
    public AudioClip soundForButtonA;
    // 버튼 B와 충돌 시 재생할 오디오 클립
    public AudioClip soundForButtonB;

    private AudioSource audioSource;

    void Start()
    {
        // AudioSource 컴포넌트를 미리 가져옵니다.
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 태그를 확인합니다.
        if (collision.gameObject.tag == "ButtonA")
        {
            // Button A 태그라면 soundForButtonA를 재생합니다.
            audioSource.PlayOneShot(soundForButtonA);
        }
        else if (collision.gameObject.tag == "ButtonB")
        {
            // Button B 태그라면 soundForButtonB를 재생합니다.
            audioSource.PlayOneShot(soundForButtonB);
        }
    }
}