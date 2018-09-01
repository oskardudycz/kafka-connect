using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

public class Program
{
    public static void Main()
    {
        var conf = new Dictionary<string, object>
    {
      { "group.id", "test-consumer-group" },
      { "bootstrap.servers", "127.0.0.1:9092" },
      { "auto.commit.interval.ms", 5000 },
      { "auto.offset.reset", "earliest" }
    };

        using (var consumer = new Consumer<string, string>(conf, new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8)))
        {
            consumer.OnMessage += (_, msg)
              => Console.WriteLine($"Read key: '{msg.Key}' from: {msg.TopicPartitionOffset} value:\n '{msg.Value}'");

            consumer.OnError += (_, error)
              => Console.WriteLine($"Error: {error}");

            consumer.OnConsumeError += (_, msg)
              => Console.WriteLine($"Consume error ({msg.TopicPartitionOffset}): {msg.Error}");

            consumer.Subscribe("test_table");

            while (true)
            {
                consumer.Poll(TimeSpan.FromMilliseconds(100));
            }
        }
    }
}