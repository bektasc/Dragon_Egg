using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameResources
{
    public class EggGenerator : MonoBehaviour
    {
        [SerializeField] private Receipt _receipt;
        [SerializeField] private Receipt rareEgg;
        [SerializeField] private Transform _generatePoint;     

        private Action m_currentBehavior;

        private float m_timer;
        private float m_generateTime;
        private int probability;

        public Eggs HoldingItem { get; set; }

        private void Start()
        {
            m_generateTime = _receipt._GenerateTime;
            StartGenerator();
        }


        private void Update()
        {
            m_currentBehavior?.Invoke();
        }

        private void GenerateBehaviour()
        {
            if (m_timer < m_generateTime)
            {
                m_timer += Time.deltaTime;
            }
            else
            {
                GenerateItem();
                m_timer = 0;
                m_currentBehavior = IdleBehaviour;
            }
        }

        private void GenerateItem()
        {
            CallProbability();
            if (probability != 7) HoldingItem = Instantiate(_receipt._eggs, _generatePoint.position, Quaternion.identity);
            if (probability == 7) HoldingItem = Instantiate(rareEgg._eggs, _generatePoint.position, Quaternion.identity);
        }

        private void StartGenerator()
        {
            m_currentBehavior = GenerateBehaviour;
        }

        private void IdleBehaviour()
        {
            m_currentBehavior = null;
        }

        public void Restart()
        {
            StartGenerator();
        }

        private void CallProbability()
        {
            if (_receipt._eggs.name == "Wind Dragon Egg") probability = Random.Range(1, 20000);
            if (_receipt._eggs.name == "Sky Dragon Egg") probability = Random.Range(1, 10000);
            if (_receipt._eggs.name == "Soul Dragon Egg") probability = Random.Range(1, 5000);
            if (_receipt._eggs.name == "Fire Dragon Egg") probability = Random.Range(1, 2000);
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }
    }
}