using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAmount;

    private void FixedUpdate()
    {
        //Rotate the object by a set amount over time
        transform.Rotate(rotationAmount);
    }
}
