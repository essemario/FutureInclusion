<%@ page language="java" contentType="text/html; charset=ISO-8859-1" pageEncoding="ISO-8859-1"%>
<%@ page import="br.com.futureinclusion.entity.Voter"%>
<!DOCTYPE html>
<html lang="pt-br">
    <head>
        <title>Future Inclusion - Eleitor</title>
        <%@ include file="/WEB-INF/view/header.jsp" %>
    </head>
    <body>
        <%@ include file="/WEB-INF/view/menu.jsp" %>
        <div class="container box-principal">
            <div class="cadastro">
                <div class="cadastro-form rounded">
                    <form action="<c:url value="/admin?voter=save"/>" id="form-cadastro" method="post">
                    	<input type="hidden" name="id" value="<c:if test="${not empty voter}">${voter.id}</c:if>"/>
                        <h1 class="titulo-cadastro">Eleitor</h1>
                        
                        <div class="form-group">
                            <label for="first-name">Primeiro Nome: </label>
                            <input value="<c:if test="${not empty voter}">${voter.name}</c:if>" type="text" class="form-control" id="first-name" aria-describedby="first-nameHelp" placeholder="Primeiro nome" name="first-name" data-msg="Primeiro nome" required>
                        </div>
                        <div class="form-group">
                            <label for="last-name">Sobrenome: </label>
                            <input value="<c:if test="${not empty voter}">${voter.lastName}</c:if>" type="text" class="form-control" id="last-name" aria-describedby="last-nameHelp" placeholder="Sobrenome" name="last-name" data-msg="Sobrenome" required>
                        </div>
                        
                        <div class="form-group">
                            <label for="cpf">CPF: </label>
                            <input value="<c:if test="${not empty voter}">${voter.document}</c:if>" type="text" class="form-control" id="cpf" aria-describedby="cpfHelp" placeholder="Digite seu CPF" name="cpf" data-msg="Digite seu CPF" required>
                        </div>
                        
                        <div class="form-group">
                            <label for="email">E-mail: </label>
                            <input value="<c:if test="${not empty voter}">${voter.email}</c:if>" type="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Digite seu E-mail" name="email" data-msg="Digite seu email" required>
                        </div>
                        <div class="form-group">
                            <label for="email">Confirme seu e-mail: </label>
                            <input value="<c:if test="${not empty voter}">${voter.email}</c:if>" type="email-check" class="form-control" id="email-check" aria-describedby="email-checkHelp" placeholder="Confirme seu E-mail" name="email-check" data-msg="Confirme seu email" required/>
                        </div>

                        <div class="form-group">
                            <label for="password">Senha: </label>
                            <input value="<c:if test="${not empty voter}">${voter.password}</c:if>" type="password" class="form-control" id="password" placeholder="Crie uma senha" name="password" data-msg="Crie uma senha" required/>
                        </div>
                        <div class="form-group">
                            <label for="password-check">Confirme sua senha: </label>
                            <input value="<c:if test="${not empty voter}">${voter.password}</c:if>" type="password" class="form-control" id="password-check" placeholder="Confirme sua senha" name="password-check" data-msg="Confirme a senha" required/>
                        </div>

                        <div class="form-group">
                            <label for="image">Selecione uma foto</label>
                            <input type="file" class="form-control" id="image" name="file"  placeholder="Selecione uma foto" data-msg="Selecione uma foto">
                        </div>

                        <div class="btn-group btn-group-toggle" data-toggle="buttons">
                            <label class="btn btn-primary <c:if test="${(not empty voter) and (voter.enabled == '1')}">active</c:if>">
                                <input type="radio" name="status" id="enabled" autocomplete="off" value="enabled" <c:if test="${(not empty voter) and (voter.enabled == '1')}">checked</c:if>> Habilitado
                            </label>
                            <label class="btn btn-primary <c:if test="${(not empty voter) and (voter.enabled == '0')}">active</c:if>">
                                <input type="radio" name="status" id="disabled" autocomplete="off" value="disabled" <c:if test="${(not empty voter) and (voter.enabled == '0')}">checked</c:if>> Desabilitado
                            </label>
                        </div>
                        
                        <br/> <br/>

                        <input type="submit" class="btn btn-primary btn-lg btn-block" value="Enviar">
                    </form>
                </div>
            </div>
        </div>
    </body>
</html>