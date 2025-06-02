using UnityEngine;

namespace VFXTools
{
    [ExecuteAlways]
    public class VFXController : MonoBehaviour
    {
        [Header("Paramètres Modifiables")]
        [SerializeField] private Color particleColor = Color.white; // Couleur des particules
        [SerializeField, Range(0f, 4f)] private float intensity = 1f; // Intensité (rateOverTime)
        [SerializeField] private Vector3 windDirection = Vector3.zero; // Direction et puissance du vent

        private ParticleSystem[] particleSystems; // Liste des systèmes de particules
        private float[] defaultRateOverTimeValues; // Valeurs par défaut rateOverTime pour chaque système de particules

        void Awake()
        {
            ApplySettings(); // Applique les paramètres dès le lancement
        }

        void OnValidate()
        {
            ApplySettings(); // Met à jour les paramètres en mode éditeur
        }

        void FindParticles()
        {
            particleSystems = GetComponentsInChildren<ParticleSystem>();
            defaultRateOverTimeValues = new float[particleSystems.Length];
        }

        private void ApplySettings()
        {
            if (particleSystems == null || particleSystems.Length == 0)
            {
                FindParticles();
            }

            for (int i = 0; i < particleSystems.Length; i++)
            {
                var ps = particleSystems[i];
                var main = ps.main;
                var emission = ps.emission;
                var velocityOverLifetime = ps.velocityOverLifetime;

                main.startColor = particleColor;

                if (defaultRateOverTimeValues[i] == 0f)
                {
                    defaultRateOverTimeValues[i] = emission.rateOverTime.constant;
                }

                var rate = emission.rateOverTime;

                if (rate.constant > 0f)
                {
                    rate.constant = defaultRateOverTimeValues[i] * intensity;
                }
                else
                {
                    rate.constantMin = defaultRateOverTimeValues[i] * intensity;
                    rate.constantMax = defaultRateOverTimeValues[i] * intensity;
                }

                emission.rateOverTime = rate;

                if (velocityOverLifetime.enabled)
                {
                    velocityOverLifetime.x = windDirection.x;
                    velocityOverLifetime.y = windDirection.y;
                    velocityOverLifetime.z = windDirection.z;
                }
            }
        }

        public void SetParticleColor(Color newColor)
        {
            particleColor = newColor;
            ApplySettings();
        }

        public void SetIntensity(float newIntensity)
        {
            intensity = Mathf.Clamp(newIntensity, 0f, 2f);
            ApplySettings();
        }

        public void SetWindDirection(Vector3 newWindDirection)
        {
            windDirection = newWindDirection;
            ApplySettings();
        }

        public Color GetParticleColor()
        {
            return particleColor;
        }

        public float GetIntensity()
        {
            return intensity;
        }

        public Vector3 GetWindDirection()
        {
            return windDirection;
        }
    }
}
