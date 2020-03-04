<%@ page language="java" contentType="text/html; charset=ISO-8859-1" pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html lang="pt-br">
    <head>
        <title>Future Inclusion - Login</title>
        <%@ include file="/WEB-INF/view/header.jsp" %>
    </head>
    <body>
        <div class="container h-100">
        <h5 class="h4">Login não está funcionando, apenas clique em entrar.</h5>
                <div class="login">
                    <div class="jumbotron">
                        <div class="login-form">
                            <h4 class="h3">Bem vindo(a) ao FutureInclusion</h4>
                            <br/>
                            <br/>
                            <form action="<c:url value="/admin?dashboard"/>" method="POST"  id="form-login" class="needs-validation">
                                <div class="form-group">
                                    <label for="email">Email: </label>
                                    <input type="email" class="form-control" id="email" name="email" aria-describedby="emailHelp" placeholder="Digite seu email" data-msg="Digite seu email!">
                                </div>
                                <div class="form-group">
                                    <label for="senha">Senha: </label>
                                    <input type="password" class="form-control" id="senha" name="senha"placeholder="Senha" data-msg="Digite sua senha">
                                </div>
                                <button type="submit" class="btn btn-primary">Entrar</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
    </body>
</html>