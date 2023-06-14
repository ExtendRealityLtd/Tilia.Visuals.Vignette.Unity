# Class VignetteFacade

The public interface into the Vignette Prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [ApplyWith]
  * [Configuration]
  * [Duration]
  * [FadeColor]
  * [FeatherAmount]
  * [SizeRange]
  * [VelocitySource]
* [Methods]
  * [AddApplyWithAngularVelocity()]
  * [AddApplyWithVelocity()]
  * [OnAfterFeatherAmountChange()]
  * [OnAfterVelocitySourceChange()]
  * [OnAfterVignetteColorChange()]
  * [RemoveApplyWithAngularVelocity()]
  * [RemoveApplyWithVelocity()]
  * [SetSize(Single)]
  * [SetSizeRangeMaximum(Single)]
  * [SetSizeRangeMinimum(Single)]

## Details

##### Inheritance

* System.Object
* VignetteFacade

##### Namespace

* [Tilia.Visuals.Vignette]

##### Syntax

```
public class VignetteFacade : MonoBehaviour
```

### Properties

#### ApplyWith

The types of velocity to listen for to apply the vignette effect.

##### Declaration

```
public VignetteFacade.ApplyTypes ApplyWith { get; set; }
```

#### Configuration

The linked Internal Setup.

##### Declaration

```
public VignetteConfigurator Configuration { get; set; }
```

#### Duration

The time taken to smooth to the new vignette size.

##### Declaration

```
public float Duration { get; set; }
```

#### FadeColor

The Color of the vignette.

##### Declaration

```
public Color FadeColor { get; set; }
```

#### FeatherAmount

The feather amount of the vingette outline.

##### Declaration

```
public float FeatherAmount { get; set; }
```

#### SizeRange

The size range of the vignette effect based on the amount of motion that is being applied.

##### Declaration

```
public FloatRange SizeRange { get; set; }
```

#### VelocitySource

The source to obtain linear velocity from.

##### Declaration

```
public GameObject VelocitySource { get; set; }
```

### Methods

#### AddApplyWithAngularVelocity()

Adds the [AngularVelocity] to the [ApplyWith] property.

##### Declaration

```
public virtual void AddApplyWithAngularVelocity()
```

#### AddApplyWithVelocity()

Adds the [Velocity] to the [ApplyWith] property.

##### Declaration

```
public virtual void AddApplyWithVelocity()
```

#### OnAfterFeatherAmountChange()

Called after [FeatherAmount] has been changed.

##### Declaration

```
protected virtual void OnAfterFeatherAmountChange()
```

#### OnAfterVelocitySourceChange()

Called after [VelocitySource] has been changed.

##### Declaration

```
protected virtual void OnAfterVelocitySourceChange()
```

#### OnAfterVignetteColorChange()

Called after [FadeColor] has been changed.

##### Declaration

```
protected virtual void OnAfterVignetteColorChange()
```

#### RemoveApplyWithAngularVelocity()

Removes the [AngularVelocity] from the [ApplyWith] property.

##### Declaration

```
public virtual void RemoveApplyWithAngularVelocity()
```

#### RemoveApplyWithVelocity()

Removes the [Velocity] from the [ApplyWith] property.

##### Declaration

```
public virtual void RemoveApplyWithVelocity()
```

#### SetSize(Single)

Sets the size of the vignette effect over the given duration.

##### Declaration

```
public virtual void SetSize(float value)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Single | value | The new size to set between 0f and 1f. |

#### SetSizeRangeMaximum(Single)

Sets the [SizeRange] maximum value.

##### Declaration

```
public virtual void SetSizeRangeMaximum(float value)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Single | value | The new minimum value. |

#### SetSizeRangeMinimum(Single)

Sets the [SizeRange] minimum value.

##### Declaration

```
public virtual void SetSizeRangeMinimum(float value)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Single | value | The new minimum value. |

[Tilia.Visuals.Vignette]: README.md
[VignetteFacade.ApplyTypes]: VignetteFacade.ApplyTypes.md
[VignetteConfigurator]: VignetteConfigurator.md
[AngularVelocity]: VignetteFacade.ApplyTypes.md#ApplyTypes_AngularVelocity
[ApplyWith]: VignetteFacade.md#ApplyWith
[Velocity]: VignetteFacade.ApplyTypes.md#ApplyTypes_Velocity
[ApplyWith]: VignetteFacade.md#ApplyWith
[FeatherAmount]: VignetteFacade.md#FeatherAmount
[VelocitySource]: VignetteFacade.md#VelocitySource
[FadeColor]: VignetteFacade.md#FadeColor
[AngularVelocity]: VignetteFacade.ApplyTypes.md#ApplyTypes_AngularVelocity
[ApplyWith]: VignetteFacade.md#ApplyWith
[Velocity]: VignetteFacade.ApplyTypes.md#ApplyTypes_Velocity
[ApplyWith]: VignetteFacade.md#ApplyWith
[SizeRange]: VignetteFacade.md#SizeRange
[SizeRange]: VignetteFacade.md#SizeRange
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ApplyWith]: #ApplyWith
[Configuration]: #Configuration
[Duration]: #Duration
[FadeColor]: #FadeColor
[FeatherAmount]: #FeatherAmount
[SizeRange]: #SizeRange
[VelocitySource]: #VelocitySource
[Methods]: #Methods
[AddApplyWithAngularVelocity()]: #AddApplyWithAngularVelocity
[AddApplyWithVelocity()]: #AddApplyWithVelocity
[OnAfterFeatherAmountChange()]: #OnAfterFeatherAmountChange
[OnAfterVelocitySourceChange()]: #OnAfterVelocitySourceChange
[OnAfterVignetteColorChange()]: #OnAfterVignetteColorChange
[RemoveApplyWithAngularVelocity()]: #RemoveApplyWithAngularVelocity
[RemoveApplyWithVelocity()]: #RemoveApplyWithVelocity
[SetSize(Single)]: #SetSizeSingle
[SetSizeRangeMaximum(Single)]: #SetSizeRangeMaximumSingle
[SetSizeRangeMinimum(Single)]: #SetSizeRangeMinimumSingle
