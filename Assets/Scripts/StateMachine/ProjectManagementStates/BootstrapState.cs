public class BootstrapState : IState<Bootstrap>, IEnterable
{
    public Bootstrap Initializer { get; }

    public BootstrapState(Bootstrap initializer) => Initializer = initializer;

    public void OnEnter() => Initializer.StateMachine.SwitchState<InitialState>();
}