namespace MonteAdentro.Systems.Interaction.Contracts
{
    public interface IInteractable
    {
        string InteractionPrompt { get; }

        void Interact();
    }
}
