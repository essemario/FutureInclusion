<%@ page language="java" contentType="text/html; charset=ISO-8859-1" pageEncoding="ISO-8859-1"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<title>Future Inclusion</title>
</head>
<body>
	<h1>Listando Paises</h1>
	<ul>
		<c:if test="${not empty countries}">
			<c:forEach items="${countries}" var="country">
				<li>${country.name}</li>
			</c:forEach>
		</c:if>
	</ul>
</body>
</html>