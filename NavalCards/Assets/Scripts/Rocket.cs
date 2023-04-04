using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private GameObject Target;
    private BoxCollider targetBox;
    private Vector3 hitPos;
    public int damage = 10;
    private void Start()
    {
        if (gameObject.transform.parent.transform.parent.transform.parent.tag == "AllyShip")
        {
            gameObject.tag = "AllyBullet";
        }
        if (gameObject.transform.parent.transform.parent.transform.parent.tag == "EnemyShip")
        {
            gameObject.tag = "EnemyBullet";
        }
        Target = GetComponentInParent<Ship>().TargetShip;
        targetBox = Target.GetComponentInChildren<BoxCollider>();
        hitPos = GetRandomPointInsideCollider(targetBox);
        gameObject.transform.parent = null;
        MoveToPos();
    }

    public void MoveToPos()
    {
        Vector3 forward = transform.forward;
        GetComponent<Rigidbody>().AddForce(forward * 15, ForceMode.Impulse);
        //var step = 4 * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, hitPos, step);
    }

    //Geminin collideri üzerinde rastgele hit noktasý fonksiyonu
    public Vector3 GetRandomPointInsideCollider(BoxCollider boxCollider)
    {
        Vector3 extents = boxCollider.size / 2f;
        Vector3 point = new Vector3(
            Random.Range(-extents.x, extents.x),
            Random.Range(-extents.y, extents.y),
            Random.Range(-extents.z, extents.z)
        );

        return boxCollider.transform.TransformPoint(point);
    }

    private void Update()
    {
        //MoveToPos();
    }

    //Mermi gemiye isabet ederse
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyShip" && gameObject.tag == "AllyBullet" || other.tag == "AllyShip" && gameObject.tag == "EnemyBullet" || other.tag == "Ground")
        {
            //Çarpýþmada mermiyi yok ediyoruz.
            Destroy(gameObject);
        }
    }
}
