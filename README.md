# Prometheus

## Quick start

- build docker image from `Server` by execcuting
```
docker build -t metrics ./Server/Dockerfile
```
- run compose to get containers running
```
docker-compose -f ./docker-compose.yaml up -d
```
- after containers are running, access prometheus GUI on http://localhost:9090
