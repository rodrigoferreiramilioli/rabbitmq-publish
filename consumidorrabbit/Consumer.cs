using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace consumidorrabbit
{
    public class Consumer
    {
        public bool Consumidor()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.Password = "guest";
            factory.Port = 7070;
            factory.UserName = "guest";

            var message = new MessageTransport();
            message.guid = Guid.NewGuid();
            message.message = "Esta é uma nova mensagem! Olá mundo";
            message.define = 0;
            message.nomeleitura = "meuservico.com/rota1";

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue:"MessageMeuServico", false, false, false, null);
            var menssagem = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(menssagem);
            channel.BasicPublish(exchange:"", routingKey: "MessageMeuServico", basicProperties: null, body: body);
            return true;
        }
    }
}
