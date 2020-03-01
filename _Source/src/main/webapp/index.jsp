<html>

	<head>
		<title>Titulo</title>
		<%@ include file="header.jsp" %>
	</head>
	
	<body>
		<h2>Hello World!</h2>
		<a href="ServletTest" class="test btn btn-success">Botão</a>
			
			<form action="challenge" method="post">
				<label>nome do challenge</label>
				<input type="text" name="name">
				
				<label>questao</label>
				<input type="text" name="question">
				
				<button type="submit">Submit</button>	
			</form>
	</body>

</html>
