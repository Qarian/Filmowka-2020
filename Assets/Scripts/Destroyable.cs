using UnityEngine;

namespace UnityTemplateProjects
{
    public class Destroyable : MonoBehaviour
    {
        [SerializeField] private float health = 100;

        public void DealDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
                Destroy();
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}