namespace Calcu.Infraestructure
{
    public interface IMessageProducer
    {
        void Produce(string message);
    }
}
