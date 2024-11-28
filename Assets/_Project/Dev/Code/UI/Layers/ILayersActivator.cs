namespace PizzaMaker.Code.UI.Layers
{
    public interface ILayersActivator
    {
        void Enable(LayerId layerId);
        void Disable(LayerId layerId);
        void DisableAll();
    }
}