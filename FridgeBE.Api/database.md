pull mysql
- `docker run --name test-mysql -p 57779:3306 -e MYSQL_ROOT_PASSWORD=my-secret-pw -d mysql:tag`
- host port : container port

start stop container
- `docker start/stop [container]`

create new mysql monitor (connect mysql to run local)
- `docker run -it mysql /bin/bash`
- `bash-5.1# mysql -h 172.17.0.3 -u root -p` <=> `bash-5.1# mysql -h [host] -u[user] -p[pass]`

run the exist mysql container
- `docker exec -it [container] [image] -uroot -p`

mysql
- `show databases`
- `show tables`

docker
- `docker compose up --build`
- `docker compose down`