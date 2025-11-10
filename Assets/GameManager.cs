using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // --- 외부 연결 변수 (Inspector 창에서 설정) ---
    [Header("게임 설정")]
    public GameObject objectToScale;
    public float scaleIncreaseAmount = 0.1f;
    public AudioClip scaleUpSound; // [추가] 오브젝트가 커질 때 재생할 사운드 파일

    [Header("UI 설정")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI pressCountText;

    // --- 내부 게임 상태 변수 ---
    private float timeLeft = 100.0f;
    private int pressCount = 0;
    private bool isButtonATurn = true;
    private bool gameIsActive = true;
    private AudioSource audioSource; // [추가] 사운드를 재생할 AudioSource 컴포넌트

    void Start()
    {
        timerText.text = "Time: " + timeLeft.ToString("F2");
        pressCountText.text = "익살이 사이즈: " + pressCount;
        audioSource = GetComponent<AudioSource>(); // [추가] AudioSource 컴포넌트 가져오기
    }

    void Update()
    {
        if (gameIsActive)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Max(0, timeLeft).ToString("F2");

            if (timeLeft <= 0)
            {
                gameIsActive = false;
                timerText.text = "Time over";
            }
        }
    }

    public void ButtonAPressed()
    {
        if (gameIsActive && isButtonATurn)
        {
            ProcessInput();
            isButtonATurn = false;
        }
    }

    public void ButtonBPressed()
    {
        if (gameIsActive && !isButtonATurn)
        {
            ProcessInput();
            isButtonATurn = true;
        }
    }

    // 공통 처리 로직
    void ProcessInput()
    {
        // 오브젝트 크기 키우기
        objectToScale.transform.localScale += new Vector3(scaleIncreaseAmount, scaleIncreaseAmount, scaleIncreaseAmount);
        
        // ✨ 바로 여기! 크기를 키운 직후에 사운드를 재생합니다.
        if (audioSource != null && scaleUpSound != null)
        {
            audioSource.PlayOneShot(scaleUpSound);
        }

        // 카운트 증가 및 UI 업데이트
        pressCount++;
        pressCountText.text = "XRT: " + pressCount;
    }
}