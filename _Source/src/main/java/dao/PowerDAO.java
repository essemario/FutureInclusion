package dao;

import javax.persistence.*;

import entity.*;

public class PowerDAO extends GenericDAO<Power, Integer> {

	public PowerDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}