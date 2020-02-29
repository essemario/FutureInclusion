package dao;

import javax.persistence.*;

import entity.*;

public class UserDAO extends GenericDAO<User, Integer> {

	public UserDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}