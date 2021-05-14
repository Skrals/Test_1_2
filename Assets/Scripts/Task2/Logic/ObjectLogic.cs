using UnityEngine;

public class ObjectLogic : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private Vector3 start;
    [SerializeField] private float distanceVector;
    void Start()
    {
        start = transform.position;
        speed = Data.objectSpeed;
        distance = Data.pathLenght;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        distanceVector = Vector3.Distance(start,transform.position);
        if(distanceVector >= distance)
        {
            Delete();
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
