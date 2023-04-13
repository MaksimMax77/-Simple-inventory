using UnityEngine;

namespace Items.Containers
{
    [CreateAssetMenu(fileName = "ArmorContainer", menuName = "ArmorContainer", order = 3)]
    public class ArmorContainer : ItemContainer
    {
        [SerializeField] private float _protection;
    }
}
