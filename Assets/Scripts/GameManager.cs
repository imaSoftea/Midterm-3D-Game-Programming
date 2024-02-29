using UnityEngine;
using System.Collections; 
using TMPro;

public class GameManager : MonoBehaviour
{
    int enemyCount;
    int elapsedTime;

    public TextMeshProUGUI textCount;
    public TextMeshProUGUI textTime;

    public GameObject WinUI;
    public GameObject NormalUI;

    void Awake()
    {
        enemyCount = 0;
        elapsedTime = 0;
        textCount.text = "Aliens: 0";
        StartCoroutine(TimerTick());
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UpdateGuiCount(int change)
    {
        enemyCount += change;
        textCount.text = "Aliens: " + enemyCount;

        if(enemyCount <= 0)
        {
            NormalUI.SetActive(false);
            WinUI.SetActive(true);
        }
    }

    IEnumerator TimerTick()
    {
        while (true)
        {
            elapsedTime += 1;
            textTime.text = $"Elapsed: {elapsedTime}";
            yield return new WaitForSeconds(1f);
        }
    }

}
