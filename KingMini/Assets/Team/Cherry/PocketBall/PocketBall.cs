using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketBall : MonoBehaviour
{
    public GameObject WhiteBall;
    public List<GameObject> RedBalls = new List<GameObject>();
    public GameObject RedBall2;

    Transform Target1;
    Transform Target2;
    Rigidbody white;

    // Start is called before the first frame update
    void Start()
    {
        white = WhiteBall.GetComponent<Rigidbody>();
        StartCoroutine("moveBall");
    }

    IEnumerator moveBall()
    {
        while (true)
        {

            int rand = Random.Range(0, RedBalls.Count);
            while (RedBalls[rand] == null || RedBalls[rand].activeSelf == false) {
                rand = Random.Range(0, RedBalls.Count);
            }

            Vector3 l_vector = RedBalls[rand].transform.position - WhiteBall.transform.position;
            WhiteBall.transform.rotation = Quaternion.LookRotation(l_vector).normalized;

           // WhiteBall.transform.LookAt(RedBall.transform);
            white.AddForce(l_vector.normalized * 2000f, ForceMode.Force);
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // WhiteBall.transform.position = Vector3.MoveTowards(WhiteBall.transform.position, Target.position, 2f * Time.deltaTime);
        
    }
}
