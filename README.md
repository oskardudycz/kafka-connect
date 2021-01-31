![Twitter Follow](https://img.shields.io/twitter/follow/oskar_at_net?style=social) [![Github Sponsors](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=GitHub&link=https://github.com/sponsors/oskardudycz/)](https://github.com/sponsors/oskardudycz/) [![blog](https://img.shields.io/badge/blog-event--driven.io-brightgreen)](https://event-driven.io/)

# kafka-connect
Sample showing how to use Marten together with Docker and Kafka Connect.

See more about Marten in documentation: [link](jasperfx.github.io/marten/documentation/).

The aim of this example is to show how to model following flow:
   1. Marten is .NET framework that allows to store data in Posgres as Documents and Events. Document and Event Data is stored with document tables.
   2. Data from the Marten tables will be moved through Debezium framework with Postgres CDC mechanism (sink connector).
   
      2.1 Events table (`mt_events`) with Outbox pattern. See more [here](https://debezium.io/blog/2019/02/19/reliable-microservices-data-exchange-with-the-outbox-pattern/) and [there](https://debezium.io/documentation/reference/0.9/configuration/outbox-event-router.html).
      
      2.2 Document tables with "regular" approach.
      
   3. Debezium moves data to Kafka Connect and then to Kafka.
   4. Documents (`mt_doc_meetings`) are moved then to ElasticSearch through Kafka Connect sink connector.

How to run sample?
1. Run following docker commands:

   1.1. `docker-compose build` - to build image of the .NET sample app,
   
   1.2. `docker-compose up` - to start containers.
   
2. [Docker compose file](docker-compose.yml) has all needed setup to do the work:

   2.1. Postgres with Debezium preconfigured - see [config](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L7)
   
   2.1. Kafka-Conect - see [config](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L164)
   
   2.2. ElasticSearch - see [config](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L42)
   
   2.3. Zookeeper - see [config](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L75)
   
   2.4. Kafka - see [config](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L84)
   
   2.5. Avro Schema Registry - see [config](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L101)
   
   2.6. Kafka Rest - see [config](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L123)
   
   2.7. Sample .NET WebApi app with Marten - [config](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L213).
3. Besides the tools by themselves you can also use UIs:

   3.1. PGAdmin - http://localhost:5050 - see [config](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L28)
   
   3.2. Kafka Topics UI - http://localhost:8000 - see [config](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L143)
   
   3.3. Kibana - UI for ElasticSearch - http://localhost:5601 - see [config](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L59)
   
   3.4. Swagger for Marten WebApi - http://localhost:5000/swagger/index.html 
   
4. Started dockers already have test tables preconfigured - see [SQL script](https://github.com/oskardudycz/kafka-connect/blob/main/postgres/init.sql).
5. Connectors are configured via CURL - see [Script](https://github.com/oskardudycz/kafka-connect/blob/main/connect/scripts/init.sh) and run via [docker compose](https://github.com/oskardudycz/kafka-connect/blob/main/docker-compose.yml#L206).

## Links
- https://medium.com/trendyol-tech/debezium-with-simple-message-transformation-smt-4f5a80c85358


**Kafka Connect with Marten** is Copyright &copy; 2018-2021 [Oskar Dudycz](http://event-driven.io) and other contributors under the [MIT license](LICENSE).
