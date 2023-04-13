using UnityEngine;

namespace Items.Containers
{
    [CreateAssetMenu(fileName = "WeaponContainer", menuName = "WeaponContainer", order = 3)]
    public class WeaponContainer : ItemContainer
    {
        [SerializeField] private float _damage; 
    }
}
