namespace Encurtador
{
    public interface IUrlCreatedEventPublisher
    {
        void PublishUrlCreatedEvent(string longUrl, string shortUrl);
    }
}
