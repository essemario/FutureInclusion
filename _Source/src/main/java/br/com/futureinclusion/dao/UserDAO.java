package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class UserDAO extends GenericDAO<User, Integer> {

	public UserDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}