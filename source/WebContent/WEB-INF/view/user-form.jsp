<%@ page language="java" contentType="text/html; charset=ISO-8859-1" pageEncoding="ISO-8859-1"%>
<%@ page import="br.com.futureinclusion.entity.User"%>
<!DOCTYPE html>
<html lang="pt-br">
    <head>
        <title>Future Inclusion - Usuário</title>
        <%@ include file="/WEB-INF/view/header.jsp" %>
    </head>
    <body>
        <%@ include file="/WEB-INF/view/menu.jsp" %>
        <div class="container box-principal">
            <div class="cadastro">
                <div class="cadastro-form rounded">
                    <form action="<c:url value="/admin?user=save"/>" id="form-cadastro" method="post">
                    	<input type="hidden" name="id" value="<c:if test="${not empty user}">${user.id}</c:if>"/>
                        <h1 class="titulo-cadastro">Usuário</h1>
                        
                        <div class="form-group">
                            <label for="first-name">Primeiro Nome: </label>
                            <input value="<c:if test="${not empty user}">${user.name}</c:if>" type="text" class="form-control" id="first-name" aria-describedby="first-nameHelp" placeholder="Primeiro nome" name="first-name" data-msg="Primeiro nome" required>
                        </div>
                        <div class="form-group">
                            <label for="last-name">Sobrenome: </label>
                            <input value="<c:if test="${not empty user}">${user.lastName}</c:if>"  type="text" class="form-control" id="last-name" aria-describedby="last-nameHelp" placeholder="Sobrenome" name="last-name" data-msg="Sobrenome" required>
                        </div>

                        <div class="form-group">
                            <label for="email">E-mail: </label>
                            <input value="<c:if test="${not empty user}">${user.email}</c:if>" type="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Digite seu E-mail" name="email" data-msg="Digite seu email" required>
                        </div>
                        <div class="form-group">
                            <label for="email">Confirme seu e-mail: </label>
                            <input value="<c:if test="${not empty user}">${user.email}</c:if>" type="email-check" class="form-control" id="email-check" aria-describedby="email-checkHelp" placeholder="Confirme seu E-mail" name="email-check" data-msg="Confirme seu email" required/>
                        </div>

                        <div class="form-group">
                            <label for="password">Senha: </label>
                            <input value="<c:if test="${not empty user}">${user.password}</c:if>" type="password" class="form-control" id="password" placeholder="Crie uma senha" name="password" data-msg="Crie uma senha" required/>
                        </div>
                        <div class="form-group">
                            <label for="password-check">Confirme sua senha: </label>
                            <input value="<c:if test="${not empty user}">${user.password}</c:if>"  type="password" class="form-control" id="password-check" placeholder="Confirme sua senha" name="password-check" data-msg="Confirme a senha" required/>
                        </div>

                        <div class="form-group">
                            <label for="image">Selecione uma foto</label>
                            <input type="file" class="form-control" id="image" name="file"  placeholder="Selecione uma foto" data-msg="Selecione uma foto">
                        </div>

                        <div class="btn-group btn-group-toggle" data-toggle="buttons">
                            <label class="btn btn-primary <c:if test="${(not empty user) and (user.enabled == '1')}">active</c:if>">
                                <input type="radio" name="status" id="enabled" autocomplete="off" value="enabled" <c:if test="${(not empty user) and (user.enabled == '1')}">checked</c:if>> Habilitado
                            </label>
                            <label class="btn btn-primary <c:if test="${(not empty user) and (user.enabled == '0')}">active</c:if>">
                                <input type="radio" name="status" id="disabled" autocomplete="off" value="disabled" <c:if test="${(not empty user) and (user.enabled == '0')}">checked</c:if>> Desabilitado
                            </label>
                        </div>

                        <div class="form-group">
                            <label for="level">Tipo de usuário: </label>
                            <select id="level" class="form-control" name="level" data-msg="Selecione o tipo de usuÃ¡rio" required/>
                                <option value="0" <c:if test="${(not empty user) and (user.level == '0')}">selected</c:if>>Adminsitrador</option>
                                <option value="1" <c:if test="${(not empty user) and (user.level == '1')}">selected</c:if>>Politico</option>
                                <option value="2" <c:if test="${(not empty user) and (user.level == '2')}">selected</c:if>>Acessoria</option>
                            </select>
                        </div>
                        <input type="submit" class="btn btn-primary btn-lg btn-block" value="Enviar">
                    </form>
                </div>
            </div>
        </div>
    </body>
</html>