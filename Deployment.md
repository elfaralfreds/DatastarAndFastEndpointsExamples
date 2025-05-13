# Fly.io

Create:
> flyctl apps create datastar-fastendpoints-demo --org personal

Deploy:
> flyctl deploy --config .\fly.demo.toml

Allocate IP:
> fly ips allocate-v4 --config .\fly.demo.toml --yes

Scale:
> flyctl scale count --config .\fly.demo.toml 1 --yes

Local build:
> podman build -f .\Dockerfile . -t demo --log-level debug

Local run: 
> podman run --rm --name demo -p 8080:8080 demo
