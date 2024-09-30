using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    [SerializeField] private bool isDay = true; // 現在が昼か夜かを保持

    private void Awake()
    {
        // シングルトンパターンの実装。すでにインスタンスが存在する場合は破棄。
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンが切り替わっても破棄されないようにする
        }
    }

    // 現在が昼か夜かを返すメソッド
    public bool IsDay()
    {
        return isDay;
    }

    // 昼夜を切り替えるメソッド
    public void ToggleDayNight()
    {
        isDay = !isDay;
        // 昼夜が切り替わったときの処理（必要に応じて追加）
        Debug.Log(isDay ? "現在は昼です。" : "現在は夜です。");
    }
}
