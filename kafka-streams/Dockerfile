FROM maven:3.5.4-jdk-10
WORKDIR /app
COPY pom.xml .
RUN mvn -B -f pom.xml -s /usr/share/maven/ref/settings-docker.xml dependency:resolve
RUN mvn install
COPY ./src ./src
RUN mvn -B -s /usr/share/maven/ref/settings-docker.xml package -DskipTests

ENTRYPOINT ["mvn", "exec:java", "-Dexec.mainClass=kafkastreamsapps.Pipe"]
# CMD ["mvn exec: -Dexec.mainClass=kafkastreamsapps.Pipe"]