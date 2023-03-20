using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private GameManager gameManager;
    private GameObject Target;
    private BoxCollider targetBox;
    private Vector3 hitPos;
    public int damage = 10;
    private Rigidbody rb;
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
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Target = GetComponentInParent<Ship>().TargetShip;
        targetBox = Target.GetComponentInChildren<BoxCollider>();
        hitPos = GetRandomPointInsideCollider(targetBox);
        rb = GetComponent<Rigidbody>();
        rb.velocity = CalcBallisticVelocityVector(transform.position, hitPos, 30);
        gameObject.transform.parent = null;
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

    Vector3 CalcBallisticVelocityVector(Vector3 source, Vector3 target, float angle)
    {
        Vector3 direction = target - source;
        float h = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(a);
        distance += h / Mathf.Tan(a);

        // calculate velocity
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized;
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
