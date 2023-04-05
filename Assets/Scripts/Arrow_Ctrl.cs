using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow_Ctrl : MonoBehaviour
{
    public GameObject archer;
    public GameObject warrior;

    public float speed = 1.0f;

    private float archerX;
    private float warriorX;

    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        archer = GameObject.FindGameObjectWithTag("Enemy");
        warrior = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        archerX = archer.transform.position.x;
        warriorX = warrior.transform.position.x;

        dist = warriorX - archerX;
        nextX = Mathf.MoveTowards(transform.position.x, warriorX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(archer.transform.position.y, warrior.transform.position.y, (nextX - archerX) / dist);
        height = 2 * (nextX - archerX) * (nextX - warriorX) / (-0.25f * dist * dist);

        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = LookAtWarrior(movePosition - transform.position);
        transform.position = movePosition;

        if (transform.position == warrior.transform.position)
        {
            warrior.GetComponent<Warrior_Ctrl>().curHp -= 10;
            Destroy(gameObject);
        }
    }

    public static Quaternion LookAtWarrior(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }

    
}
