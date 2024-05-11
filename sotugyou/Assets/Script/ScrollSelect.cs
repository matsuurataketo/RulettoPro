using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSelect : MonoBehaviour
{
    public Button[] buttons; // 左右のボタン
    public GameObject[] objectsToActivate;
    private int selectedIndex = 0; // 現在の選択インデックス
    private float selectionTime = 5f; // 選択時間
    private float currentTime = 0f; // 現在の経過時間

    void Start()
    {
        // 最初のボタンを選択状態にする
        SelectButton(selectedIndex);
    }

    void Update()
    {
        // マウススクロールの入力を受け取る
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // スクロール方向によって選択を変更する
        if (scroll > 0)
        {
            selectedIndex--; // 上にスクロール
            if (selectedIndex < 0)
                selectedIndex = buttons.Length - 1;
        }
        else if (scroll < 0)
        {
            selectedIndex++; // 下にスクロール
            if (selectedIndex >= buttons.Length)
                selectedIndex = 0;
        }

        // 選択されたボタンを更新する
        SelectButton(selectedIndex);

        // 選択が決定されるまでの時間をカウント
        currentTime += Time.deltaTime;
        if (currentTime >= selectionTime)
        {
            // 選択を決定する処理をここに追加する
            buttons[selectedIndex].onClick.Invoke();
            Debug.Log("Button " + selectedIndex + " selected!");
        }
    }

    // 指定したインデックスのボタンを選択状態にする
    void SelectButton(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            // インデックスが一致するボタンを選択状態にする
            buttons[i].interactable = (i == index);
        }
    }
    public void ActivateObjects()
    {
        if (selectedIndex == 0)
        {
            currentTime = 0f;
            objectsToActivate[1].SetActive(false);
            objectsToActivate[2].SetActive(false);
            objectsToActivate[0].SetActive(true);
        }
        else
        {
            currentTime = 0f;
            objectsToActivate[1].SetActive(false);
            objectsToActivate[2].SetActive(false);
            objectsToActivate[3].SetActive(true);
        }
       
    }
}
