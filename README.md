# **shp-to-geojson**

Uma simples aplicação console que converte arquivos shapefiles(.shp) para arquivos GeoJSON.

## **Como gerar o executável**

Para gerar o arquivo executável, basta rodar um dos comandos abaixo:

*Windows 64bits*

`dotnet publish -c Release -r win-x64`

*Linux 64bits*

`dotnet publish -c Release -r linux-x64`

## **Utilização**

A aplicação pode ser executada de duas formas:
- Informando o nome do arquivo shapefile como argumento.<br>
Desta forma, é importante que o **executável** e o **arquivo shapefile** estejam na **mesma pasta**:

![Exemplo de execução informando o nome do arquivo](/assets/example1.jpg)

- Ou sem informar o nome do arquivo como argumento.<br>
Neste caso, você pode informar o nome do arquivo shapefile(se estiver na mesma pasta que o executável) ou informar o caminho do arquivo:

![Exemplo de execução sem informar o nome do arquivo](/assets/example2.jpg)

## Dependências

Essa aplicação utiliza as bibliotecas:
- NetTopologySuite.IO.GeoJSON
- NetTopologySuite.IO.ShapeFile

# English description

Simple console application that converts shapefiles(.shp) to GeoJSON.