docker run -e ZOOKEEPER_CONNECT=zookeeper:2181 --network docker_connect_network -it --rm debezium/kafka list-topics

docker run -e ZOOKEEPER_CONNECT=zookeeper:2181 --network docker_connect_network -it --rm debezium/kafka watch-topic -a -k dbserver1.public.test_table