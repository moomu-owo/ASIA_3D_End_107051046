﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;       // 引用 系統.集合 API (包含協同程序)

public class MessengerBoard: MonoBehaviour
{
    [Header("Messenger 資料")]
    public MessengerData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval = 0.2f;

    // 定義列舉 eunm (下拉式選單 - 只能選一個)
    public enum NPCState
    {
       Propaganda, RollCall, Dairy, Opennote, Note
    }

    // 列舉欄位
    // 修飾詞 列舉名稱 自訂欄位名稱 指定 預設值；
    [Header("NPC 狀態")]
    public NPCState state = NPCState.Propaganda;

    /// <summary>
    /// 玩家是否進入感應區
    /// </summary>
    private bool playerInArea;

    /* 協同程序
    private void Start()
    {
        // 啟動協程
        StartCoroutine(Test());
    }
    private IEnumerator Test()
    {
        print("嗨~");
        yield return new WaitForSeconds(1.5f);
        print("嗨，我是一點五秒後");
        yield return new WaitForSeconds(2);
        print("嗨，又過去兩秒了");
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "amira")
        {
            playerInArea = true;
            StartCoroutine(Dialog());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "amira")
        {
            playerInArea = false;
            StopDialog();
        }
    }

    /// <summary>
    /// 停止對話
    /// </summary>
    private void StopDialog()
    {
        dialog.SetActive(false);    // 關閉對話框
        StopAllCoroutines();        // 停止所有協程
    }

    /// <summary>
    /// 開始對話
    /// </summary>
    private IEnumerator Dialog()
    {
        /**
        // print(data.dialogA);            // 取得字串全部資料
        // print(data.dialogA[0]);         // 取得字串局部資料：語法 [編號]
        // for 迴圈：重複處理相同程式
        //for (int i = 0; i < 10; i++)
        //{
        //    print("我是迴圈：" + i);
        //}
        //for (int apple = 1; apple < 100; apple++)
        //{
        //    print("迴圈：" + apple);
        //}
        */

        // 顯示對話框
        dialog.SetActive(true);
        // 清空文字
        textContent.text = "";
        // 對話者名稱 指定為 此物件的名稱
        textName.text = name;

        // 要說的對話
        string dialogString = data.dialogB;

        // 判斷 NPC 狀態 來顯示對應的 對話內容
        switch (state)
        {
            case NPCState.Propaganda:
                dialogString = data.dialogA;
                break;
            case NPCState.RollCall:
                dialogString = data.dialogB;
                break;
            case NPCState.Dairy:
                dialogString = data.dialogC;
                break;
            case NPCState.Opennote:
                dialogString = data.dialogD;
                break;
            case NPCState.Note:
                dialogString = data.dialogE;
                break;
        }

        // 字串的長度 dialogA.Length
        for (int i = 0; i < dialogString.Length; i++)
        {
            // print(data.dialogA[i]);
            // 文字 串聯 
            textContent.text += dialogString[i] + "";
            yield return new WaitForSeconds(interval);
        }
    }
}