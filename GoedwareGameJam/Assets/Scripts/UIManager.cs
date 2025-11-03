using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] public Slider playerSlider;

    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TextMeshProUGUI endText;

    private void Update()
    {
        if (GameManager.Instance.huntTime)
        {
            timerText.color = Color.red;
        }
        else if (!GameManager.Instance.huntTime)
        {
            timerText.color = Color.white;
        }
    }

    public void EndPanel(bool isActive, string text)
    {
        Cursor.visible = true;
        endGamePanel.SetActive(isActive);
        endText.text = text;
    }

    public void UpdateTimer(float minutes, float seconds)
    {
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
