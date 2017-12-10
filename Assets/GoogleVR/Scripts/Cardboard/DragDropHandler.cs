using UnityEngine.EventSystems;

public interface DragDropHandler : IEventSystemHandler
{
    void HandleGazeTriggerStart(int index);
    void HandleGazeTriggerEnd();
}