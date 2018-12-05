using RabbitMQ.Client;

namespace BusinessLogic.RabbitMq
{
    public class RabbitMqService
    {
        public static string SerialisationQueueName = "queue_MalerQ"; //Mail Transfer Agent
        public static string SerialisationExchangeName = "exchange_MalerQ";
        public static string SerialisationRoutingKey = "routingKey_MalerQ";

        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = "localhost";
            connectionFactory.UserName = "guest";
            connectionFactory.Password = "guest";

            return connectionFactory.CreateConnection();
        }

        public void SetupInitialTopicQueue(IModel model)
        {
            model.QueueDeclare(SerialisationQueueName, durable: true, exclusive: false, autoDelete: false);
            model.ExchangeDeclare(SerialisationExchangeName, ExchangeType.Direct);
            model.QueueBind(SerialisationQueueName, SerialisationExchangeName, SerialisationRoutingKey);
        }
    }
}
