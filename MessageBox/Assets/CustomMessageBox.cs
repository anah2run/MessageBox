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
        // �޽��� �ڽ� ���� ����
        title_.text = title;
        content_.text = content;
        Accept_ = Accept + Hide;
        Cancel_ = Cancel + Hide;

        // ��ư�� �ݹ� �޼ҵ� �ο�
        okBtn_.onClick.RemoveAllListeners();
        okBtn_.onClick.AddListener(ClickAcceptBtn);
        cancelBtn_.onClick.RemoveAllListeners();
        cancelBtn_.onClick.AddListener(ClickCancelBtn);

        // �����ֱ�
        gameObject.SetActive(true);

        // UI���� ���� ���� ǥ��
        transform.SetAsLastSibling();
    }
    public void Hide()
    {
        // ���߱�
        gameObject.SetActive(false);
    }

    private void ClickAcceptBtn() // ��ư�� ���� wrapper
    {
        Accept_();
    }
    private void ClickCancelBtn()
    {
        Cancel_();
    }
}
