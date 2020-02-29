package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class SphereDAO extends GenericDAO<Sphere, Integer> {

	public SphereDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}