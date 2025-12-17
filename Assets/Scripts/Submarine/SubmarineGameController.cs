using UnityEngine;

public class SubmarineGameController : MonoBehaviour
{
    public static SubmarineGameController Instance;

    [Header("Chest Settings")]
    public int totalChests = 5;
    private int collectedChests = 0;

    [Header("Quiz & Result")]
    public GameObject quizPanel;
    public QuizResultPanel resultPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    // =====================
    // CHEST LOGIC (AYNI)
    // =====================
    public void CollectChest()
    {
        collectedChests++;

        UpdateUI();

        if (collectedChests >= totalChests)
        {
            AllChestsCollected();
        }
    }

    private void UpdateUI()
    {
        SubmarineUI.Instance.UpdateChestUI(collectedChests, totalChests);
    }

    private void AllChestsCollected()
    {
        SubmarineUI.Instance.OpenQuizPanel();
    }

    // =====================
    // QUIZ FLOW (YENİ)
    // =====================

    // QuizManager burayı çağırır
    public void OnQuizFinished(int correctCount, int totalQuestions)
    {
        quizPanel.SetActive(false);
        resultPanel.ShowResult(correctCount, totalQuestions);
    }

    // =====================
    // UI BUTTON ACTIONS
    // =====================

    public void RestartSubmarine()
    {
        MiniGameManager.Instance.RestartCurrentGame();
    }

    public void ReturnToHub()
    {
        MiniGameManager.Instance.ReturnToHub();
    }
}
