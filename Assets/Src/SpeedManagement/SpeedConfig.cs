using UnityEngine;

namespace Src
{
    [CreateAssetMenu(fileName="Speed Config", menuName="Configs/Speed Config")]
    public class SpeedConfig : ScriptableObject
    {
        [SerializeField] private float maxSpeed;
        [SerializeField] private float defaultSpeed;

        public float MaxSpeed => maxSpeed;
        public float DefaultSpeed => defaultSpeed;
    }
}