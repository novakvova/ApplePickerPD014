using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chnceToChangeDireactions = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2);
    }
    void DropApple()
    {
        var apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if(pos.x<-leftAndRightEdge)
        {
            speed=Mathf.Abs(speed);
        }
        else if(pos.x>leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    private void FixedUpdate()
    {
        if(Random.value < chnceToChangeDireactions)
        {
            speed *= -1;
        }
    }
}
