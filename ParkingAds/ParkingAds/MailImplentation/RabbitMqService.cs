using RabbitMQ.Client;

namespace BusinessLogic.RabbitMq
{
    public class RabbitMqService
    {
        //Mail Transfer Agent
        public static string SerialisationQueueName = "queue_MalerQ"; 
        public static string SerialisationExchangeName = "exchange_MalerQ";
        public static string SerialisationRoutingKey = "routingKey_MalerQ";

        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            return connectionFactory.CreateConnection(); 
        }

        public void SetupInitialTopicQueue(IModel model)
        {
            model.QueueDeclare(SerialisationQueueName, durable: true, exclusive: false, autoDelete: false, null);
            model.ExchangeDeclare(SerialisationExchangeName, ExchangeType.Direct);
            model.QueueBind(SerialisationQueueName, SerialisationExchangeName, SerialisationRoutingKey);
        }
    }
}
