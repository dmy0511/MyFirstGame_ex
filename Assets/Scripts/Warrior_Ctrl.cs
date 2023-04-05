using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warrior_Ctrl : MonoBehaviour
{
    float h = 0.0f;
    float v = 0.0f;

    Vector3 moveDir = Vector3.zero;

    Vector3 HalfSize = Vector3.zero;
    Vector3 m_CacCurPos = Vector3.zero;

    private float moveSpeed = 5.0f;
    private Vector3 moveDirection = Vector3.zero;

    [SerializeField]
    private Slider hpbar;

    public float maxHp = 100;
    public float curHp = 100;

    // Start is called before the first frame update
    void Start()
    {
        hpbar.value = curHp / maxHp;
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300f);
        }

        moveDirection = new Vector3(x, 0, 0);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        HandleHp();

        h = Input.GetAxis("Horizontal");    //  -1.0f ~ 1.0f
        v = Input.GetAxis("Vertical");

        if (h != 0.0f || v != 0.0f)
        {
            moveDir = new Vector3(h, v, 0);
            if (1.0f < moveDir.magnitude)
                moveDir.Normalize();
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        LimitMove();
    }

    void LimitMove()
    {
        m_CacCurPos = transform.position;

        if (m_CacCurPos.x < CameraResolution.m_ScreenWMin.x + HalfSize.x)
            m_CacCurPos.x = CameraResolution.m_ScreenWMin.x + HalfSize.x;

        if (CameraResolution.m_ScreenWMax.x - HalfSize.x < m_CacCurPos.x)
            m_CacCurPos.x = CameraResolution.m_ScreenWMax.x - HalfSize.x;

        if (m_CacCurPos.y < CameraResolution.m_ScreenWMin.y + HalfSize.y)
            m_CacCurPos.y = CameraResolution.m_ScreenWMin.y + HalfSize.y;

        if (CameraResolution.m_ScreenWMax.y - HalfSize.y < m_CacCurPos.y)
            m_CacCurPos.y = CameraResolution.m_ScreenWMax.y - HalfSize.y;

        transform.position = m_CacCurPos;
    }

    private void HandleHp()
    {
        hpbar.value = curHp / maxHp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Bullet"))
        //{
        //    curHp -= 10;
        //}
    }
}
