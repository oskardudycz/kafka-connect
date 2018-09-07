FROM maven:3.5.4-jdk-10
WORKDIR /app
COPY pom.xml .
RUN mvn -B -f pom.xml -s /usr/share/maven/ref/settings-docker.xml dependency:resolve
RUN mvn install
COPY ./src ./src
RUN mvn -B -s /usr/share/maven/ref/settings-docker.xml clean package -DskipTests

EXPOSE 8000/tcp

ENV MAVEN_OPTS=-Xdebug -Xrunjdwp:transport=dt_socket,server=y,suspend=y,address=8001

ENTRYPOINT ["mvn", "exec:java", "-Dexec.mainClass=kafkastreamsapps.Pipe"]