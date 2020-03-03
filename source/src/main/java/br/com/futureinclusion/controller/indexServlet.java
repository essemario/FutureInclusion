package br.com.futureinclusion.controller;

import java.io.IOException;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.Persistence;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import br.com.futureinclusion.dao.CountryDAO;
import br.com.futureinclusion.entity.Country;

@WebServlet({ "/index", "/" })
public class indexServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		EntityManager entityManager = null;
		try {	
			entityManager = Persistence.createEntityManagerFactory("application").createEntityManager();
			CountryDAO countryDao = new CountryDAO(entityManager);			
		
//			Country country1 = new Country();
//			country1.setName("Brasil");
//			countryDao.save(country1, true);
//			
//			Country country2 = new Country();
//			country2.setName("Argentina");
//			countryDao.save(country2, true);
//			
//			Country country3 = new Country();
//			country3.setName("Uruguay");
//			countryDao.save(country3, true);
			
//			countryDao.delete(2, true);
			
//			Country country4 = new Country();
//			country4.setName("AGENTINA 1");
//			country4.setId(3);
//			countryDao.save(country4, true);
			
			List<Country> countries = countryDao.getAll();
			request.setAttribute("countries", countries);
		} catch (Exception e) {
			e.printStackTrace();
			//entityManager.getTransaction().rollback();
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		request.getRequestDispatcher("WEB-INF/view/index.jsp").forward(request, response);
	}

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doGet(request, response);
	}

}