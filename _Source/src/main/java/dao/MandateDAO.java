package dao;

import javax.persistence.*;

import entity.*;

public class MandateDAO extends GenericDAO<Mandate, Integer> {

	public MandateDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}