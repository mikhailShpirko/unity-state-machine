# State Machine implementation for Unity
Implementation of tate Machine pattern in Unity. Quick and easy to apply to any Unity project. And most importantly:
- NO ENUMS!
- NO MASSIVE SWITCH STATEMENTS!
- NO IMPLEMENTATION OF EMPTY METHODS!

I come up to this implementation while developing multiple projects. I decided to share this implementation as I find it efficient and easy to use.

The solution includes 2 interactive demo of the pattern applied for different cases.

## Demo: Game State
The example shows how to setup gameplay states (Loading, Play, Pause, Resume) and transitions between them. Open Assets/Scenes/Demo/DemoGamePlay.unity to try it out.

![alt text](https://github.com/mikhailShpirko/unity-state-machine/blob/main/demo1.png)

## Demo: Enemy Behaviour
The example shows how to setup enemy behaviour: patrol the area or follow player if in visibility range. Open Assets/Scenes/Demo/DemoEnemy.unity to try it out.

![alt text](https://github.com/mikhailShpirko/unity-state-machine/blob/main/demo2.png)

## Setup
1. Include all scripts from the following folders to your project 
   1. Assets/Scripts/StateMachine 
   2. Assets/Scripts/Events 
2. Implement BaseState abstraction with the logic for your states
   1. If you need to use Awake method, you need to override it like done below

```csharp
protected override void Awake()
{
    base.Awake();
  
    ...
}
```

   2. Be attentive using OnEnable and OnDisable methods. Entry/Exit of the state is done via enabling/disabling component, consider this upon using OnEnable and OnDisable methods in BaseState implementation
3. Implement BaseStateMachine abstraction with tany additional logic required for your case
   1. If you need to use Awake method, you need to override it like done below

```csharp
protected override void Awake()
{
    base.Awake();
  
    ...
}
```

4. Attach implementations of BaseState and BaseStateMachine to objects on a scene/s
5. Assign initial state to state machine component in the Editor


## Usage
Use function Transition of BaseStateMachine component to transition from current state to next desired state.

```csharp
/// <summary>
/// Transition from current state to next state provided as parameter
/// </summary>
/// <param name="nextState">State to be transitioned to</param>
public void Transition(BaseState nextState)
```

You can call this function from another component directly or attach it to event in the Editor as done in example demos.

Example:
```csharp
[SerializeField] //if you want to assign it in the Editor
private BaseStateMachine _enemyStateMachine; 

//or
private void Awake()
{
  _enemyStateMachine = FindObjectOfType<BaseStateMachine>();
}

...

//transition to the state attached to current object
_enemyStateMachine.Transition(FindObjectOfType<BaseState>());
```

## Additional notes
I used UnityEvent instead of C# event. Even though C# events are faster, you are not able to attach event listeners from the Editor. This results having tight coupling of components. Current implementation has loosly coupled components and all relationship between components and method calls can be setup in the Editor. However, if you feel that for your case you need to use C# event - feel free to adjust the abstractions in your implementation.

It might be a bit tricky to attach BaseState component as parameter to event listener in the Editor if there are several BaseState components attached to a object. This requires using 2 inspector tabs. Refer to this thread for detailed instruction how to achieve it: https://answers.unity.com/questions/1232762/how-to-drag-a-specific-component-reference-from-on.html

