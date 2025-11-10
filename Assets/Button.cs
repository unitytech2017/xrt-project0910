using UnityEngine;

public class Button : MonoBehaviour
{
    // GameManager와 통신하기 위한 변수
    public GameManager gameManager;

    // 다른 Collider를 가진 오브젝트와 충돌이 시작될 때 호출됩니다.
    private void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 오브젝트의 태그가 "Hammer"인지 확인합니다.
        if (collision.gameObject.CompareTag("Hammer"))
        {
            // ▼▼▼ 여기에 Debug.Log 한 줄만 추가하면 되는 거였습니다! ▼▼▼
            Debug.Log("망치와 충돌! 내 태그는: " + gameObject.tag);

            // 이 스크립트가 붙어있는 버튼 자신의 태그를 확인합니다.
            if (gameObject.CompareTag("ButtonA"))
            {
                // A 버튼이라면 GameManager에게 A가 눌렸다고 알립니다.
                gameManager.ButtonAPressed();
            }
            else if (gameObject.CompareTag("ButtonB"))
            {
                // B 버튼이라면 GameManager에게 B가 눌렸다고 알립니다.
                gameManager.ButtonBPressed();
            }
        }
    }
}