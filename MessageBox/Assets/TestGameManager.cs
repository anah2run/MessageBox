using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGameManager : MonoBehaviour
{
    [SerializeField] private Text moneyText_;
    [SerializeField] private CustomMessageBox messageBox;
    public int money = 10000;

    private void Awake()
    {
        SetMoneyText();
    }

    public void ShowPurchaseMessageBox()
    {
        messageBox.Show("����","������ �����Ͻðڽ��ϱ�?",Purchase);
    }

    public void Purchase()
    {
        money -= 500;
        SetMoneyText();
    }

    private void SetMoneyText()
    {
        moneyText_.text = money.ToString();
    }
}
