package br.com.futureinclusion.dao;

import javax.persistence.*;

import br.com.futureinclusion.entity.*;

public class MandateDAO extends GenericDAO<Mandate, Integer> {

	public MandateDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}