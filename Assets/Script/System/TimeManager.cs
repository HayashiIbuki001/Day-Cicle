using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    [SerializeField] private bool isDay = true; // ���݂������邩��ێ�

    private void Awake()
    {
        // �V���O���g���p�^�[���̎����B���łɃC���X�^���X�����݂���ꍇ�͔j���B
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����؂�ւ���Ă��j������Ȃ��悤�ɂ���
        }
    }

    // ���݂������邩��Ԃ����\�b�h
    public bool IsDay()
    {
        return isDay;
    }

    // �����؂�ւ��郁�\�b�h
    public void ToggleDayNight()
    {
        isDay = !isDay;
        // ���邪�؂�ւ�����Ƃ��̏����i�K�v�ɉ����Ēǉ��j
        Debug.Log(isDay ? "���݂͒��ł��B" : "���݂͖�ł��B");
    }
}
