﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
//Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
var factory = new ConnectionFactory
{
    HostName = "host.docker.internal",
};
//Create the RabbitMQ connection using connection factory details as i mentioned above
var connection = factory.CreateConnection();
//Here we create channel with session and model
using var channel = connection.CreateModel();
//declare the queue after mentioning name and a few property related to that
channel.QueueDeclare("orders", exclusive: false);
//Set Event object which listen message from chanel which is sent by producer
var consumer = new EventingBasicConsumer(channel);
 consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Order message received: {message}");
};
//read the message
channel.BasicConsume(queue: "orders", autoAck: true, consumer: consumer);

