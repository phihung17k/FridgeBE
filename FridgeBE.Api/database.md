pull mysql
- `docker run --name test-mysql -p 57779:3306 -e MYSQL_ROOT_PASSWORD=my-secret-pw -e MYSQL_DATABASE=fridge -d mysql:tag`
- host port : container port

run container with volume
- `docker run --name test-mysql -dp 57779:3306 --mount type=volume,src=vol-mysql,target=/etc/todos -e MYSQL_ROOT_PASSWORD=my-secret-pw -e MYSQL_DATABASE=fridge mysql`

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



mysql in migration dotnet
- Use annotation or configuration to specify Table name 
	- default table = name of DbSet (no DbSex exists, table = class name)
	- example: Entity 'Ingredient' => DbSet 'Ingredients' => Table 'Ingredients'
- Id auto generated in types: `guid, int`
- `string` is required and `string?` is optional
- Other Relationships: explicit in configuration

