using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi.Tools
{
    public class RabbitMQHelper
    {        
        public static void Producing()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";//RabbitMQ服务在本地运行
            factory.UserName = "SampanLee";//用户名
            factory.Password = "123456";//密码
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello1", false, false, false, null);//创建一个名称为hello的消息队列
                    string message = "Hello World" + DateTime.Now.ToString("yyyy-MM-dd"); //传递的消息内容
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "hello1", null, body); //开始传递
                }
            }
        }
        public static string Consuming()
        {
            string result = string.Empty;
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "SampanLee";
            factory.Password = "123456";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    var consumer = new EventingBasicConsumer(channel);
                    channel.BasicConsume("hello", false, consumer);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        result= Encoding.UTF8.GetString(body);                        
                    };                    
                }
            }
            return result;
        }
    }
}
