package dao;

import javax.persistence.*;

import entity.*;

public class SphereDAO extends GenericDAO<Sphere, Integer> {

	public SphereDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}