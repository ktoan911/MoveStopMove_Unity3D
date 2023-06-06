using UnityEngine.UI;
using UnityEngine;

public class OnOffMusic : MonoBehaviour
{
    [SerializeField] private GameObject OffMusic;

    [SerializeField] private GameObject OnMusic;

    [SerializeField] private Button btnMusic;

    private void Start()
    {
        btnMusic.onClick.AddListener(SetMute);
    }

    private void SetMute()
    {
        if (OnMusic.activeSelf)
        {
            SoundManager.Ins.MuteMusic(true);
            OnMusic.SetActive(false);
            OffMusic.SetActive(true);
        }
        else if(OffMusic.activeSelf)
        {
            SoundManager.Ins.MuteMusic(false);
            OnMusic.SetActive(true);
            OffMusic.SetActive(false);
        }
    }
}
