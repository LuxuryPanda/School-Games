using UnityEngine;


namespace BorysProductions.Gameplay
{
    [CreateAssetMenu(fileName = "Assets/_Flappy Mattei/Resources/EndlessConfiguration", menuName = "Flappy Mattei/GameModes Config/Endless Config", order = 0)]
    public class EndlessConfig : ScriptableObject
    {
        [Header("Game Settings")]
        public Vector3 playerStartPosition;
        [Space(10f)]
        public GameObject[] Ostacoli;
        [Space(10f)]
        public float spawnTime = 4f;
        
        [Header("Currency Stuff")]
        
        public bool allowCreatingCoins;
        public bool allowCreatingBolts;

        [Space(5f)]
        [Range(0f, 1f)]
        public float coinsFrequency = 0.02f;
        [Space(5f)]
        [Range(0f, 1f)]
        public float boltsFrequency = 0.2f;
    }
}