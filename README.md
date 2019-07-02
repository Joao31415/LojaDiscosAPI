README.md

# Loja de Discos - API


## Pré-requisito para rodar o serviço:
* * *
Acesse abaixo para obter uma *API Key* para ter acesso à API do Last.fm:
https://secure.last.fm/login?next=/api/account/create

Na pasta raiz do projeto, abra o arquivo '**settings.json**' e insira sua *API Key* do Last.fm
Exemplo:

`"Lastfm_ApiKey" : "37373737a7a7a634398cb"`

## Gerando o projeto
* * *
Abra um "Prompt de comando" na pasta raiz do projeto e execute:

`dotnet build `


## Executando o projeto
* * *
Ainda na pasta raiz do projeto, execute:

`dotnet run`

O projeto indicará a porta (https) onde a api está rodando.

## Acessando as APIs
* * *
O serviço pode ser acessado utilizando o seu Browser ou via [Postman](https://www.getpostman.com/downloads/)

O primeiro passo para executar o serviço é popular o catálogo com alguns Discos obtidos do Last.fm. Para facilitar este processo, isso será feito automaticamente na primeira vez que a API de *Discos* for acessada.

### API *Disco*
* * *

- Obter todos os discos de forma paginada, filtrando por gênero e ordenando de forma crescente pelo nome do disco.
Exemplos (acesso via GET):
```
https://localhost:5001/api/disco/

https://localhost:5001/api/disco?Filters=genero==rock&Sorts=nome&page=1&pageSize=15
```

- Consultar o disco pelo seu identificador
Exemplo (acesso via GET):
```
https://localhost:44304/api/disco/99
```

### API *Venda*
* * *
- Registrar uma nova venda de discos calculando o valor total de cashback.
Exemplo (acesso via POST):
Formato do Json que deve ir no *Body*:
```
{
	"id_Cliente": 3,
	"data": "2019-07-03T17:00:00.0Z",
	"produtos": [
		{
			"id_Disco": 95
		},
		{
			"id_Disco": 199
		}
	]
}
```
onde *id_Disco* é o ID do disco de cada disco comprado.
```
https://localhost:44304/api/Venda/
```
- Consultar todas as vendas efetuadas de forma paginada, filtrando pelo range de datas (inicial e final) da venda e ordenando de forma decrescente pela data da venda.
Exemplos (acesso via GET):
```
https://localhost:5001/api/venda/

https://localhost:5001/api/Venda?Sorts=-data&Filters=data>2019-07-04T00:00:00.0Z,data<2019-07-08T23:59:59.0Z&pagesize=5&page=1
```

- Consultar uma venda pelo seu identificador.
Exemplo (acesso via GET):
```
https://localhost:5001/api/venda/1
```
