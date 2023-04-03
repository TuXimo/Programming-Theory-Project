using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public abstract class BedroomObject : MonoBehaviour
{
    [SerializeField] protected Rigidbody objectRb;
    [SerializeField] private MeshRenderer meshRenderer;
    

    private void Start()
    {
        ObjectStartAction();
        SetColor();
        SaySomething();
    }

    protected virtual void ObjectStartAction()
    {
        float force = 100;
        objectRb.AddForce(Vector3.up * force * Time.deltaTime, ForceMode.Impulse);
    }

    protected abstract void SaySomething();

    private void SetColor()
    {
        meshRenderer.material.color = Color.cyan;
    }
}
