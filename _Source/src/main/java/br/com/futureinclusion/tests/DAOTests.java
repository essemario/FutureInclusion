package br.com.futureinclusion.tests;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.Persistence;

import br.com.futureinclusion.dao.*;
import br.com.futureinclusion.entity.*;

public class DAOTests {

	public static void main(String[] args) {
		EntityManager entityManager = null;
		try {	
			entityManager = Persistence.createEntityManagerFactory("backend").createEntityManager();
			
			CountryDAO countryDao = new CountryDAO(entityManager);			
			/*
			Country country1 = new Country();
			country1.setName("Brasil");
			countryDao.save(country1, true);
			
			Country country2 = new Country();
			country2.setName("Argentina");
			countryDao.save(country2, true);
			
			Country country3 = new Country();
			country3.setName("Uruguay");
			countryDao.save(country3, true);
			*/
			//countryDao.delete(2, true);
			/*
			Country country4 = new Country();
			country4.setName("AGENTINA 2");
			country4.setId(3);
			countryDao.save(country4, true);
			*/
			
			List<Country> countries = countryDao.getAll();
			for (Country country : countries) {
				System.out.println("PAIS: [" + country.getId() + "] " + country.getName());
			}
			
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