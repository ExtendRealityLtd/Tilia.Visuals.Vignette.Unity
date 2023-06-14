# Class VignetteConfigurator

Configures Vignette prefab based on the provided settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [applyingManualSize]
  * [currentSmoothedVelocity]
  * [manualSize]
  * [materialBlock]
  * [smoothedSize]
* [Properties]
  * [Facade]
  * [MagnitudeLimit]
  * [SmoothingLowerThreshold]
  * [SmoothingRoundingFactor]
  * [VelocityTracker]
  * [VignetteMesh]
* [Methods]
  * [GetVelocityMagnitude()]
  * [OnEnable()]
  * [Process()]
  * [SetColor(Color)]
  * [SetFeather(Single)]
  * [SetManualSize(Single)]
  * [SetSize(Single)]
  * [SetVelocitySource(GameObject)]
  * [UpdateSize()]
* [Implements]

## Details

##### Inheritance

* System.Object
* VignetteConfigurator

##### Implements

IProcessable

##### Namespace

* [Tilia.Visuals.Vignette]

##### Syntax

```
public class VignetteConfigurator : MonoBehaviour
```

### Fields

#### applyingManualSize

Whether the manual size is currently being applied.

##### Declaration

```
protected bool applyingManualSize
```

#### currentSmoothedVelocity

The current smoothed velocity.

##### Declaration

```
protected float currentSmoothedVelocity
```

#### manualSize

The manual size to apply.

##### Declaration

```
protected float manualSize
```

#### materialBlock

The material property block for updating the vignette material shader.

##### Declaration

```
protected MaterialPropertyBlock materialBlock
```

#### smoothedSize

The current smoothed size value.

##### Declaration

```
protected float smoothedSize
```

### Properties

#### Facade

The public interface facade.

##### Declaration

```
public VignetteFacade Facade { get; set; }
```

#### MagnitudeLimit

The lower and upper limit of the combined velocity magnitude to consider none to full velocity.

##### Declaration

```
public FloatRange MagnitudeLimit { get; set; }
```

#### SmoothingLowerThreshold

The threshold value above 0f to consider the smoothing value as 0f.

##### Declaration

```
public float SmoothingLowerThreshold { get; set; }
```

#### SmoothingRoundingFactor

The factor of decimal places to round the smoothing value.

##### Declaration

```
public int SmoothingRoundingFactor { get; set; }
```

#### VelocityTracker

The AverageVelocityEstimatorProcess for tracking velocity.

##### Declaration

```
public AverageVelocityEstimatorProcess VelocityTracker { get; set; }
```

#### VignetteMesh

The Renderer to modify.

##### Declaration

```
public Renderer VignetteMesh { get; set; }
```

### Methods

#### GetVelocityMagnitude()

Gets the Velocity Magnitude from the given velocity tracker source.

##### Declaration

```
protected virtual float GetVelocityMagnitude()
```

##### Returns

| Type | Description |
| --- | --- |
| System.Single | The highest value from either the linear velocity or angular velocity of the source. |

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### Process()

Processes the appropriate velocities on the given source to apply the vignette effect.

##### Declaration

```
public virtual void Process()
```

#### SetColor(Color)

Sets the Color of the vignette fade effect.

##### Declaration

```
public virtual void SetColor(Color color)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| Color | color | The color to use. |

#### SetFeather(Single)

Sets the feathering effect at the edge of the vignette effect.

##### Declaration

```
public virtual void SetFeather(float feather)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Single | feather | The amount to feather by. |

#### SetManualSize(Single)

Apply a manual size to the vignette effect.

##### Declaration

```
public virtual void SetManualSize(float size)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Single | size | The new size to apply. |

#### SetSize(Single)

Sets the size of the vignette fade effect with a larger number meaning more of the effect fills the view.

##### Declaration

```
public virtual void SetSize(float size)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Single | size | The size to apply. |

#### SetVelocitySource(GameObject)

Sets the source of the velocity tracker.

##### Declaration

```
public virtual void SetVelocitySource(GameObject source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | source | The source to track the velocity of. |

#### UpdateSize()

Updates the size of the vignette based on the current settings.

##### Declaration

```
protected virtual void UpdateSize()
```

### Implements

IProcessable

[Tilia.Visuals.Vignette]: README.md
[VignetteFacade]: VignetteFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[applyingManualSize]: #applyingManualSize
[currentSmoothedVelocity]: #currentSmoothedVelocity
[manualSize]: #manualSize
[materialBlock]: #materialBlock
[smoothedSize]: #smoothedSize
[Properties]: #Properties
[Facade]: #Facade
[MagnitudeLimit]: #MagnitudeLimit
[SmoothingLowerThreshold]: #SmoothingLowerThreshold
[SmoothingRoundingFactor]: #SmoothingRoundingFactor
[VelocityTracker]: #VelocityTracker
[VignetteMesh]: #VignetteMesh
[Methods]: #Methods
[GetVelocityMagnitude()]: #GetVelocityMagnitude
[OnEnable()]: #OnEnable
[Process()]: #Process
[SetColor(Color)]: #SetColorColor
[SetFeather(Single)]: #SetFeatherSingle
[SetManualSize(Single)]: #SetManualSizeSingle
[SetSize(Single)]: #SetSizeSingle
[SetVelocitySource(GameObject)]: #SetVelocitySourceGameObject
[UpdateSize()]: #UpdateSize
[Implements]: #Implements
