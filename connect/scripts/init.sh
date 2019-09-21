
apk add --update curl && rm -rf /var/cache/apk/*

curl -X POST -H "Accept:application/json" -H "Content-Type:application/json" connect:8083/connectors/ -d '
{
    "name": "postgres-source-connector",
    "config": {
        "connector.class": "io.debezium.connector.postgresql.PostgresConnector",
        "tasks.max": "1",
        "database.hostname": "postgres",
        "database.port": "5432",
        "database.user": "postgres",
        "database.password": "Password12!",
        "database.dbname": "postgres",
        "database.server.name": "dbserver1",
        "key.converter": "io.confluent.connect.avro.AvroConverter",
        "key.converter.schema.registry.url": "http://schema_registry:8081",
        "value.converter": "io.confluent.connect.avro.AvroConverter",
        "value.converter.schema.registry.url": "http://schema_registry:8081",
        "table.whitelist": "public.test_table,meetingsmanagementread.mt_doc_meeting",
        "transforms": "route",
        "transforms.route.type": "org.apache.kafka.connect.transforms.RegexRouter",
        "transforms.route.regex": "([^.]+)\\.([^.]+)\\.([^.]+)",
        "transforms.route.replacement": "$3"
    }
}' && curl -X POST -H "Accept:application/json" -H "Content-Type:application/json" connect:8083/connectors/ -d '
{
    "name": "postgres-source-connector-events",
    "config": {
       "connector.class": "io.debezium.connector.postgresql.PostgresConnector",
        "tasks.max": "1",
        "database.hostname": "postgres",
        "database.port": "5432",
        "database.user": "postgres",
        "database.password": "Password12!",
        "database.dbname": "postgres",
        "database.server.name": "dbserver1",
        "table.whitelist" : "public.events",
        "tombstones.on.delete" : "false",
        "transforms": "outbox",
        "transforms.outbox.type": "io.debezium.transforms.outbox.EventRouter"
    }
}'  && curl -X POST -H "Accept:application/json" -H "Content-Type:application/json" connect:8083/connectors/ -d '
{
    "name": "postgres-source-connector-mt_events",
    "config": {
       "connector.class": "io.debezium.connector.postgresql.PostgresConnector",
        "tasks.max": "1",
        "database.hostname": "postgres",
        "database.port": "5432",
        "database.user": "postgres",
        "database.password": "Password12!",
        "database.dbname": "postgres",
        "database.server.name": "dbserver1",
        "table.whitelist" : "meetingsmanagementwrite.mt_events",
        "tombstones.on.delete" : "false",
        "transforms": "outbox",
        "transforms.outbox.type": "io.debezium.transforms.outbox.EventRouter"
        "table.field.event.id": "id",
        "table.field.event.key": "stream_id",
        "table.field.event.type": "type",
        "table.field.event.payload": "data",
        "table.field.event.payload.id": "stream_id",
        "route.by.field": "tenant_id"
    }
}' && curl -X POST -H "Accept:application/json" -H "Content-Type:application/json" connect:8083/connectors/ -d '
{
    "name": "elastic-connector-clients-sink_document",
    "config": {
        "connector.class": "io.confluent.connect.elasticsearch.ElasticsearchSinkConnector",
        "tasks.max": "1",
        "topics": "mt_doc_meeting",
        "connection.url": "http://elasticsearch:9200",
        "transforms": "unwrap,key",
        "transforms.unwrap.type": "io.debezium.transforms.UnwrapFromEnvelope",
        "transforms.key.type": "org.apache.kafka.connect.transforms.ExtractField$Key",
        "transforms.key.field": "id",
        "key.converter": "io.confluent.connect.avro.AvroConverter",
        "key.converter.schema.registry.url": "http://schema_registry:8081",
        "value.converter": "io.confluent.connect.avro.AvroConverter",
        "value.converter.schema.registry.url": "http://schema_registry:8081",
        "key.ignore": "false",
        "type.name": "meeting"
    }
}'