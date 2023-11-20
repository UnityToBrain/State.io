using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float Speed = 3f;
    public float DirectionScale = 1.5f;
    private Vector3 _targetPosition;
    public Transform enemy;
    private void Update()
    {
        // var offset = _targetPosition - transform.position;
        //
        // if (offset.sqrMagnitude > 8f)
        //     transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * Speed);
        // else
        //     transform.position = Vector3.Lerp(transform.position, enemy.position, Time.deltaTime * Speed);

    }

    public void Initialize(Vector3 target, float angle, Transform enemyCountry)
    {
        var direction = Quaternion.Euler(0, 0, angle) * (target - transform.position);
       _targetPosition = transform.position + direction * DirectionScale;
       enemy = enemyCountry;

       var offset =  _targetPosition - enemy.transform.position ;
       
       transform.GetComponent<Rigidbody>().AddForce(offset * 20f);
    }
}
