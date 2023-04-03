using UnityEngine;

namespace Bedroom_Objects
{
    [RequireComponent(typeof(Rigidbody))]
// ABSTRACTION
    public abstract class BedroomObject : MonoBehaviour
    {
        // ENCAPSULATION
        [SerializeField] protected Rigidbody objectRb;
        [SerializeField] private MeshRenderer meshRenderer;
    

        private void Start()
        {
            ObjectStartAction();
            SetColor();
            SaySomething();
        }

        // POLYMORPHISM
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
}
