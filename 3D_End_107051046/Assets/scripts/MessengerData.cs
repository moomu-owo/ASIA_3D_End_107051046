using UnityEngine;

// ScriptableObject 腳本化物件
// 將腳本資料變成物件並保存在專案內

// 建立資源選單("檔案名稱"，"選單名稱")
[CreateAssetMenu(fileName = "NPC 資料", menuName = "MU/NPC 資料")]
public class MessengerData : ScriptableObject
{
    [Header("第一段對話"), TextArea(1, 5)]
    public string dialogA;
    [Header("第二段對話"), TextArea(1, 5)]
    public string dialogB;
    [Header("第三段對話"), TextArea(1, 5)]
    public string dialogC;
    [Header("第四段對話"), TextArea(1, 5)]
    public string dialogD;
    [Header("第五段對話"), TextArea(1, 5)]
    public string dialogE;
    [Header("莉莉絲的求救"), TextArea(1, 5)]
    public string dialogF;
   
}
