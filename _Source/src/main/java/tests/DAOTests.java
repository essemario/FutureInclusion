package tests;

import javax.persistence.EntityManager;
import javax.persistence.Persistence;

import dao.*;
import entity.*;

public class DAOTests {

	public static void main(String[] args) {
		EntityManager entityManager = null;
		try {	
			entityManager = Persistence.createEntityManagerFactory("backend").createEntityManager();
			
			CountryDAO dao = new CountryDAO(entityManager);			
			/*
			Country country1 = new Country();
			country1.setName("Brasil");
			dao.save(country1, true);
			
			Country country2 = new Country();
			country2.setName("Argentina");
			dao.save(country2, true);
			
			Country country3 = new Country();
			country3.setName("Uruguay");
			dao.save(country3, true);
			*/
			//dao.delete(2, true);
			
			Country country4 = new Country();
			country4.setName("AGENTINA 2");
			country4.setId(3);
			dao.save(country4, true);
			
		} catch (Exception e) {
			e.printStackTrace();
			entityManager.getTransaction().rollback();
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
			System.exit(0);
		}
	}

}