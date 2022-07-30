using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomMessageBox : MonoBehaviour
{
    [SerializeField] private Text title_;
    [SerializeField] private Text content_;
    [SerializeField] private Button okBtn_;
    [SerializeField] private Button cancelBtn_;
    private event System.Action Accept_;
    private event System.Action Cancel_;

    private void Awake()
    {
        Hide();
    }

    public void Show(string title, string content, System.Action Accept, System.Action Cancel = null)
    {
        // 메시지 박스 내용 설정
        title_.text = title;
        content_.text = content;
        Accept_ = Accept + Hide;
        Cancel_ = Cancel + Hide;

        // 버튼에 콜백 메소드 부여
        okBtn_.onClick.RemoveAllListeners();
        okBtn_.onClick.AddListener(ClickAcceptBtn);
        cancelBtn_.onClick.RemoveAllListeners();
        cancelBtn_.onClick.AddListener(ClickCancelBtn);

        // 보여주기
        gameObject.SetActive(true);

        // UI에서 제일 위로 표시
        transform.SetAsLastSibling();
    }
    public void Hide()
    {
        // 감추기
        gameObject.SetActive(false);
    }

    private void ClickAcceptBtn() // 버튼을 위한 wrapper
    {
        Accept_();
    }
    private void ClickCancelBtn()
    {
        Cancel_();
    }
}
