using UnityEngine;
using Invector.vCharacterController;  //引用 套件

public class Player : MonoBehaviour
{
    private float hp = 100;
    private Animator ani;



    ///連擊次數
    private int atkCount;

    ///計時器
    private float timer;
    [Header("連擊間隔時間"), Range(0, 3)]
    public float interval = 1;
    [Header("攻擊中心點")]
    public Transform atkPoint;
    [Header("攻擊長度"), Range(0f, 5f)]
    public float atkLength;
    [Header("攻擊力"), Range(0, 500)]
    public float atk = 30;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    /// <summary>
    /// 繪製圖示事件:僅在Unity內顯示
    /// </summary>
    private void OnDrawGizmos()
    {
        //圖示.顏色 = 紅色
        Gizmos.color = Color.green;
        //圖示.繪製射線(中心點，方向)
        //(攻擊中心點座標，攻擊中心點的前方 *攻擊長度)
        Gizmos.DrawRay(atkPoint.position, atkPoint.forward * atkLength);
    }

    ///射線擊中的物件
    private RaycastHit hit;

    private void Attack()
    {
        if (atkCount < 3)
        {
            if (timer < interval)
            {
                timer += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    atkCount++;
                    timer = 0;
                    if (Physics.Raycast(atkPoint.position, atkPoint.forward, out hit, atkLength, 1 << 9))
                    {
                        hit.collider.GetComponent<Enemy>().Damage(atk);
                    }
                }
            }
            else
            {
                atkCount = 0;
                timer = 0;
            }
        }
        if (atkCount == 3) atkCount = 0;
        ani.SetInteger("連技", atkCount);
    }

    ///受傷
    ///<param name="damage">接收的傷害值 </param>
    public void Damage(float damage)
    {
        hp -= damage;
        ani.SetTrigger("damage");
        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        ani.SetTrigger("die");

        //鎖定移動與旋轉
        vThirdPersonController vt = GetComponent<vThirdPersonController>();
        vt.lockMovement = true;
        vt.lockRotation = true;
    }
}
