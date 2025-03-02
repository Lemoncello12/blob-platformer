using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] saws;
    // Start is called before the first frame update
    void Start()
    {
        speed *= -10 * Mathf.Abs(saws[0].transform.localPosition.x);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);

        for (int i = 0; i < saws.Length; i++)
        {
            saws[i].transform.Rotate(0, 0, Time.deltaTime * -speed);
        }
    }
}
