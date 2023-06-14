namespace Tilia.Visuals.Vignette
{
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Type;
    using Zinnia.Extension;
    using Zinnia.Process;
    using Zinnia.Tracking.Velocity;

    /// <summary>
    /// Configures Vignette prefab based on the provided settings.
    /// </summary>
    public class VignetteConfigurator : MonoBehaviour, IProcessable
    {
        #region Facade Settings
        [Header("Facade Settings")]
        [Tooltip("The public interface facade.")]
        [SerializeField]
        [Restricted]
        private VignetteFacade facade;
        /// <summary>
        /// The public interface facade.
        /// </summary>
        public VignetteFacade Facade
        {
            get
            {
                return facade;
            }
            set
            {
                facade = value;
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The lower and upper limit of the combined velocity magnitude to consider none to full velocity.")]
        [SerializeField]
        [MinMaxRange(0f, 1f)]
        private FloatRange magnitudeLimit = new FloatRange(0f, 0.7f);
        /// <summary>
        /// The lower and upper limit of the combined velocity magnitude to consider none to full velocity.
        /// </summary>
        public FloatRange MagnitudeLimit
        {
            get
            {
                return magnitudeLimit;
            }
            set
            {
                magnitudeLimit = value;
            }
        }
        [Tooltip("The threshold value above 0f to consider the smoothing value as 0f.")]
        [SerializeField]
        private float smoothingLowerThreshold = 0.001f;
        /// <summary>
        /// The threshold value above 0f to consider the smoothing value as 0f.
        /// </summary>
        public float SmoothingLowerThreshold
        {
            get
            {
                return smoothingLowerThreshold;
            }
            set
            {
                smoothingLowerThreshold = value;
            }
        }
        [Tooltip("The factor of decimal places to round the smoothing value.")]
        [SerializeField]
        private int smoothingRoundingFactor = 3;
        /// <summary>
        /// The factor of decimal places to round the smoothing value.
        /// </summary>
        public int SmoothingRoundingFactor
        {
            get
            {
                return smoothingRoundingFactor;
            }
            set
            {
                smoothingRoundingFactor = value;
            }
        }
        [Tooltip("The Renderer to modify.")]
        [SerializeField]
        [Restricted]
        private Renderer vignetteMesh;
        /// <summary>
        /// The <see cref="Renderer"/> to modify.
        /// </summary>
        public Renderer VignetteMesh
        {
            get
            {
                return vignetteMesh;
            }
            set
            {
                vignetteMesh = value;
            }
        }
        [Tooltip("The VelocityTracker for tracking velocity.")]
        [SerializeField]
        [Restricted]
        private AverageVelocityEstimatorProcess velocityTracker;
        /// <summary>
        /// The <see cref="AverageVelocityEstimatorProcess"/> for tracking velocity.
        /// </summary>
        public AverageVelocityEstimatorProcess VelocityTracker
        {
            get
            {
                return velocityTracker;
            }
            set
            {
                velocityTracker = value;
            }
        }
        #endregion

        /// <summary>
        /// The material property block for updating the vignette material shader.
        /// </summary>
        protected MaterialPropertyBlock materialBlock;
        /// <summary>
        /// The current smoothed size value.
        /// </summary>
        protected float smoothedSize;
        /// <summary>
        /// The current smoothed velocity.
        /// </summary>
        protected float currentSmoothedVelocity;
        /// <summary>
        /// Whether the manual size is currently being applied.
        /// </summary>
        protected bool applyingManualSize;
        /// <summary>
        /// The manual size to apply.
        /// </summary>
        protected float manualSize;

        /// <summary>
        /// Sets the <see cref="Color"/> of the vignette fade effect.
        /// </summary>
        /// <param name="color">The color to use.</param>
        public virtual void SetColor(Color color)
        {
            materialBlock.SetColor("_Color", color);
            VignetteMesh.SetPropertyBlock(materialBlock);
        }

        /// <summary>
        /// Sets the size of the vignette fade effect with a larger number meaning more of the effect fills the view.
        /// </summary>
        /// <param name="size">The size to apply.</param>
        public virtual void SetSize(float size)
        {
            materialBlock.SetFloat("_Size", Mathf.Clamp01(1f - size));
            VignetteMesh.SetPropertyBlock(materialBlock);
        }

        /// <summary>
        /// Sets the feathering effect at the edge of the vignette effect.
        /// </summary>
        /// <param name="feather">The amount to feather by.</param>
        public virtual void SetFeather(float feather)
        {
            materialBlock.SetFloat("_Feather", Mathf.Clamp01(feather));
            VignetteMesh.SetPropertyBlock(materialBlock);
        }

        /// <summary>
        /// Sets the source of the velocity tracker.
        /// </summary>
        /// <param name="source">The source to track the velocity of.</param>
        public virtual void SetVelocitySource(GameObject source)
        {
            if (VelocityTracker == null)
            {
                return;
            }

            VelocityTracker.Source = source;
        }

        /// <summary>
        /// Apply a manual size to the vignette effect.
        /// </summary>
        /// <param name="size">The new size to apply.</param>
        public virtual void SetManualSize(float size)
        {
            manualSize = Mathf.Clamp01(size);
            applyingManualSize = true;
        }

        /// <summary>
        /// Processes the appropriate velocities on the given source to apply the vignette effect.
        /// </summary>
        public virtual void Process()
        {
            UpdateSize();
        }

        /// <summary>
        /// Updates the size of the vignette based on the current settings.
        /// </summary>
        protected virtual void UpdateSize()
        {
            float velocityMagnitude = GetVelocityMagnitude();
            float newSize = applyingManualSize ? manualSize : velocityMagnitude;

            smoothedSize = Mathf.SmoothDamp(smoothedSize, newSize, ref currentSmoothedVelocity, Facade.Duration);
            smoothedSize = smoothedSize.ApproxEquals(0f, SmoothingLowerThreshold) ? 0f : smoothedSize;

            float multiplier = Mathf.Pow(10.0f, (float)SmoothingRoundingFactor);
            float roundedSmoothedSize = Mathf.Round(smoothedSize * multiplier) / multiplier;
            float finalSize = Mathf.Lerp(Facade.SizeRange.minimum, Facade.SizeRange.maximum, roundedSmoothedSize);

            SetSize(applyingManualSize ? smoothedSize : finalSize);

            applyingManualSize = applyingManualSize && velocityMagnitude.ApproxEquals(0f);
        }

        /// <summary>
        /// Gets the Velocity Magnitude from the given velocity tracker source.
        /// </summary>
        /// <returns>The highest value from either the linear velocity or angular velocity of the source.</returns>
        protected virtual float GetVelocityMagnitude()
        {
            if (VelocityTracker == null)
            {
                return 0f;
            }

            float linearVelocity = (Facade.ApplyWith & VignetteFacade.ApplyTypes.Velocity) == 0 ? 0f : VelocityTracker.GetVelocity().magnitude;
            float angularVelocity = (Facade.ApplyWith & VignetteFacade.ApplyTypes.AngularVelocity) == 0 ? 0f : VelocityTracker.GetAngularVelocity().magnitude * 2f;
            return Mathf.InverseLerp(MagnitudeLimit.minimum, MagnitudeLimit.maximum, Mathf.Max(linearVelocity, angularVelocity));
        }

        protected virtual void OnEnable()
        {
            materialBlock = new MaterialPropertyBlock();
            SetColor(Facade.FadeColor);
            SetFeather(Facade.FeatherAmount);
            SetVelocitySource(Facade.VelocitySource);
        }
    }
}