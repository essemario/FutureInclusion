package dao;

import javax.persistence.*;

import entity.*;

public class PostDAO extends GenericDAO<Post, Integer> {

	public PostDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}