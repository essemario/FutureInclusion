<%@ page language="java" contentType="text/html; charset=ISO-8859-1"  pageEncoding="ISO-8859-1"%>
			<nav class="navbar navbar-expand-xl navbar-dark">
                <a class="navbar-brand" href="<c:url value="/index.jsp"/>">Future Inclusion</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav">
                        <li class="nav-item 
                        	<c:if test="${activeMenu == 'dashboard'}">
								active
							</c:if>">
                            <a class="nav-link" href="<c:url value="/admin?dashboard"/>">Dashboard</a>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle 
	                            <c:if test="${activeMenu == 'user'}">
									active
								</c:if>" href="<c:url value="/admin?user=list"/>" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Usuários
                            </a>
                            <div class="dropdown-menu bg-info" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item
	                       			<c:if test="${activeMenu == 'user' && activeSubMenu == 'new'}">
										active
									</c:if>" href="<c:url value="/admin?user=new"/>">Novo</a>
                                <a class="dropdown-item
	                       			<c:if test="${activeMenu == 'user' && activeSubMenu == 'list'}">
										active
									</c:if>" href="<c:url value="/admin?user=list"/>">Listar</a>
                            </div>
                        </li>
                        <li class="nav-item dropdown
                       			<c:if test="${activeMenu == 'voter'}">
									active
								</c:if>">
                            <a class="nav-link dropdown-toggle" href="<c:url value="/admin?voter=list"/>" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Eleitores
                            </a>
                            <div class="dropdown-menu bg-info" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item
	                       			<c:if test="${activeMenu == 'voter' && activeSubMenu == 'new'}">
										active
									</c:if>" href="<c:url value="/admin?voter=new"/>">Novo</a>
                                <a class="dropdown-item
	                       			<c:if test="${activeMenu == 'voter' && activeSubMenu == 'list'}">
										active
									</c:if>" href="<c:url value="/admin?voter=list"/>">Listar</a>
                            </div>
                        </li>
                    </ul>
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item 
	                     	<c:if test="${activeMenu == 'profile'}">
								active
							</c:if>">
                            <a class="nav-link" href="#">Meu perfil</a>
                        </li>
                    </ul>
                </div>
            </nav>