using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject GamePanel;

    [Inject] private GameController GameController;

    public Text TitleText;

    public void ShowMenuPanel() {MenuPanel.SetActive(true);}

    public void HideMenuPanel() { MenuPanel.SetActive(false);}

    public void ShowGamePanel() { GamePanel.SetActive(true);}

    public void HideGamePanel() {GamePanel.SetActive(false);}

    public void SetTitle(string text) {
        TitleText.gameObject.SetActive(true);
        TitleText.text = text;
    }

    public void OnPlayBtnClicked() {
        GameController.Play();
    }

    public void OnExitBtnClicked() {
        GameController.Exit();
    }

    public void OnRestartBtnClicked() {
        GameController.Restart();
    }
}
