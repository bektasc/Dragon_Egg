using System;
using UnityEngine;

namespace GameResources
{
    public class EggGenerator : MonoBehaviour
    {
        [SerializeField] private Receipt _receipt;
        [SerializeField] private Transform _generatePoint;

        private Action m_currentBehavior;

        private float m_timer;
        private float m_generateTime;

        public Eggs HoldingItem { get; set; }

        private void Start ()
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
            HoldingItem = Instantiate(_receipt._eggs, _generatePoint.position, Quaternion.identity);
        }

        private void StartGenerator()
        {
            m_currentBehavior = GenerateBehaviour;
        }

        private void IdleBehaviour()
        {
            m_currentBehavior = null;
        }


        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {

        }
    }
}