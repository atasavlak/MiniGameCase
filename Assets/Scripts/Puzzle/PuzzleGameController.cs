using UnityEngine;

public class PuzzleGameController : MonoBehaviour
{
    public static PuzzleGameController Instance;

    public int totalPieces = 4;
    private int correctPlacedCount = 0;

    public GameObject completePanel;

    public AudioSource sfxSource;
    public AudioClip correctClip;
    public float completeDelay = 0.8f;
    
    private void Awake()
    {
        Instance = this;
    }

    public void NotifyCorrectPlacement()
    {
        correctPlacedCount++;

        if (sfxSource != null && correctClip != null)
            sfxSource.PlayOneShot(correctClip);

        if (correctPlacedCount >= totalPieces)
        Invoke(nameof(ShowCompletePanel), completeDelay);
    }

    private void ShowCompletePanel()
    {
        if (completePanel != null)
            completePanel.SetActive(true);
    }

    public void RestartPuzzle()
    {
        MiniGameManager.Instance.RestartCurrentGame();
    }

    public void ReturnToHub()
    {
        MiniGameManager.Instance.ReturnToHub();
    }

    public void PlayCorrectSfx()
    {
        if (sfxSource != null && correctClip != null)
            sfxSource.PlayOneShot(correctClip);
    }
}
