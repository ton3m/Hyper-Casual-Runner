namespace PizzaMaker.Code.Services
{
    public interface ILoadingCurtain
    {
        public bool IsActive { get; }
        
        void Show();
        void Hide();
    }
}