# TravelRoute

![APIPublish](https://github.com/RodrigoPrandi/TravelRoute/workflows/APIPublish/badge.svg)

## Requisitos para execução

- Docker
- Dotnet (https://dotnet.microsoft.com/download/dotnet-core)

## Como executar a aplicação

###  1) API

Buildar imagem docker:

```bash
docker build --tag travelrouteapi:local .\Api\TravelRouteApi\
```

Executar imagem gerada local:

```bash
docker run --publish 44338:80 --detach --name travelrouteapi travelrouteapi:local
```

Encerrar execução:

```bash
docker stop travelrouteapi
```


###  2) Console

Após subir a API executar o seguinte comando:

```bash
bash console.sh CAMINHO_ARQUIVO
```

## Executar os testes

```bash
bash tests.sh
```

## Estrutura dos arquivos/pacotes

```bash
├── .github
│   ├── workflows
│   │    └── CI.yml (Arquivo de configuração do GitHub Actions, responsável por executar o build e deploy automatizado, rodando os testes)
├── Api
│   ├── TravelRouteApi (Projeto aplicação API rest)
│   └── TravelRouteApiTest (Projeto de testes unitários da API rest)
├── Console
│   ├── TravelRouteConsole (Projeto aplicação console)
│   └── TravelRouteConsole.Test (Projeto de testes unitários da console)
├── console.sh (Script para buildar e executar o console aplication)
├── tests.sh (Script para buildar e executar os testes unitários)
└── .gitignore

```

## Decisões de Desing

###  1) API

Foi criado uma aplicação web em Dotnet Core 3.1, para construção dos endpoints que serão os responsávies por manter as rotas do sistema, e possibilita realizar a consulta da melhor rota entre dois pontos considerando o menor valor total.

Como este cálculo e um problema clássico de grafos, realizei uma implementação do algorítimo de Dijkstra para realizar o cálculo da rota com o custo mais barato.

Durante o desenvolvimento foi aplicado o TDD para implementação do projeto em alguns momentos, principalmente nos testes dos cenários apresentados para garantir que a implementação do algorítimo estava passando nos cenários já apresentados, e nos demais calculados a mão.

Foi aplicado conceitos SOLID em ambos os projetos, para tornar as classes tom responsáblidades únicas, sem acoplamento, facilitando assim futuras manutenções e aumentando a qualidade do código.

Foi criado o Dockerfile para criação da imagen Docker para subir a aplicação de forma mais fácil. 

Disponibilizado na aplicação o Swagger para exibir a documentação da API e simplificar seu uso.

Por último foi criado o processo de CI do repositório usando o [GitHub Actions](https://github.com/RodrigoPrandi/TravelRoute/actions), onde a cada push na branch master é realizado o build dos projetos API e Console, é executado os testes de ambos os projetos, e também é publicado a imagem docker de cada build no próprio repositório para que possa ser baixado sem precisar realizar o build novamente.

###  2) Console

Criado uma aplicação console, que é iniciado com o arquivo CSV contendo as rotas e seus valores, onde essa aplicação realizar a inclusão dessas rotas na API atravéz do método POST disponibilizado.

Sistema faz o controle das ações do usuário  solicitando as informações necessárias da rota, realiza a consulta da melhor rota de acordo com o percurso informado e exibe o resultado para o usuário, reiniciando o processo novamente.

A Url base para chamada do serviço está parametrizada no arquivo appsettings.json, para que se houver uma mudaça na url ou porta possa ser alterado sem nenhuma compilação.


## Detalhe API Rest

- /api/route
  - Método POST: Inclui nova rota a partir do Json enviado no body:
  ```json
  {
    "from": "MGF",
    "to": "VCP",
    "value": 10
  }
  ```

- /api/bestroute?from=MGF&to=ASD
  - Método GET: Calcula e retorna o melhor caminho entre os parametros informados from e to.
  
  A documentação também pode ser verificada atravez do Swagger acessando o endereço base da API.
  ```
  https://localhost:44338/index.html
  ```
  
