using UnityEngine;

[CreateAssetMenu(menuName = "Quiz/Question")]
public class QuizQuestionSO : ScriptableObject
{
    [TextArea]
    public string question;

    public string[] options = new string[3]; // 3 seçenek

    [Range(0, 2)]
    public int correctIndex;
}
