package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class PostDAO extends GenericDAO<Post, Integer> {

	public PostDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}