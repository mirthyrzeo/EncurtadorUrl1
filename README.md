# Encurtador de URL

Objetivos:
É uma API REST desenvolvida em Visual Studio 2022 utilizando C# e banco de dados PostGresql.

Este projeto tem o objetivo de receber uma URL (longa) e encurta-la, informando também se o link é válido, mostrando a quantidade de acessos daquele link e incrementando este número para contagem de futuros acessos.
Para cada URL encurtada criada, ele também irá disparar um evento que poderá ser integrado em um sistema de mensagens.

Concluídos:
*O sistema atualmente está recebendo as URL's e as encurtando, também notificando se o link é válido.

A concluir:
*O sistema ainda não dispara eventos e não foi concluído o acesso ao banco de dados PostGresql.
