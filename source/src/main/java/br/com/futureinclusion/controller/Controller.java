package br.com.futureinclusion.controller;

import javax.persistence.EntityManager;
import javax.persistence.Persistence;

public class Controller {
	
	EntityManager entityManager = null;
	
	Controller(){
		entityManager = Persistence.createEntityManagerFactory("application").createEntityManager();
	}
	
}
