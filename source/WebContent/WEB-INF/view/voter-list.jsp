<%@ page language="java" contentType="text/html; charset=ISO-8859-1" pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html lang="pt_BR">
    <head>
        <title>FutureInclusion - Listar Usuários</title>
        <%@ include file="/WEB-INF/view/header.jsp" %>
        <script src="<c:url value="/js/_listagem.js"/>"></script>
    </head>
    <body>
        <%@ include file="/WEB-INF/view/menu.jsp" %>
        <div class="content">
            <div class="listagem-box">
                <div class="modal fade" id="confirm-delete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">!ATENÇÃO!</div>
                            <div class="modal-body">Tem certeza que deseja deletar este registro?</div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                <a class="btn btn-danger btn-ok">DELETAR</a>
                            </div>
                        </div>
                    </div>
                </div>
                <table class="table table-striped table-hover table-responsive-md">
                    <thead class="bg-info text-light">
                        <tr>
                            <th scope="col" class="d-none d-lg-table-cell">ID</th>
                            <th scope="col">Nome</th>
                            <th scope="col">E-mail</th>
                            <th scope="col">CPF</th>
                            <th scope="col">Estado</th>
                            <th scope="col">Editar</th>
                            <th scope="col">Excluir</th>
                        </tr>
                    </thead>
                    <tbody>
						<c:forEach items="${voters}" var="voter">
							<tr class='tabela-linha-clicavel' data-href='<c:url value="/admin?voter=edit&id=${voter.id}"/>'>
	                            <td scope="row" class="d-none d-lg-table-cell">${voter.id}</th>
	                            <td>${voter.name}</td>
	                            <td>${voter.email}</td>
	                            <td>${voter.document}</td>
	                            <td><c:out value="${voter.enabled eq 1 ? 'Habilitado': 'Desabilitado'}"/></td>
	                            <td class="td-acaoes d-none d-lg-table-cell">
	                            	<a href="<c:url value="/admin?voter=edit&id=${voter.id}"/>" class="btn btn-secondary">Editar</a>
	                            </td>
	                            <td class="td-acaoes">
	                            	<a 	href="#" 
	                            		class="btn btn-danger" 
	                            		data-href="<c:url value="/admin?voter=delete&id=${voter.id}"/>" 
	                            		data-toggle="modal" data-target="#confirm-delete">
		                            	Excluir
	                            	</a>
                            	</td>
	                        </tr>
						</c:forEach>
                    </tbody>
                </table>
            </div>
        </div>
    </body>
</html>