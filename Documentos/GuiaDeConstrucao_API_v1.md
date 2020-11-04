Legenda
	-> Envio via API
	<- Resposta API
	:> Vai para a tela
	:< Interação do usuário
	->> Votar
	| Condicional
	EP: Ending Points
Feed
	EP: /api/Feed ->> Lista todos as POLLs
	https://futureinclusionbackend.azurewebsites.net/api/feed
	EP: /api/Feed/ID ->> Lista todos as POLLs dizendo se o VOTER do ID já votou em cada POLL
	https://futureinclusionbackend.azurewebsites.net/api/feed/1
	-> enviamos id da pessoa
	<- recebemos lista de items
		:> No topo eXquerdo exibir FOTO, Nome, Mandato Nome
		| Lista de POLL ->> Exibe e Pode ser votada
			:> Titulo
			:> Descrição
			| Se ainda não votou: 
				:> Alternativas
					:> Texto 
						:< Clicavel ->> Votar
			| Se já votou: 
				:> Alternativas 
					:> Texto (Marcar o voto da pessoa)
						:> Barra e porcentagem
			
Perfil pessoal
	EP: api/PerfilPessoal/ID  ->> Tras o perfil do VOTER do ID que enviamos
	-> enviamos o id da pessoa
	<- recebemos os dados da pessoa
		:> Foto 
			| Se não tiver ->> Exibe foto padrão
			| Se tiver ->> Exibe foto
		:> Nome
		:> Seguindo
		:> Pesquisas respondidas
		
Perfil politico
	
	-> enviamos o id do politico e da pessoa
	<- recebemos os dados do politico e lista de items
		:> Nome
			:> Mandato nome
		:> Seguidores
		:> lista de items
		| Lista de POLL ->> Exibe e Pode ser votada
			:> Titulo
			:> Descrição
			| Se ainda não votou: 
				:> Alternativas
					:> Texto 
						:< Clicavel ->> Votar
			| Se já votou: 
				:> Alternativas 
					:> Texto (Marcar o voto da pessoa)
						:> Barra e porcentagem
Pesquisa (Users)
	-> Enviamos a pesquisa
	<- Lista de perfils
	:> Nome
	:> Mandato nome
	:> Poder
	:> Data de inicio
	:> Data de fim
	
	
	
- Mini perfil 
- POLL
- Alternativa votavel
- Alternativa resultado