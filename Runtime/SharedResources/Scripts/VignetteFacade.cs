namespace Tilia.Visuals.Vignette
{
    using System;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Type;
    using Zinnia.Extension;

    /// <summary>
    /// The public interface into the Vignette Prefab.
    /// </summary>
    public class VignetteFacade : MonoBehaviour
    {
        /// <summary>
        /// The types when to apply the vignette effect.
        /// </summary>
        [Flags]
        public enum ApplyTypes
        {
            /// <summary>
            /// The speed in a linear direction.
            /// </summary>
            Velocity = 1 << 0,
            /// <summary>
            /// The speed in a angular rotation.
            /// </summary>
            AngularVelocity = 1 << 1
        }

        #region Vignette Settings
        [Header("Vignette Settings")]
        [Tooltip("The source to obtain linear velocity from.")]
        [SerializeField]
        private GameObject velocitySource;
        /// <summary>
        /// The source to obtain linear velocity from.
        /// </summary>
        public GameObject VelocitySource
        {
            get
            {
                return velocitySource;
            }
            set
            {
                velocitySource = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterVelocitySourceChange();
                }
            }
        }
        [Tooltip("The types of velocity to listen for to apply the vignette effect.")]
        [SerializeField]
        [UnityFlags]
        private ApplyTypes applyWith = (ApplyTypes)(-1);
        /// <summary>
        /// The types of velocity to listen for to apply the vignette effect.
        /// </summary>
        public ApplyTypes ApplyWith
        {
            get
            {
                return applyWith;
            }
            set
            {
                applyWith = value;
            }
        }
        [Tooltip("The Color of the vignette.")]
        [SerializeField]
        private Color fadeColor = Color.black;
        /// <summary>
        /// The <see cref="Color"/> of the vignette.
        /// </summary>
        public Color FadeColor
        {
            get
            {
                return fadeColor;
            }
            set
            {
                fadeColor = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterVignetteColorChange();
                }
            }
        }
        [Tooltip("The size range of the vignette effect based on the amount of motion that is being applied.")]
        [SerializeField]
        [MinMaxRange(0f, 1f)]
        private FloatRange sizeRange = new FloatRange(0f, 0.1f);
        /// <summary>
        /// The size range of the vignette effect based on the amount of motion that is being applied.
        /// </summary>
        public FloatRange SizeRange
        {
            get
            {
                return sizeRange;
            }
            set
            {
                sizeRange = value;
            }
        }
        [Tooltip("The feather amount of the vingette outline.")]
        [SerializeField]
        private float featherAmount = 0.15f;
        /// <summary>
        /// The feather amount of the vingette outline.
        /// </summary>
        public float FeatherAmount
        {
            get
            {
                return featherAmount;
            }
            set
            {
                featherAmount = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterFeatherAmountChange();
                }
            }
        }
        [Tooltip("The time taken to smooth to the new vignette size.")]
        [SerializeField]
        private float duration = 0.15f;
        /// <summary>
        /// The time taken to smooth to the new vignette size.
        /// </summary>
        public float Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The linked Internal Setup.")]
        [SerializeField]
        [Restricted]
        private VignetteConfigurator configuration;
        /// <summary>
        /// The linked Internal Setup.
        /// </summary>
        public VignetteConfigurator Configuration
        {
            get
            {
                return configuration;
            }
            set
            {
                configuration = value;
            }
        }
        #endregion

        /// <summary>
        /// Sets the <see cref="SizeRange"/> minimum value.
        /// </summary>
        /// <param name="value">The new minimum value.</param>
        public virtual void SetSizeRangeMinimum(float value)
        {
            FloatRange newLimit = new FloatRange(SizeRange.ToVector2());
            newLimit.minimum = value;
            SizeRange = newLimit;
        }

        /// <summary>
        /// Sets the <see cref="SizeRange"/> maximum value.
        /// </summary>
        /// <param name="value">The new minimum value.</param>
        public virtual void SetSizeRangeMaximum(float value)
        {
            FloatRange newLimit = new FloatRange(SizeRange.ToVector2());
            newLimit.maximum = value;
            SizeRange = newLimit;
        }

        /// <summary>
        /// Sets the size of the vignette effect over the given duration.
        /// </summary>
        /// <param name="value">The new size to set between 0f and 1f.</param>
        public virtual void SetSize(float value)
        {
            Configuration.SetManualSize(value);
        }

        /// <summary>
        /// Adds the <see cref="ApplyTypes.Velocity"/> to the <see cref="ApplyWith"/> property.
        /// </summary>
        public virtual void AddApplyWithVelocity()
        {
            ApplyWith |= ApplyTypes.Velocity;
        }

        /// <summary>
        /// Removes the <see cref="ApplyTypes.Velocity"/> from the <see cref="ApplyWith"/> property.
        /// </summary>
        public virtual void RemoveApplyWithVelocity()
        {
            ApplyWith = ApplyWith & ~ApplyTypes.Velocity;
        }

        /// <summary>
        /// Adds the <see cref="ApplyTypes.AngularVelocity"/> to the <see cref="ApplyWith"/> property.
        /// </summary>
        public virtual void AddApplyWithAngularVelocity()
        {
            ApplyWith |= ApplyTypes.AngularVelocity;
        }

        /// <summary>
        /// Removes the <see cref="ApplyTypes.AngularVelocity"/> from the <see cref="ApplyWith"/> property.
        /// </summary>
        public virtual void RemoveApplyWithAngularVelocity()
        {
            ApplyWith = ApplyWith & ~ApplyTypes.AngularVelocity;
        }

        /// <summary>
        /// Called after <see cref="FadeColor"/> has been changed.
        /// </summary>
        protected virtual void OnAfterVignetteColorChange()
        {
            Configuration.SetColor(FadeColor);
        }

        /// <summary>
        /// Called after <see cref="FeatherAmount"/> has been changed.
        /// </summary>
        protected virtual void OnAfterFeatherAmountChange()
        {
            Configuration.SetFeather(FeatherAmount);
        }

        /// <summary>
        /// Called after <see cref="VelocitySource"/> has been changed.
        /// </summary>
        protected virtual void OnAfterVelocitySourceChange()
        {
            Configuration.SetVelocitySource(VelocitySource);
        }
    }
}