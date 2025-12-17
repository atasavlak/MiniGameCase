using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("Questions")]
    public QuizQuestionSO[] questions;

    [Header("UI")]
    public TMP_Text questionText;
    public TMP_Text questionCounterText; // 1 / 5
    public TMP_Text pearlCounterText;    // correct / answered
    public Button[] optionButtons;

    [Header("Result")]
    public GameObject quizPanel;
    public QuizResultPanel resultPanel;


    private int currentQuestionIndex = 0;
    private int correctCount = 0;
    private int answeredCount = 0;

    private void Start()
    {
        UpdatePearlCounter();
        ShowQuestion();
    }

    private void ShowQuestion()
    {
        QuizQuestionSO q = questions[currentQuestionIndex];

        questionText.text = q.question;
        questionCounterText.text = (currentQuestionIndex + 1) + " / " + questions.Length;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i;

            optionButtons[i].GetComponentInChildren<TMP_Text>().text = q.options[i];
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => SelectAnswer(index));
        }
    }

    private void SelectAnswer(int selectedIndex)
    {
        answeredCount++;

        if (selectedIndex == questions[currentQuestionIndex].correctIndex)
        {
            correctCount++;
        }

        UpdatePearlCounter();

        currentQuestionIndex++;

        if (currentQuestionIndex >= questions.Length)
        {
            QuizFinished();
        }
        else
        {
            ShowQuestion();
        }
    }

    private void UpdatePearlCounter()
    {
        pearlCounterText.text = correctCount + " / " + answeredCount;
    }

    private void QuizFinished()
    {
        SubmarineGameController.Instance.OnQuizFinished(
            correctCount,
            questions.Length
        );
    }



}
