using UnityEngine;
using TMPro;
using System.Collections;

public class SubmarineUI : MonoBehaviour
{
    public static SubmarineUI Instance;

    public TMP_Text chestText;

    [Header("Panels")]
    public GameObject scoreUI;
    public GameObject quizPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateChestUI(int collected, int total)
    {
        chestText.text = collected + " / " + total;
    }

    public void OpenQuizPanel()
    {
        StartCoroutine(OpenQuizFlow());
    }

    private IEnumerator OpenQuizFlow()
    {

        // Çok kısa bir bekleme (isteğe bağlı ama hoş durur)
        yield return new WaitForSeconds(0.3f);
      
        // Önce ScoreUI kapansın
        if (scoreUI != null)
            scoreUI.SetActive(false);

        // Quiz açılsın
        if (quizPanel != null)
            quizPanel.SetActive(true);
    }
}
