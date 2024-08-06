using DG.Tweening;
using Signals;
using UnityEngine;

namespace UIs
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject gamePanel;

        [SerializeField] private RectTransform startPanelEndPos;
        [SerializeField] private RectTransform startPanelInitialPos;
        private void Start()
        {
            settingsPanel.transform.localScale = Vector3.zero;
            startPanel.SetActive(true);
            settingsPanel.SetActive(true);
        }

        public void CloseButton()
        {
            startPanel.transform.DOMoveX(startPanelInitialPos.position.x, 0.2f).SetEase(Ease.InBack);
            settingsPanel.transform.DOScale(Vector3.zero, 0.2f);
        }
        public void SettingsButton()
        {
            startPanel.transform.DOMoveX(startPanelEndPos.position.x, 0.2f).SetEase(Ease.InBack);
            settingsPanel.transform.DOScale(Vector3.one * 0.8f, 0.2f);
        }
        public void InfoButton()
        {
            Application.OpenURL("https://github.com/BasarEkinci");
        }
        public void PlayButton()
        {
            startPanel.transform.DOMoveX(-443, 0.5f).SetEase(Ease.InBack);
            gamePanel.transform.DOScaleY(1, 0.1f);
            CoreGameSignals.Instance.OnGameStart?.Invoke();
        }
    }
}