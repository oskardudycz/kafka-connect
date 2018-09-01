curl -X POST -H "Accept:application/json" -H "Content-Type:application/json" connect:8083/connectors/ -d '
{
    "name": "postgres-connector",
    "config": {
        "connector.class": "io.debezium.connector.postgresql.PostgresConnector",
        "tasks.max": "1",
        "database.hostname": "postgres",
        "database.port": "5432",
        "database.user": "postgres",
        "database.password": "postgres",
        "database.dbname": "test",
        "database.server.name": "dbserver1",
        "transforms": "route",
        "transforms.route.type": "org.apache.kafka.connect.transforms.RegexRouter",
        "transforms.route.regex": "([^.]+)\\.([^.]+)\\.([^.]+)",
        "transforms.route.replacement": "$3",
        "name": "postgres-connector"
    }
}' && curl -X POST -H "Accept:application/json" -H "Content-Type:application/json" connect:8083/connectors/ -d '
{
    "name": "elastic-sink",
    "config": {
        "connector.class": "io.confluent.connect.elasticsearch.ElasticsearchSinkConnector",
        "tasks.max": "1",
        "topics": "test_table",
        "connection.url": "http://elastic:9200",
        "transforms": "unwrap,key",
        "transforms.unwrap.type": "io.debezium.transforms.UnwrapFromEnvelope",
        "transforms.key.type": "org.apache.kafka.connect.transforms.ExtractField$Key",
        "transforms.key.field": "id",
        "key.ignore": "false",
        "type.name": "test_table"
    }
}'